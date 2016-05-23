namespace MakerPlatform.Migrations
{
    using MakerPlatform.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MakerPlatform.Models.MakerDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MakerPlatform.Models.MakerDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            #region Add Admin Role
            string adminRoleId = string.Empty;
            string admin = "Admin";
            var adminRole = context.Roles.FirstOrDefault(r => r.Name == admin);
            if (adminRole == null)
            {
                var adminModel = new IdentityRole
                {
                    Name = admin
                };
                context.Roles.Add(adminModel);
                adminRoleId = adminModel.Id;
            }
            else
            {
                adminRoleId = adminRole.Id;
            }

            #endregion
            #region Init Admin User
            string userName = "Admin";
            string password = "admin123";
            var user = context.Users.FirstOrDefault(u => u.UserName == userName);
            if (user == null)
            {
                // Hash password
                var passwordHash = new PasswordHasher().HashPassword(password);

                var userModel = new ApplicationUser
                {
                    UserName = userName,
                    PasswordHash = passwordHash
                };

                context.Users.Add(userModel);
                //Add User to Admin
                var relation = new IdentityUserRole() { UserId = userModel.Id, RoleId = adminRoleId };
                userModel.Roles.Add(relation);
            }
            #endregion
            context.SaveChanges();
        }
    }
}
