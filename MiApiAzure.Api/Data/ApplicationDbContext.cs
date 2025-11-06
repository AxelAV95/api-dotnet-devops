using Microsoft.EntityFrameworkCore;

namespace MiApiAzure.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Aquí agregarías tus DbSet, por ejemplo:
        // public DbSet<TodoItem> TodoItems { get; set; }
    }
}