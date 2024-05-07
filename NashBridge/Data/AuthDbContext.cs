using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NashBridge.Data
{
    public class AuthDbContext: IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var userRoleId = "eb9f7882-ca5d-4f92-8653-4a253ffac805";
            var adminRoleId = "4a30232b-c555-487a-8ba1-cf0779f511e3";
            // create roles

            var roles = new List<IdentityRole>
            {
               new IdentityRole()
               {
                   Id = userRoleId,
                   Name = "User",
                   NormalizedName = "User".ToUpper(),
                   ConcurrencyStamp = userRoleId
               },
               new IdentityRole()
               {
                   Id = adminRoleId,
                   Name = "Admin",
                   NormalizedName = "Admin".ToUpper(),
                   ConcurrencyStamp = adminRoleId
               }
            };

            //Seed the roles
            builder.Entity<IdentityRole>().HasData(roles);

            // Create an admin user
            var adminUserId = "600ff101-5765-44f1-8e62-e2e24eb1cfe5";
            var admin = new IdentityUser()
            {
                Id = adminUserId,
                UserName = "admin@nashBridge.com",
                Email = "admin@nashBridge.com",
                NormalizedEmail = "admin@nashBridge.com".ToUpper(),
                NormalizedUserName = "admin@nashBridge.com".ToUpper()

            };

            admin.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(admin, "Admin@123");

            builder.Entity<IdentityUser>().HasData(admin);

            //Give roles to admin user

            var adminRoles = new List<IdentityUserRole<string>>()
            {
                new()
                {
                    UserId = adminUserId,
                    RoleId = userRoleId
                },
                new()
                {
                    UserId = adminUserId,
                    RoleId = adminRoleId
                }
            };
            builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);
        }
    }
}
