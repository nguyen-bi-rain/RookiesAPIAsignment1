using Application.DTOs;

namespace Application.Interfaces
{
    public interface ITodoService
    {
        Task<TodoDTO> CreateTaskAsync(TodoCreateDTO createTaskDto);
        Task<IEnumerable<TodoDTO>> GetAllTodoAsync();
        Task<TodoDTO> GetTodoByIdAsync(Guid id);
        Task UpdateTaskAsync(Guid id, TodoUpdateDTO updateTaskDto);
        Task DeleteTaskAsync(Guid id);
        Task<IEnumerable<TodoDTO>> BulkCreateTasksAsync(List<TodoCreateDTO> bulkCreateTaskDto);
        Task BulkDeleteTasksAsync(BulkDeleteTaskDTO bulkDeleteTaskDto);
    }
}
