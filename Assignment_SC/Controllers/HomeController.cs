using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment_SC.Models;
using System.Web.Security;

namespace Assignment_SC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login ob)
        {
            using(var context = new SC_demoEntities())
            {
                bool isValid = context.user_master.Any(x => x.Email_id == ob.EmailId && x.Password == ob.Password);
                if(isValid)
                {
                    FormsAuthentication.SetAuthCookie(ob.EmailId, false);
                    return RedirectToAction("Index", "user_master");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid EmailId and Password");
                    return View();
                }
            }
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(user_master model)
        {
            using (var context = new SC_demoEntities())
            {
                context.user_master.Add(model);
                context.SaveChanges();
            }
            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}