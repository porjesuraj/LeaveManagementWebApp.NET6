using LeaveManagement.Web.Configuration.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LeaveManagement.Web.Models;

namespace LeaveManagement.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<Employee.Employee>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleSeedConfiguration());
            builder.ApplyConfiguration(new DefaultUserSeedConfiguration());
            builder.ApplyConfiguration(new DefaultUserRoleSeedConfiguration());
        }

        public DbSet<LeaveType>? LeaveTypes { get; set; }

        public DbSet<LeaveAllocation>? LeaveAllocations { get; set; }





    }
}