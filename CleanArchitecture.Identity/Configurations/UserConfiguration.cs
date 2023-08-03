using CleanArchitecture.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(new ApplicationUser
            {
                Id = "68136802-d9f1-479f-a1ba-e5b025707ab2",
                Email = "carlos@gmail.com",
                NormalizedEmail = "CARLOS@GMAIL.COM",
                Nombre = "VAxi",
                Apellidos = "Drez",
                UserName = "vaxidrez",
                NormalizedUserName = "VAXIDREZ",
                PasswordHash = hasher.HashPassword(null, "vaxiDrez2025$"),
                EmailConfirmed = true
            });
            builder.HasData(new ApplicationUser
            {
                Id = "228a144f-a974-4472-914f-29255de835d2",
                Email = "juan@gmail.com",
                NormalizedEmail = "JUAN@GMAIL.COM",
                Nombre = "JUAN",
                Apellidos = "Drez",
                UserName = "JUANDREZ",
                NormalizedUserName = "JUANDREZ",
                PasswordHash = hasher.HashPassword(null, "vaxiDrez2025$"),
                EmailConfirmed = true
            });
        }
    }
}
