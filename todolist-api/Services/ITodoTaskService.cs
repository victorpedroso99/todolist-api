using todolist_api.Models;

namespace todolist_api.Services
{
    public interface ITodoTaskService
    {
        Task<IEnumerable<TodoTask>> GetAllTasks();
        Task<TodoTask> GetTask(int id);
        Task CreateTask(TodoTask task);
        Task UpdateTask(TodoTask task);
        Task DeleteTask(TodoTask task);
    }
}
