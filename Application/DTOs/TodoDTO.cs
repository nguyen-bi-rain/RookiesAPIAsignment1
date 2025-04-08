namespace Application.DTOs;

public class TodoDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted  { get; set; }
}
