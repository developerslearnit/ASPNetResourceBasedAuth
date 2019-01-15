using AuthApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AuthApp.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult login()
        {
            return View();
        }

        
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            HttpContext.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("login", "auth", new { area = "" });
        }

        public JsonResult signIn(AuthModel model)
        {
            if (string.IsNullOrWhiteSpace(model.username.Trim()) || String.IsNullOrWhiteSpace(model.password.Trim()))
            {
                return Json(new { error = true, message = "Wrong username or password" }, JsonRequestBehavior.AllowGet);
            }

            try
            {
                if (Membership.ValidateUser(model.username, model.password))
                {
                    FormsAuthentication.SetAuthCookie(model.username, false);
                    return Json(new { error = false, message =string.Empty }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { error = true, message = "Wrong username or password" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                return Json(new { error = true, message = "Wrong username or password" }, JsonRequestBehavior.AllowGet);
            }
            


        }
    }
}