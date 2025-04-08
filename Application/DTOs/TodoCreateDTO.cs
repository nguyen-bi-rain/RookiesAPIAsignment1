using System.ComponentModel.DataAnnotations;

namespace Application.DTOs;

public class TodoCreateDTO
{
    [Required(ErrorMessage = "Tile is require")]
    [MaxLength(100)]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }


}
