using Microsoft.EntityFrameworkCore;
using todolist_api.Context;
using todolist_api.Models;
using System.Net.Sockets;
using System.Net;

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
            return await _context.Tasks.ToListAsync();
        }

        public async Task<TodoTask> GetTask(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task CreateTask(TodoTask task)
        {
            task.CreatedAt = DateTime.Now;
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTask(TodoTask task)
        {
            task.UpdateAt = DateTime.Now;
            _context.Entry(task).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTask(TodoTask task)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }
    }
}
