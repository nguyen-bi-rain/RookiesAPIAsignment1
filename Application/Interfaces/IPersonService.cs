using Application.DTOs;
using Application.DTOs.Person;

namespace Application.Interfaces
{
    public interface IPersonService
    {
        Task<PersonDTO> GetPersonByIdAsync(Guid id);
        Task<IEnumerable<PersonDTO>> GetAllPersonsAsync();
        Task<PersonDTO> AddPersonAsync(PersonCreateDTO person);
        Task UpdatePersonAsync(PersonUpdateDTO person);
        Task DeletePersonAsync(Guid id);
        Task<IEnumerable<PersonDTO>> GetPersonsByFilterAsync(PersonFilter filter);
    }
}