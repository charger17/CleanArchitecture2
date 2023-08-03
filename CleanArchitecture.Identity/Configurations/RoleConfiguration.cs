using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "b0fe34c2-8dd2-4967-bf9e-171b260a5fe4",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                },
                new IdentityRole
                {
                    Id = "c3534849-ff15-4de8-a12b-c0e64179ccf3",
                    Name = "Operator",
                    NormalizedName = "OPERATOR"
                }
            );
        }
    }
}
