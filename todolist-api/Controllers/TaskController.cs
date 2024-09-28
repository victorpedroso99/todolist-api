using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using todolist_api.Dto;
using todolist_api.Models;
using todolist_api.Services;

namespace todolist_api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITodoTaskService _todoTaskService;
        private readonly IMapper _mapper;

        public TaskController(ITodoTaskService todoTaskService, IMapper mapper)
        {
            _todoTaskService = todoTaskService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<TodoTask>>> GetTasks()
        {
            try
            {
                var tasks = await _todoTaskService.GetAllTasks();

                return Ok(tasks);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetTask")]
        public async Task<ActionResult<TodoTask>> GetTask(int id)
        {
            try
            {
                var task = await _todoTaskService.GetTask(id);

                if (task == null) 
                {
                    return NotFound("Task not found");
                }

                return Ok(task);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(CreateTodoTaskDto createDto)
        {
            var task = _mapper.Map<TodoTask>(createDto);
            await _todoTaskService.CreateTask(task);
            return CreatedAtRoute(nameof(GetTask), new { id = task.Id }, task);
        }

        [HttpPut]
        [Route("{id:int}", Name = "UpdateTask")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] UpdateTodoTaskDto updateDto)
        {
            if (updateDto == null || updateDto.Status == null)
            {
                return BadRequest("Status is required.");
            }

            try
            {
                var task = await _todoTaskService.GetTask(id);
                if (task == null)
                {
                    return NotFound("Task not found.");
                }

                _mapper.Map(updateDto, task);

                await _todoTaskService.UpdateTask(task);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [Route("{id:int}", Name = "UpdateTaskStatus")]
        public async Task<IActionResult> UpdateTaskStatus(int id, [FromBody] UpdateTodoTaskStatusDto updateDto)
        {
            if (updateDto == null)
            {
                return BadRequest("Status is required.");
            }

            try
            {
                var task = await _todoTaskService.GetTask(id);
                if (task == null)
                {
                    return NotFound("Task not found.");
                }

                task.Status = updateDto.Status;
                await _todoTaskService.UpdateTask(task);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id:int}", Name = "DeleteTask")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            try
            {
                var task = await _todoTaskService.GetTask(id);
                if (task == null)
                {
                    return NotFound("Task not found.");
                }

                await _todoTaskService.DeleteTask(task);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
