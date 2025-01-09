using Medical.Resource;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medical.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                 new ApplicationUser
                 {
                     Id = Constants.ADMIN_GUID,
                     Email = Constants.ADMIN_EMAIL,
                     NormalizedEmail = Constants.ADMIN_EMAIL.ToUpper(),
                     FirstName = Constants.ADMIN_NAME,
                     LastName = Constants.SYSTEM_PREFIX_NAME,
                     UserName = Constants.ADMIN_EMAIL,
                     NormalizedUserName = Constants.ADMIN_EMAIL.ToUpper(),
                     PasswordHash = hasher.HashPassword(null!, Constants.ADMIN_PASSWORD),
                     EmailConfirmed = true
                 }
            );
        }
    }
}
