using Domain.Enum;

namespace Domain.Entities;
public class Person : Entity
{


    public Person(string firstName, string LastName, DateTime dateOfBirth, GenderType gender, string birthPlace)
    {
        this.FirstName = firstName;
        this.LastName = LastName;
        this.DateOfBirth = dateOfBirth;
        this.Gender = gender;
        this.BirthPlace = birthPlace;

    }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public GenderType Gender { get; set; }
    public string BirthPlace { get; set; }
    public DateTime? CreatedAt { get; set; } = null;
    public DateTime? UpdatedAt { get; set; } = null;

}