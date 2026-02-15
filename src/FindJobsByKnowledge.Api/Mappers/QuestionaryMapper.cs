using FindJobsByKnowledge.Domain.DTOs;
using FindJobsByKnowledge.Domain.Entities;

namespace FindJobsByKnowledge.Api.Mappers;

/// <summary>
/// Maps Questionary entities to QuestionaryDto and AssessmentResultDto.
/// Reuses TagLevel.LevelName for level-to-name conversion.
/// </summary>
public static class QuestionaryMapper
{
    public static QuestionaryDto MapToDto(Questionary questionary, bool hideCorrectAnswers)
    {
        return new QuestionaryDto
        {
            Id = questionary.Id,
            Tags = questionary.Tags,
            IsCompleted = questionary.IsCompleted,
            CreatedAt = questionary.CreatedAt,
            CompletedAt = questionary.CompletedAt,
            Items = questionary.Items.Select(i => new QuestionaryItemDto
            {
                Id = i.Id,
                QuestionId = i.QuestionId,
                Tag = i.Question.Tag,
                Level = i.Question.Level,
                Text = i.Question.Text,
                Options = i.Question.Options,
                SelectedOptionIndex = i.SelectedOptionIndex,
                IsCorrect = hideCorrectAnswers ? null : i.IsCorrect
            }).ToList(),
            Results = questionary.IsCompleted
                ? questionary.Results.Select(MapTagResult).ToList()
                : null
        };
    }

    public static AssessmentResultDto MapToAssessmentResult(Questionary questionary)
    {
        return new AssessmentResultDto
        {
            QuestionaryId = questionary.Id,
            Results = questionary.Results.Select(MapTagResult).ToList(),
            RecommendedSearchTags = questionary.Results.Select(r => new TagLevel
            {
                Tag = r.Tag,
                Level = r.DeterminedLevel
            }).ToList()
        };
    }

    private static TagResultDto MapTagResult(TagResult r) => new()
    {
        Tag = r.Tag,
        DeterminedLevel = r.DeterminedLevel,
        DeterminedLevelName = new TagLevel { Level = r.DeterminedLevel }.LevelName,
        CorrectPercentage = r.CorrectPercentage,
        PercentagePerLevel = r.PercentagePerLevel
    };
}
