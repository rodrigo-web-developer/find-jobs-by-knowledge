namespace FindJobsByKnowledge.Domain.DTOs;

/// <summary>
/// Full assessment results including job recommendations
/// </summary>
public class AssessmentResultDto
{
    public Guid QuestionaryId { get; set; }
    public List<TagResultDto> Results { get; set; } = new();
    public List<TagLevel> RecommendedSearchTags { get; set; } = new();
}
