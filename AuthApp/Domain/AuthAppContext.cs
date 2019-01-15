using AuthApp.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AuthApp.Domain
{
    public class AuthAppContext: DbContext
    {
        public AuthAppContext() : base("name=AppConnection")
        {
            
        }

        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleResource> RoleResources { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}