using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IMapper _mapper;
        public TodoService(ITodoRepository todoRepository, IMapper mapper)
        {
            _todoRepository = todoRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<TodoDTO>> BulkCreateTasksAsync(List<TodoCreateDTO> bulkCreateTaskDto)
        {
            var todos = _mapper.Map<List<Todo>>(bulkCreateTaskDto);
            await _todoRepository.AddRangeAsync(todos);
            return _mapper.Map<IEnumerable<TodoDTO>>(todos);

        }

        public async Task BulkDeleteTasksAsync(BulkDeleteTaskDTO bulkDeleteTaskDto)
        {
            var todoIds = bulkDeleteTaskDto.TodoIds;
            await _todoRepository.DeleteRangeAsync(todoIds);
        }

        public async Task<TodoDTO> CreateTaskAsync(TodoCreateDTO createTaskDto)
        {
            
            var model = _mapper.Map<Todo>(createTaskDto);
            model.Id = Guid.NewGuid(); // Ensure a new ID is generated for the new task
            await _todoRepository.AddAsync(model);
            return _mapper.Map<TodoDTO>(createTaskDto);
        }

        public async Task DeleteTaskAsync(Guid id)
        {
            var isDeleted = await _todoRepository.DeleteAsync(id);
            if (!isDeleted)
            {
                throw new Exception("Task not found");
            }
        }

        public async Task<IEnumerable<TodoDTO>> GetAllTodoAsync()
        {
            var todos = await _todoRepository.GetAllAsync();
            if (todos == null)
            {
                throw new Exception("No tasks found");
            }
            return _mapper.Map<IEnumerable<TodoDTO>>(todos);

        }

        public async Task<TodoDTO> GetTodoByIdAsync(Guid id)
        {
            var todo = await _todoRepository.GetByIdAsync(id);
            if (todo == null)
            {
                throw new Exception("Task not found");
            }
            return _mapper.Map<TodoDTO>(todo);
        }


        public async Task UpdateTaskAsync(Guid id, TodoUpdateDTO updateTaskDto)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id), "Task ID cannot be null");
            }
            
            var model = _mapper.Map<Todo>(updateTaskDto);
            await _todoRepository.UpdateAsync(model);
        }
    }
}
