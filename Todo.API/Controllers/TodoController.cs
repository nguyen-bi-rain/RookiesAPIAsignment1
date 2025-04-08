using Application.DTOs;
using Application.Interfaces;
using Domain.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Todo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;
        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }
        /// <summary>
        /// Get all todos
        /// </summary>
        /// <returns>list all data</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<TodoDTO>), 200)]
        [ProducesResponseType(typeof(TodoDTO), 404)]
        public async Task<IActionResult> GetAllTodos()
        {
            var todos = await _todoService.GetAllTodoAsync();
            if (todos == null || !todos.Any())
            {
                return NotFound(ApiResponse<string>.Fail("No Task found", HttpStatusCode.NotFound));
            }
            return Ok(ApiResponse<List<TodoDTO>>.Ok(todos.ToList()));
        }
        /// <summary>
        /// Get todo by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>to do</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TodoDTO), 200)]
        [ProducesResponseType(typeof(TodoDTO), 404)]
        [ProducesResponseType(typeof(TodoDTO), 400)]
        public async Task<IActionResult> GetTodoById(Guid id)
        {
            try
            {
                var todo = await _todoService.GetTodoByIdAsync(id);
                return Ok(ApiResponse<TodoDTO>.Ok(todo));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<string>.Fail(ex.Message));
            }

        }
        /// <summary>
        /// Create a new todo
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(TodoCreateDTO), 201)]
        [ProducesResponseType(typeof(TodoDTO), 400)]
        public async Task<IActionResult> CreateTodo([FromBody] TodoCreateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<string>.Fail("Invalid todo"));
            }
            var createdTodo = await _todoService.CreateTaskAsync(dto);
            return Ok(ApiResponse<TodoDTO>.Ok(createdTodo, "Task created successfully", HttpStatusCode.Created));
        }
        /// <summary>
        /// delete todo by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(TodoDTO), 404)]
        [ProducesResponseType(typeof(TodoDTO), 400)]
        public async Task<IActionResult> DeleteTodo(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest(ApiResponse<string>.Fail("Invalid id"));
                }
                await _todoService.DeleteTaskAsync(id);
                return Ok(ApiResponse<string>.Ok("Task deleted successfully", "", HttpStatusCode.NoContent));
            }
            catch (Exception ex)
            {
                return NotFound(ApiResponse<string>.Fail(ex.Message));
            }
        }
        /// <summary>
        /// Update todo by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(TodoDTO), 404)]
        [ProducesResponseType(typeof(TodoDTO), 400)]
        public async Task<IActionResult> UpdateTodo(Guid id, [FromBody] TodoUpdateDTO dto)
        {
            try
            {
                if (id != dto.Id || dto == null)
                {
                    return BadRequest(ApiResponse<string>.Fail("Invalid id or todo"));
                }
                await _todoService.UpdateTaskAsync(id, dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<string>.Fail(ex.Message));
            }
        }
        /// <summary>
        /// Create a new todo in bulk
        /// </summary>
        /// <param name="dto">List TodoCreateDTO C</param>
        /// <returns></returns>
        [HttpPost("bulk-create")]
        [ProducesResponseType(typeof(List<TodoCreateDTO>), 201)]
        [ProducesResponseType(typeof(TodoDTO), 400)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateBulkTodo([FromBody] List<TodoCreateDTO> dto)
        {
            try
            {
                var createdTodos = await _todoService.BulkCreateTasksAsync(dto);
                return Ok(ApiResponse<List<TodoDTO>>.Ok(createdTodos.ToList(), "Tasks created successfully", HttpStatusCode.Created));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Delete todo in bulk
        /// </summary>
        /// <param name="dto">List id of Todo</param>
        /// <returns></returns>
        [HttpDelete("bulk-delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(TodoDTO), 404)]
        [ProducesResponseType(typeof(TodoDTO), 400)]
        public async Task<IActionResult> DeleteBulkTodo([FromBody] BulkDeleteTaskDTO dto)
        {
            try
            {
                await _todoService.BulkDeleteTasksAsync(dto);
                return Ok(ApiResponse<string>.Ok("Tasks deleted successfully", "", HttpStatusCode.NoContent));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<string>.Fail(ex.Message));
            }
        }
    }
}
