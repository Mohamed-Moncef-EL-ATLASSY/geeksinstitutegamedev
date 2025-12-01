using System;

public enum TaskStatus
{
    Pending,
    Completed
}

public class TaskItem
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TaskStatus Status { get; set; } = TaskStatus.Pending;
    public DateTime? DueDate { get; set; }

    public override string ToString()
    {
        string due = DueDate.HasValue ? DueDate.Value.ToString("yyyy-MM-dd") : "None";
        return $"[{(Status == TaskStatus.Completed ? 'X' : ' ')}] {Title} (Due: {due})\n    {Description}";
    }
}