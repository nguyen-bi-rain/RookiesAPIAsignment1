using Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Person
{
    public class PersonCreateDTO
    {
        [Required(ErrorMessage = "First name is required")]
        [MaxLength(50, ErrorMessage = "First name cannot exceed 50 characters")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        [MaxLength(50, ErrorMessage = "Last name cannot exceed 50 characters")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        [EnumDataType(typeof(GenderType), ErrorMessage = "Invalid gender type Gender must be Male(0), Female(1), Other(2)")]
        public GenderType Gender { get; set; }
        [Required(ErrorMessage = "Birth Place is required")]
        public string BirthPlace { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}