using System.Linq.Expressions;
using Application.DTOs;
using Application.DTOs.Person;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Enum;
using Domain.Interfaces;
using Microsoft.VisualBasic;

namespace Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IMapper _mapper;
        private readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            _mapper = mapper;
            _personRepository = personRepository;
        }

        public async Task<PersonDTO> AddPersonAsync(PersonCreateDTO person)
        {
            var persons = await _personRepository.GetAllPersonsAsync();
            if (persons.Any(x => x.LastName == person.LastName && x.DateOfBirth == person.DateOfBirth)) throw new ArgumentException("Person already exists");
            var personEntity = _mapper.Map<Person>(person);
            personEntity.Id = Guid.NewGuid(); // Ensure a new ID is generated
            personEntity.CreatedAt = DateTime.UtcNow; // Set the creation date
            await _personRepository.AddPersonAsync(personEntity);
            return _mapper.Map<PersonDTO>(personEntity); // Return the created person as DTO
        }

        public async Task DeletePersonAsync(Guid id)
        {
            var person = await _personRepository.GetPersonByIdAsync(id);
            if (person == null) throw new KeyNotFoundException("Person not found");
            await _personRepository.DeletePersonAsync(person);
        }

        public async Task<IEnumerable<PersonDTO>> GetAllPersonsAsync()
        {
            var persons = await _personRepository.GetAllPersonsAsync();
            if (persons == null || !persons.Any()) throw new KeyNotFoundException("No persons found");
            return _mapper.Map<IEnumerable<PersonDTO>>(persons); 
        }

        public async Task<PersonDTO> GetPersonByIdAsync(Guid id)
        {
            var person = await _personRepository.GetPersonByIdAsync(id);
            if (person == null) throw new KeyNotFoundException("Person not found");
            return _mapper.Map<PersonDTO>(person);
        }

        public async Task<IEnumerable<PersonDTO>> GetPersonsByFilterAsync(PersonFilter filter)
        {
            var persons = _personRepository.GetAllPersonsAsync().Result.AsQueryable(); // Get all persons from the repository
            if(filter == null) return _mapper.Map<IEnumerable<PersonDTO>>(persons); // If no filter, return all persons
            if (!string.IsNullOrEmpty(filter.Name))
            {
                persons = persons.Where(x => x.FirstName.Contains(filter.Name) || x.LastName.Contains(filter.Name)); // Filter by name
            }
            if(Enum.TryParse(filter.Gender , out GenderType res )){
                persons = persons.Where(x => x.Gender == res);
            }
            if (!string.IsNullOrEmpty(filter.BirthPlace))
            {
                persons = persons.Where(x => x.BirthPlace.Contains(filter.BirthPlace)); // Filter by birth place
            }
            return _mapper.Map<IEnumerable<PersonDTO>>(persons.ToList()); // Return the filtered persons as DTOs
            
        }

        public async Task UpdatePersonAsync(PersonUpdateDTO person)
        {
            var personEntity = _mapper.Map<Person>(person);
            personEntity.UpdatedAt = DateTime.UtcNow; // Set the update date
            await _personRepository.UpdatePersonAsync(personEntity); // Assuming UpdatePersonAsync is implemented in the repository
        }
    }
}