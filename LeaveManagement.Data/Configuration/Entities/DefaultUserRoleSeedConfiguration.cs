using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagement.Web.Configuration.Entities
{
    internal class DefaultUserRoleSeedConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "2d6cf024-2e3e-4249-9a8e-2796bcead059",
                    UserId = "5910682d-2b54-4edc-935d-44df2f0b2290"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "2d3cf024-2e3e-2323-9a8e-2796bcead059",
                    UserId = "5910682d-2b54-4edc-232d-44df1f0b1190"
                }
                );
        }
    }
}