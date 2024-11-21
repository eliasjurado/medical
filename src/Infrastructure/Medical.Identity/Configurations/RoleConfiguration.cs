using Medical.Resource;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medical.Identity.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = Constants.USER_ROLE_GUID,
                    Name = Constants.USER_ROLE_NAME,
                    NormalizedName = Constants.USER_ROLE_NAME.ToUpper()
                },
                new IdentityRole
                {
                    Id = Constants.ADMIN_ROLE_GUID,
                    Name = Constants.ADMIN_ROLE_NAME,
                    NormalizedName = Constants.ADMIN_ROLE_NAME.ToUpper()
                }
            );
        }
    }
}
