using Domain.Enum;

namespace Application.DTOs.Person
{
    public class PersonFilter
    {
        public string? Name { get; set; }
        public string?  Gender { get; set; }
        public string? BirthPlace { get; set; }
    }
}