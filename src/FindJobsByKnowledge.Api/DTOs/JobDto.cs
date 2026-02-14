namespace FindJobsByKnowledge.Api.DTOs;

public class JobDto
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Company { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public decimal? Salary { get; set; }
    public DateTime PostedDate { get; set; }
    public List<string> Tags { get; set; } = new();
    public string Source { get; set; } = string.Empty;
}
