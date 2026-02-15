using FindJobsByKnowledge.Domain.DTOs;
using FindJobsByKnowledge.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace FindJobsByKnowledge.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuestionsController : ControllerBase
{
    private readonly IQuestionService _questionService;
    private readonly ILogger<QuestionsController> _logger;

    public QuestionsController(IQuestionService questionService, ILogger<QuestionsController> logger)
    {
        _questionService = questionService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetAll()
    {
        var questions = await _questionService.GetAllAsync();
        return Ok(questions);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<QuestionDto>> GetById(Guid id)
    {
        var question = await _questionService.GetByIdAsync(id);
        if (question == null) return NotFound();
        return Ok(question);
    }

    [HttpGet("tag/{tag}")]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetByTag(string tag)
    {
        var questions = await _questionService.GetByTagAsync(tag);
        return Ok(questions);
    }

    [HttpGet("tag/{tag}/level/{level:int}")]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetByTagAndLevel(string tag, int level)
    {
        if (level < 1 || level > 5)
            return BadRequest("Level must be between 1 and 5");

        var questions = await _questionService.GetByTagAndLevelAsync(tag, level);
        return Ok(questions);
    }

    [HttpPost]
    public async Task<ActionResult<QuestionDto>> Create([FromBody] QuestionDto question)
    {
        if (string.IsNullOrWhiteSpace(question.Tag))
            return BadRequest("Tag is required");
        if (string.IsNullOrWhiteSpace(question.Text))
            return BadRequest("Text is required");
        if (question.Options == null || question.Options.Count < 2)
            return BadRequest("At least 2 options are required");
        if (question.CorrectOptionIndex < 0 || question.CorrectOptionIndex >= question.Options.Count)
            return BadRequest("CorrectOptionIndex must be a valid index in the Options list");
        if (question.Level < 1 || question.Level > 5)
            return BadRequest("Level must be between 1 and 5");

        var created = await _questionService.CreateAsync(question);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<QuestionDto>> Update(Guid id, [FromBody] QuestionDto question)
    {
        if (string.IsNullOrWhiteSpace(question.Tag))
            return BadRequest("Tag is required");
        if (string.IsNullOrWhiteSpace(question.Text))
            return BadRequest("Text is required");
        if (question.Options == null || question.Options.Count < 2)
            return BadRequest("At least 2 options are required");
        if (question.CorrectOptionIndex < 0 || question.CorrectOptionIndex >= question.Options.Count)
            return BadRequest("CorrectOptionIndex must be a valid index in the Options list");

        var updated = await _questionService.UpdateAsync(id, question);
        if (updated == null) return NotFound();
        return Ok(updated);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var success = await _questionService.DeleteAsync(id);
        if (!success) return NotFound();
        return NoContent();
    }
}
