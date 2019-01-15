using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthApp.Models
{
    public class RequiredPermissionVM
    {
        public string controllerName { get; set; }
        public string actionName { get; set; }
        public string areaName { get; set; }
        public string requiredPermision { get { return $"{this.controllerName}-{this.actionName}-{this.areaName}"; } }
    }
}