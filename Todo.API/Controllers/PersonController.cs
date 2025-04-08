using System.Net;
using Application.DTOs;
using Application.DTOs.Person;
using Application.Interfaces;
using Domain.Enum;
using Domain.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Todo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        /// <summary>
        /// Get all persons
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(PersonDTO),200)]
        [ProducesResponseType(typeof(PersonDTO),404)]
        public async Task<IActionResult> GetAllPersonsAsync()
        {
            try
            {
                var persons = await _personService.GetAllPersonsAsync();
                return Ok(ApiResponse<IEnumerable<PersonDTO>>.Ok(persons,"get all persons",HttpStatusCode.OK));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<string>.Fail(ex.Message,HttpStatusCode.NotFound));
            }
        }
        [HttpPost]
        [ProducesResponseType(typeof(PersonDTO), 200)]  
        [ProducesResponseType(typeof(PersonDTO), 400)]
        public async Task<IActionResult> CreatePersonAsync([FromBody] PersonCreateDTO person)
        {
            try
            {
                if(person == null)
                {
                    return BadRequest(ApiResponse<string>.Fail("Person is null", HttpStatusCode.BadRequest));
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ApiResponse<string>.Fail("Invalid model", HttpStatusCode.BadRequest));
                }
                var personCreate = await _personService.AddPersonAsync(person);
                return Ok(ApiResponse<PersonDTO>.Ok(personCreate, "Person created successfully", HttpStatusCode.OK));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<string>.Fail(ex.Message, HttpStatusCode.BadRequest));
            }
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(PersonDTO), 400)]
        public async Task<IActionResult> UpdatePersonAsync([FromBody] PersonUpdateDTO person)
        {
            try
            {
                if (person == null)
                {
                    return BadRequest(ApiResponse<string>.Fail("Person is null", HttpStatusCode.BadRequest));
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ApiResponse<string>.Fail("Invalid model", HttpStatusCode.BadRequest));
                }
                await _personService.UpdatePersonAsync(person);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<string>.Fail(ex.Message, HttpStatusCode.BadRequest));
            }
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(PersonDTO), 404)]
        public async Task<IActionResult> DeletePersonAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest(ApiResponse<string>.Fail("Id is null", HttpStatusCode.BadRequest));
                }
                await _personService.DeletePersonAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<string>.Fail(ex.Message, HttpStatusCode.NotFound));
            }
        }
        [HttpGet("filter")]
        [ProducesResponseType(typeof(PersonDTO), 200)]
        [ProducesResponseType(typeof(PersonDTO), 404)]
        [ProducesResponseType(typeof(PersonDTO), 400)]
        public async Task<IActionResult> GetPersonsByFilterAsync([FromQuery] PersonFilter filter)
        {
            try
            {
                if (filter == null)
                {
                    return BadRequest(ApiResponse<string>.Fail("Filter is null", HttpStatusCode.BadRequest));
                }
                var persons = await _personService.GetPersonsByFilterAsync(filter);
                return Ok(ApiResponse<IEnumerable<PersonDTO>>.Ok(persons, "get persons by filter", HttpStatusCode.OK));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<string>.Fail(ex.Message, HttpStatusCode.NotFound));
            }
        }
    
    }
}