namespace Mockassesment6.Models
{
    using Microsoft.EntityFrameworkCore;

    public class EmployeeDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
            : base(options)
        {
        }
    }
}