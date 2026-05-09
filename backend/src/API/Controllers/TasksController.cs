using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Api.API.DTOs;
using TodoList.Api.Domain.Commands;
using TodoList.Api.Domain.Interfaces;

namespace TodoList.Api.API.Controllers
{
    /// <summary>
    /// TasksController.
    /// 
    /// MVC Pattern: The Controller handles incoming HTTP requests and translates 
    /// them into actions on the Model (Domain).
    /// 
    /// Object Calisthenics:
    /// - Max 2 instance variables: _repository and _handlers.
    /// - No 'else' keyword.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _repository;
        private readonly TaskCommandHandlerBundle _handlers;

        public TasksController(ITaskRepository repository, TaskCommandHandlerBundle handlers)
        {
            _repository = repository;
            _handlers = handlers;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskDataTransferObject>>> GetAll([FromQuery] string? sortBy = null)
        {
            var tasks = await _repository.GetAllAsync(sortBy);
            
            // Map domain entities to DTOs
            return Ok(tasks.Select(t => t.ToDto()));
        }

        [HttpPost]
        public async Task<ActionResult<TaskDataTransferObject>> Create(RegisterTaskCommand command)
        {
            var newTask = await _handlers.RegisterHandler.HandleAsync(command);
            
            var dto = newTask.ToDto();
            
            return CreatedAtAction(nameof(GetAll), new { id = dto.Id }, dto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new RemoveTaskCommand(id);
            
            await _handlers.RemoveHandler.HandleAsync(command);
            
            return NoContent();
        }
    }
}
