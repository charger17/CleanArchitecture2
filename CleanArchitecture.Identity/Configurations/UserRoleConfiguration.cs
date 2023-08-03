using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
             new IdentityUserRole<string>
             {
                 RoleId = "b0fe34c2-8dd2-4967-bf9e-171b260a5fe4",
                 UserId = "68136802-d9f1-479f-a1ba-e5b025707ab2"
             },
              new IdentityUserRole<string>
              {
                  RoleId = "c3534849-ff15-4de8-a12b-c0e64179ccf3",
                  UserId = "228a144f-a974-4472-914f-29255de835d2"
              }
            );
        }
    }
}
