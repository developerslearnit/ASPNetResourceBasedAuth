using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthApp.Controllers
{
    public class errorController : Controller
    {
        // GET: error
        public ActionResult Unauthorized()
        {
            return View();
        }
    }
}