using Microsoft.EntityFrameworkCore;
using todolist_api.Models;

namespace todolist_api.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TodoTask> Tasks { get; set; }
    }
}
