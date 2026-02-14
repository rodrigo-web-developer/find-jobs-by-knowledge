namespace FindJobsByKnowledge.Api.Models;

public class CreateJobRequest
{
    public required string Title { get; set; } = string.Empty;
    public required string Company { get; set; } = string.Empty;
    public required string Description { get; set; } = string.Empty;
    public required string Location { get; set; } = string.Empty;
    public decimal? Salary { get; set; }
    public DateTime PostedDate { get; set; }
    public List<string> RequiredKnowledge { get; set; } = new();
}

public class UpdateJobRequest
{
    public required string Title { get; set; } = string.Empty;
    public required string Company { get; set; } = string.Empty;
    public required string Description { get; set; } = string.Empty;
    public required string Location { get; set; } = string.Empty;
    public decimal? Salary { get; set; }
    public DateTime PostedDate { get; set; }
    public List<string> RequiredKnowledge { get; set; } = new();
}
