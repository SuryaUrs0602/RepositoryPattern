using Microsoft.EntityFrameworkCore;

namespace RepositoryPatternImplementation.Models
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions contextoptions) : base(contextoptions)
        {
            
        }

        public DbSet<Student> Students { get; set; }
    }
}
