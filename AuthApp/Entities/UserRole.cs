using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthApp.Entities
{
    public class UserRole
    {
        public int UserRoleId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}