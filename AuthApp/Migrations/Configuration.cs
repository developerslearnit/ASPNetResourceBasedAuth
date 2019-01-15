namespace AuthApp.Migrations
{
    using AuthApp.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AuthApp.Domain.AuthAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Domain.AuthAppContext context)
        {
            context.Users.AddOrUpdate(x => x.ApplicationUserId,
                new ApplicationUser() { ApplicationUserId = 1, Username = "john", Password = "password123" },
                new ApplicationUser() { ApplicationUserId = 2, Username = "jane", Password = "password" });

            context.Roles.AddOrUpdate(x => x.RoleId,
                new Role() { RoleId = 1, Name = "admin" },
                new Role() { RoleId = 2, Name = "user" });

            context.UserRoles.AddOrUpdate(x => x.UserRoleId,
                new UserRole() { UserRoleId = 1, RoleId = 1, UserId = 1 },
                new UserRole() { UserRoleId = 2, RoleId = 2, UserId = 1 },
                new UserRole() { UserRoleId = 3, RoleId = 2, UserId = 2 });

            context.Resources.AddOrUpdate(x => x.ResourceId,
                new Resource() { ResourceId = 1, Action = "index", Area = "admin", Controller = "users" },
                new Resource() { ResourceId = 2, Action = "profile", Area = "admin", Controller = "users" },
                new Resource() { ResourceId = 3, Action = "index", Area = "", Controller = "pages" },
                new Resource() { ResourceId = 4, Action = "portfolio", Area = "", Controller = "pages" });

            context.RoleResources.AddOrUpdate(x => x.RoleResourceId,
                new RoleResource() { RoleResourceId = 1, ResourceId = 1, RoleId = 1 },
                new RoleResource() { RoleResourceId = 2, ResourceId = 2, RoleId = 1 },
                new RoleResource() { RoleResourceId = 3, ResourceId = 3, RoleId = 2 },
                new RoleResource() { RoleResourceId = 4, ResourceId = 4, RoleId = 2 }

                );

        }
    }
}
