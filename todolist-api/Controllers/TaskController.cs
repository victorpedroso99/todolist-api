using Microsoft.AspNetCore.Mvc;
using todolist_api.Models;
using todolist_api.Services;

namespace todolist_api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITodoTaskService _todoTaskService;

        public TaskController(ITodoTaskService todoTaskService)
        {
            _todoTaskService = todoTaskService;
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
    }
}
