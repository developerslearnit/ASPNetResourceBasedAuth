using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthApp.Entities
{
    public class RoleResource
    {
        public int RoleResourceId { get; set; }
        public int RoleId { get; set; }
        public int ResourceId { get; set; }
        public virtual Resource Resource { get; set; }
        public virtual Role Role { get; set; }
    }
}