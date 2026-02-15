using FindJobsByKnowledge.Domain.DTOs;
using FindJobsByKnowledge.Domain.Entities;

namespace FindJobsByKnowledge.Api.Mappers;

/// <summary>
/// Maps Question entities to QuestionDto
/// </summary>
public static class QuestionMapper
{
    public static QuestionDto MapToDto(Question q) => new()
    {
        Id = q.Id,
        Tag = q.Tag,
        Level = q.Level,
        Text = q.Text,
        Options = q.Options,
        CorrectOptionIndex = q.CorrectOptionIndex
    };
}
