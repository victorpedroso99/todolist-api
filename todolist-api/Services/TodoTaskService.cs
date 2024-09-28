using Microsoft.EntityFrameworkCore;
using todolist_api.Context;
using todolist_api.Models;

namespace todolist_api.Services
{
    public class TodoTaskService : ITodoTaskService
    {
        private readonly AppDbContext _context;

        public TodoTaskService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TodoTask>> GetAllTasks()
        {
            try
            {
                return await _context.Tasks.ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<TodoTask> GetTask(int id)
        {
            try
            {
                var task = await _context.Tasks.FindAsync(id);

                return task;
            }
            catch
            {
                throw;
            }
        }

        public async Task CreateTask(TodoTask task)
        {
            try
            {
                _context.Tasks.Add(task);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task UpdateTask(TodoTask task)
        {
            try
            {
                _context.Entry(task).State = EntityState.Modified;

                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteTask(TodoTask task)
        {
            try
            {
                _context.Tasks.Remove(task);

                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
