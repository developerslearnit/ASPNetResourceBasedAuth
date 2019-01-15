using AuthApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AuthApp.Infrastructure
{
    public class FilterResourceAttribute: ActionFilterAttribute
    {
        AuthorizationService srv = new AuthorizationService(new Domain.AuthAppContext());
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var areaName = string.Empty;
            var routeData = filterContext.RouteData;
            areaName = routeData.DataTokens["area"] as string;
            var controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var actionName = filterContext.ActionDescriptor.ActionName;

            var requiredPermission = $"{controllerName}-{actionName}";
            if (!string.IsNullOrWhiteSpace(areaName))
            {
                requiredPermission += $"-{areaName}";
            }

            if (!srv.hasPermission(requiredPermission))
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary {
                    { "action", "Unauthorized" }, { "controller", "Error" }, { "area", "" } });
            }
            
            base.OnActionExecuting(filterContext);
        }
    }
}