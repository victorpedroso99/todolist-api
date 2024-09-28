using Microsoft.EntityFrameworkCore;
using todolist_api.Models;

namespace todolist_api.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TodoTask> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TodoTask>(entity =>
            {
                entity.HasData(
                    new TodoTask
                    {
                        Id = 1,
                        Description = "Grab some Pizza",
                        Status = 1,
                        CreatedAt = DateTime.Now
                    });
            });
        }
    }
}
