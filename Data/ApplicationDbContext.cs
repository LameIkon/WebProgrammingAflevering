using Microsoft.EntityFrameworkCore;
using WebProgrammingAflevering.Models.Entities;

namespace WebProgrammingAflevering.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
    }

}
