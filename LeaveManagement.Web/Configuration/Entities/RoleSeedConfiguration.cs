using LeaveManagement.Web.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagement.Web.Configuration.Entities
{
    public class RoleSeedConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "2d6cf024-2e3e-4249-9a8e-2796bcead059",
                    Name = StringConstants.ADMIN_ROLE,
                    NormalizedName = StringConstants.ADMIN_ROLE.ToUpper()
                },
                 new IdentityRole
                 {
                     Id = "2d3cf024-2e3e-2323-9a8e-2796bcead059",
                     Name = StringConstants.USER_ROLE,
                     NormalizedName = StringConstants.USER_ROLE.ToUpper()
                 });


        }
    }
}

//2d6cf044-2e6e-4249-9a8e-2796bcead059