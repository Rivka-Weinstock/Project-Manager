namespace Models.Entities;

public class TaskItem
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime? DueDate { get; set; }
    public int StatusId { get; set; }
    public int ProjectId { get; set; }

    public Status Status { get; set; } = null!;
    public Project Project { get; set; } = null!;
}
