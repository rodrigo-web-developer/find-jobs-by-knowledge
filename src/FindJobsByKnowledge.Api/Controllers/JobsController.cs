using FindJobsByKnowledge.Api.Models;
using FindJobsByKnowledge.Domain.Entities;
using FindJobsByKnowledge.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FindJobsByKnowledge.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobsController : ControllerBase
{
    private readonly IJobRepository _jobRepository;
    private readonly ILogger<JobsController> _logger;

    public JobsController(IJobRepository jobRepository, ILogger<JobsController> logger)
    {
        _jobRepository = jobRepository;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Job>>> GetAll()
    {
        var jobs = await _jobRepository.GetAllAsync();
        return Ok(jobs);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Job>> GetById(Guid id)
    {
        var job = await _jobRepository.GetByIdAsync(id);
        if (job == null)
        {
            return NotFound();
        }
        return Ok(job);
    }

    [HttpGet("search/{knowledge}")]
    public async Task<ActionResult<IEnumerable<Job>>> GetByKnowledge(string knowledge)
    {
        var jobs = await _jobRepository.GetByKnowledgeAsync(knowledge);
        return Ok(jobs);
    }

    [HttpPost]
    public async Task<ActionResult<Job>> Create(CreateJobRequest request)
    {
        var job = new Job
        {
            Title = request.Title,
            Company = request.Company,
            Description = request.Description,
            Location = request.Location,
            Salary = request.Salary,
            PostedDate = request.PostedDate,
            RequiredKnowledge = request.RequiredKnowledge
        };

        var createdJob = await _jobRepository.CreateAsync(job);
        return CreatedAtAction(nameof(GetById), new { id = createdJob.Id }, createdJob);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Job>> Update(Guid id, UpdateJobRequest request)
    {
        var existingJob = await _jobRepository.GetByIdAsync(id);
        if (existingJob == null)
        {
            return NotFound();
        }

        existingJob.Title = request.Title;
        existingJob.Company = request.Company;
        existingJob.Description = request.Description;
        existingJob.Location = request.Location;
        existingJob.Salary = request.Salary;
        existingJob.PostedDate = request.PostedDate;
        existingJob.RequiredKnowledge = request.RequiredKnowledge;

        var updatedJob = await _jobRepository.UpdateAsync(existingJob);
        return Ok(updatedJob);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var job = await _jobRepository.GetByIdAsync(id);
        if (job == null)
        {
            return NotFound();
        }

        await _jobRepository.DeleteAsync(id);
        return NoContent();
    }
}
