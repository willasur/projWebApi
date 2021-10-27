using Microsoft.EntityFrameworkCore;

namespace MoviesDB.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<movieDetails> TodoItems { get; set; }
    }
}