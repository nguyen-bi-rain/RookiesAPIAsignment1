namespace Domain.Entities
{
    public class Todo : Entity
    {
        public Todo(string title, string description)
        {
            Title = title;
            Description = description;
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; } = false;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; } 

    }
}
