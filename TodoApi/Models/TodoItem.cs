namespace TodoApi.Models;

public class TodoItem
{
    public long Id { get; set; }
    public string? Title { get; set; }
    public string? Body{ get; set; }
    public bool IsComplete { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
}
