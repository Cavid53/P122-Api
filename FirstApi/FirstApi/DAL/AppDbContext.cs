using FirstApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstApi.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasData(
                  new Employee { Id = 1, FullName = "Cavid Bashirov", Address = "Ehmedli",Age = 28},
                  new Employee { Id = 2, FullName = "Xeyal Binnetov", Address = "Suraxani", Age = 23 },
                  new Employee { Id = 3, FullName = "Orxan Ibrahimov", Address = "Sumqayit", Age = 22 }
                );
        }
    }
}
