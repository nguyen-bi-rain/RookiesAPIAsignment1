using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Infrastructure.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly ApplicationDbContext _context;
        public TodoRepository(ApplicationDbContext context)
        {
            _context = context; 
        }
        public async Task AddAsync(Todo todo)
        {
            await _context.Todos.AddAsync(todo);
            await _context.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<Todo> todos)
        {
            foreach(var todo in todos)
            {
                await _context.Todos.AddAsync(todo);
            }
            await _context.SaveChangesAsync();    
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var todo = _context.Todos.Find(id);
            if (todo == null) return false;
            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task DeleteRangeAsync(IEnumerable<Guid> taskId)
        {
            var tasksToDelete = await _context.Todos
                 .Where(t => taskId.Contains(t.Id))
                 .ToListAsync();

            _context.Todos.RemoveRange(tasksToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Todo>> GetAllAsync()
        {
            return await _context.Todos.ToListAsync();
        }

        public async Task<Todo> GetByIdAsync(Guid id)
        {
            var todo = await _context.Todos.FirstOrDefaultAsync(x => x.Id == id);
            return todo;
        }

        public async Task UpdateAsync(Todo todo)
        {
            _context.Todos.Update(todo);
            await _context.SaveChangesAsync();
        }
    }
}
