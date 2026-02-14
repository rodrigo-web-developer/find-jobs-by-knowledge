namespace FindJobsByKnowledge.Api.Models;

public class CreateJobRequest
{
    public string Title { get; set; } = string.Empty;
    public string Company { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public decimal? Salary { get; set; }
    public DateTime PostedDate { get; set; }
    public List<string> RequiredKnowledge { get; set; } = new();
}

public class UpdateJobRequest
{
    public string Title { get; set; } = string.Empty;
    public string Company { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public decimal? Salary { get; set; }
    public DateTime PostedDate { get; set; }
    public List<string> RequiredKnowledge { get; set; } = new();
}
