using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MovieApp.Data
{
    public class AuthContext : IdentityDbContext
    {
        public AuthContext(DbContextOptions options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Seed all roles
            var superAdminId = "eb5222f4-18c9-4a34-b77d-377dab96a36a";
            var adminId = "1a3974d0-8fbd-4923-ae63-daae66dd63c9";
            var userId = "dcbc94ee-cde1-4baf-bfa0-ea799fb97106";
            builder.Entity<IdentityRole>().HasData(
            new IdentityRole { Id = superAdminId, ConcurrencyStamp = superAdminId, Name = "SuperAdmin", NormalizedName = "SUPERADMIN" },
            new IdentityRole { Id = adminId, ConcurrencyStamp = adminId, Name = "Admin", NormalizedName = "ADMIN" },
            new IdentityRole { Id = userId, ConcurrencyStamp = userId, Name = "User", NormalizedName = "USER" });

            // Seed SuperAdmin User
            var superAdminUserId = "a6457b92-5b61-44fb-8d1a-6b248b29dbfb";
            var superAdmin = new IdentityUser()
            {
                Id = superAdminUserId,
                Email = "superadmin@movie.com",
                UserName = "superadmin@movie.com",
                NormalizedEmail = "superadmin@movie.com".ToUpperInvariant(),
                NormalizedUserName = "superadmin@movie.com".ToUpperInvariant(),
                PasswordHash = "AQAAAAIAAYagAAAAEIxj31utL0uMnVrL5Kq36j9UtbnyvdlcEJvVcPHU4btUN22W8agvAZ+OZhY5TSHbfA==",
                SecurityStamp = "static-security-stamp",
                ConcurrencyStamp = "static-concurrency-stamp"
            };

            //superAdmin.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(superAdmin, "SuperAdmin@12");

            builder.Entity<IdentityUser>().HasData(superAdmin);

            //Add all roles to SuperAdmin
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = superAdminUserId, RoleId = superAdminId },
                new IdentityUserRole<string> { UserId = superAdminUserId, RoleId = adminId },
                new IdentityUserRole<string> { UserId = superAdminUserId, RoleId = userId }
            );
        }
    }
}
