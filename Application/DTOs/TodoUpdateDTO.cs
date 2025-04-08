using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class TodoUpdateDTO
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        [MaxLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string Description { get; set; } 
        public bool IsCompleted { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
