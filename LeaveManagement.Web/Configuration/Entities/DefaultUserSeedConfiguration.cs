using LeaveManagement.Web.Data.Employee;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagement.Web.Configuration.Entities
{
    internal class DefaultUserSeedConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            var hasher = new PasswordHasher<Employee>();

            builder.HasData(
                new Employee
                {
                    Id = "5910682d-2b54-4edc-935d-44df2f0b2290",
                    FirstName = "Suraj",
                    LastName = "Porje",
                    Email = "porjesuraj@gmail.com",
                    NormalizedEmail = "PORJESURAJ@GMAIL.COM",
                    UserName = "porjesuraj@gmail.com",
                    NormalizedUserName = "PORJESURAJ@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "Porje_12345"),
                    EmailConfirmed = true
                },
                  new Employee
                  {
                      Id = "5910682d-2b54-4edc-232d-44df1f0b1190",
                      FirstName = "System",
                      LastName = "User",
                      Email = "user@gmail.com",
                      NormalizedEmail = "USER@GMAIL.COM",
                      UserName = "user@gmail.com",
                      NormalizedUserName = "USER@GMAIL.COM",
                      PasswordHash = hasher.HashPassword(null, "User_12345"),
                      EmailConfirmed = true
                  }

                );

        }
    }
}