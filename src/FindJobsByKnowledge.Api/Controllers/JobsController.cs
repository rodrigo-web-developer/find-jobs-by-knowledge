using FindJobsByKnowledge.Domain.DTOs;
using FindJobsByKnowledge.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace FindJobsByKnowledge.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobsController : ControllerBase
{
    private readonly IJobService _jobService;
    private readonly ILogger<JobsController> _logger;

    public JobsController(IJobService jobService, ILogger<JobsController> logger)
    {
        _jobService = jobService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<JobDto>>> GetAll()
    {
        var jobs = await _jobService.FindJobsByTags(Array.Empty<TagLevel>());
        return Ok(jobs);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<JobDto>> GetById(string id)
    {
        var job = await _jobService.GetJobById(id);
        if (job == null)
        {
            return NotFound();
        }
        return Ok(job);
    }

    [HttpPost("search")]
    public async Task<ActionResult<IEnumerable<JobDto>>> FindByTags([FromBody] TagLevel[] tags)
    {
        if (tags == null || tags.Length == 0)
        {
            return await GetAll();
        }

        var jobs = await _jobService.FindJobsByTags(tags);
        return Ok(jobs);
    }

    [HttpGet("search/{tag}")]
    public async Task<ActionResult<IEnumerable<JobDto>>> FindByTag(string tag, [FromQuery] int level = 3)
    {
        var tagLevel = new TagLevel { Tag = tag, Level = Math.Clamp(level, 1, 5) };
        var jobs = await _jobService.FindJobsByTags(new[] { tagLevel });
        return Ok(jobs);
    }
}
