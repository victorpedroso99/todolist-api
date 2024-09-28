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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IAsyncEnumerable<TodoTask>>> GetTasks()
        {
            try
            {
                var tasks = await _todoTaskService.GetAllTasks();

                return Ok(tasks);
            }
            catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
