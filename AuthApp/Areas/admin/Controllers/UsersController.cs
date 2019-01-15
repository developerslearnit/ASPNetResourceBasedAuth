using AuthApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthApp.Areas.admin.Controllers
{
    [Authorize]
    [FilterResource]    
    public class UsersController : Controller
    {
        // GET: admin/Users
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult profile()
        {
            return View();
        }

    }
}