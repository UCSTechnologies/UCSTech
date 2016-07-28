using GFS.Domain;
using GFS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GFS.Controllers
{
    public class NavbarController : Controller
    {
        private GFSContext db = new GFSContext();
        // GET: Navbar
        public ActionResult Navbar(string controller, string action)
        {
            var data = new Data();
            if (!String.IsNullOrEmpty(User.Identity.Name))
            {
                TempData["UserNameee"] = (db.Users.ToList().Find(p => p.userid == User.Identity.Name).firstname + " " + db.Users.ToList().Find(p => p.userid == User.Identity.Name).lastname).ToString();
            }
            var navbar = data.itemsPerUser(controller, action, User.Identity.Name);

            return PartialView("_Navbar", navbar);
        }
    }
}