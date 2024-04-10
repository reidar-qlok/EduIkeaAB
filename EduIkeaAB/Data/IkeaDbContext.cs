using EduIkeaAB.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EduIkeaAB.Data
{
    public class IkeaDbContext : IdentityDbContext
    {
        public IkeaDbContext(DbContextOptions<IkeaDbContext> options)
            : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmentList> DepartmentLists { get; set; }
    }
}
