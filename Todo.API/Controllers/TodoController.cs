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
        [HttpGet]
        public async Task<IActionResult> GetAllTodos()
        {
            var todos = await _todoService.GetAllTodoAsync();
            if (todos == null || todos.Count() == 0)
            {
                return NotFound(ApiResponse<string>.Fail("No Task found", HttpStatusCode.NotFound));
            }
            return Ok(ApiResponse<List<TodoDTO>>.Ok(todos.ToList()));
        }
        [HttpGet("{id}")]
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
        [HttpPost]
        public async Task<IActionResult> CreateTodo([FromBody] TodoCreateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<string>.Fail("Invalid todo"));
            }

            var createdTodo = await _todoService.CreateTaskAsync(dto);
            return CreatedAtAction(nameof(GetTodoById), new { id = createdTodo.Id }, ApiResponse<TodoDTO>.Ok(createdTodo));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(Guid id)
        {
            try
            {
                await _todoService.DeleteTaskAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<string>.Fail(ex.Message));
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodo(Guid id, [FromBody] TodoUpdateDTO dto)
        {
            try
            {
                if(id != dto.Id || dto == null)
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
        [HttpPost("bulk-create")]
        public async Task<IActionResult> CreateBulkTodo([FromBody] List<TodoCreateDTO> dto)
        {
            try
            {
                var createdTodos = await _todoService.BulkCreateTasksAsync(dto);
                return CreatedAtAction(nameof(GetAllTodos), createdTodos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("bulk-delete")]
        public async Task<IActionResult> DeleteBulkTodo([FromBody] BulkDeleteTaskDTO dto)
        {
            try
            {
                await _todoService.BulkDeleteTasksAsync(dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
