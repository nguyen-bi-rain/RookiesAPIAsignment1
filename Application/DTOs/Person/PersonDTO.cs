using Domain.Enum;

namespace Application.DTOs;

public class PersonDTO
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public GenderType Gender { get; set; }
    public string BirthPlace { get; set; }
}