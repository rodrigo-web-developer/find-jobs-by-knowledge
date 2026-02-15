using FindJobsByKnowledge.Domain.DTOs;
using FindJobsByKnowledge.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace FindJobsByKnowledge.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuestionaryController : ControllerBase
{
    private readonly IQuestionaryService _questionaryService;
    private readonly ILogger<QuestionaryController> _logger;

    public QuestionaryController(IQuestionaryService questionaryService, ILogger<QuestionaryController> logger)
    {
        _questionaryService = questionaryService;
        _logger = logger;
    }

    /// <summary>
    /// Generate a new questionary based on selected tags.
    /// Creates a form with at least 5 questions per level for each tag.
    /// </summary>
    [HttpPost("generate")]
    public async Task<ActionResult<QuestionaryDto>> Generate([FromBody] GenerateQuestionaryRequest request)
    {
        if (request.Tags == null || request.Tags.Count == 0)
            return BadRequest("At least one tag is required");

        var questionary = await _questionaryService.GenerateAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = questionary.Id }, questionary);
    }

    /// <summary>
    /// Get all questionaries
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<QuestionaryDto>>> GetAll()
    {
        var questionaries = await _questionaryService.GetAllAsync();
        return Ok(questionaries);
    }

    /// <summary>
    /// Get a specific questionary by ID
    /// </summary>
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<QuestionaryDto>> GetById(Guid id)
    {
        var questionary = await _questionaryService.GetByIdAsync(id);
        if (questionary == null) return NotFound();
        return Ok(questionary);
    }

    /// <summary>
    /// Submit answers for a questionary and get assessment results.
    /// Calculates skill level per tag based on correct answer percentages.
    /// </summary>
    [HttpPost("{id:guid}/submit")]
    public async Task<ActionResult<AssessmentResultDto>> SubmitAnswers(Guid id, [FromBody] SubmitAnswersRequest request)
    {
        if (request.Answers == null || request.Answers.Count == 0)
            return BadRequest("At least one answer is required");

        var result = await _questionaryService.SubmitAnswersAsync(id, request);
        if (result == null) return NotFound();
        return Ok(result);
    }

    /// <summary>
    /// Get assessment results for a completed questionary
    /// </summary>
    [HttpGet("{id:guid}/results")]
    public async Task<ActionResult<AssessmentResultDto>> GetResults(Guid id)
    {
        var result = await _questionaryService.GetResultsAsync(id);
        if (result == null) return NotFound("Questionary not found or not yet completed");
        return Ok(result);
    }
}
