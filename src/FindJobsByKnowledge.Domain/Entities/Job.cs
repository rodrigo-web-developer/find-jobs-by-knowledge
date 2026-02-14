namespace FindJobsByKnowledge.Domain.Entities;

public class Job
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Company { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public decimal? Salary { get; set; }
    public DateTime PostedDate { get; set; }
    public List<string> RequiredKnowledge { get; set; } = new();
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
