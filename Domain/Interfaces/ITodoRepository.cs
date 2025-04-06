using Domain.Entities;
namespace Domain.Interfaces;

public interface ITodoRepository
{
    Task AddAsync(Todo todo);
    Task AddRangeAsync(IEnumerable<Todo> todos);
    Task<IEnumerable<Todo>> GetAllAsync();
    Task<Todo> GetByIdAsync(Guid id);
    Task UpdateAsync(Todo todo);
    Task DeleteRangeAsync(IEnumerable<Guid> taskId);
    Task<bool> DeleteAsync(Guid id);
}
