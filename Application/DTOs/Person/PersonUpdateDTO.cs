
using Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Person
{
    public class PersonUpdateDTO
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "First name is required")]
        [MaxLength(50, ErrorMessage = "First name cannot exceed 50 characters")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        [MaxLength(50, ErrorMessage = "Last name cannot exceed 50 characters")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public GenderType Gender { get; set; }
        [Required(ErrorMessage = "Birth Place is required")]
        public string BirthPlace { get; set; }
        public DateTime? UpdatedAt { get; set; } = null;
    }
}