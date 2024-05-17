using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Zajęcia1_Todos.Models;

namespace Zajęcia1_Todos.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Zajęcia1_Todos.Models.Todo> Todo { get; set; } = default!;
        public DbSet<Zajęcia1_Todos.Models.TodoGroup> TodoGroup { get; set; } = default!;
    }
}
