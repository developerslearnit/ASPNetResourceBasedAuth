using AuthApp.Domain;
using AuthApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthApp.Models
{
    public class AuthorizationService
    {
        private AuthAppContext db;
        public AuthorizationService(AuthAppContext _db)
        {
            this.db = _db;
        }

        public bool hasPermission(string resource)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return false;
            }
            var userName = HttpContext.Current.User.Identity.Name;

            var loggedInUser = db.Users.Where(x => x.Username == userName).FirstOrDefault();

            List<RequiredPermissionVM> userpages = null;

            if (loggedInUser == null) return false;

            var userResource = (from rr in db.RoleResources
                                join ur in db.UserRoles on rr.RoleId equals ur.RoleId
                                where ur.UserId == loggedInUser.ApplicationUserId
                                select rr.ResourceId).ToList();

            if (userResource.Any())
            {


                userpages = (from m in db.Resources
                             where userResource.Contains(m.ResourceId)
                             select new RequiredPermissionVM
                             {
                                 controllerName = m.Controller,
                                 actionName = m.Action,
                                 areaName = m.Area
                             }).ToList();
            }

            if (!userpages.Any()) return false;

            return userpages.Any(x => x.requiredPermision.ToLower() == resource.ToLower());
        }
    }
}