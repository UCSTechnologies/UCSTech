using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using GFS.Domain;
using GFS.Models;
using GFS.Business_Logic;

namespace GFS.Controllers
{
    public class AccountController : Controller
    {
        GFSContext db = new GFSContext();
        GFSTracking d = new GFSTracking();
        IAuthenticationManager Authentication
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }

        // GET: Account
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            TempData["nullList"] = (from e in db.Users.ToList()
                                    select e).ToList();
            ViewBag.ReturnUrl = returnUrl;
            return View(new LoginViewModel());
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var data = new Data();
            var users = data.users();

            if (users.Any(p => p.CustEmail == model.UserName && p.password == model.Password))
            {
                User t = db.Users.ToList().Find(p => p.CustEmail == model.UserName && p.password == model.Password);
                var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, t.userid), }, DefaultAuthenticationTypes.ApplicationCookie);

                Authentication.SignIn(new AuthenticationProperties
                {
                    IsPersistent = model.RememberMe
                }, identity);
                
                d.login(t.userid);
                return RedirectToAction("Home", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            d.logout(User.Identity.Name);
            Authentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}