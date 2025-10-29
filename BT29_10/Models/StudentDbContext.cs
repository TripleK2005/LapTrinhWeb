using Microsoft.EntityFrameworkCore;
namespace BT29_10.Models

{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
        }
        public DbSet<Studen> Studens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Studen>().HasData(
                new Studen { Id = 1, Name = "Alice", Age = 20 },
                new Studen { Id = 2, Name = "Bob", Age = 22 },
                new Studen { Id = 3, Name = "Charlie", Age = 21 }
            );
        }
    }
}
