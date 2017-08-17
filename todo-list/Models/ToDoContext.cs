using Microsoft.EntityFrameworkCore;


namespace TodoApi.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=todo-store.db");
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
