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
            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }
    }
}
