
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Infrastructure.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _context;
        public PersonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddPersonAsync(Person person)
        {
            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePersonAsync(Person person)
        {
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Person>> GetAllPersonsAsync()
        {
            var persons = await _context.Persons.ToListAsync();
            return persons;
        }

        public Task<Person> GetPersonByIdAsync(Guid id)
        {
            var person  = _context.Persons.FirstOrDefaultAsync(x => x.Id == id);
            return person;
        }

        public async Task UpdatePersonAsync(Person person)
        {
            _context.Persons.Update(person);
            await _context.SaveChangesAsync();
        }
    }
}