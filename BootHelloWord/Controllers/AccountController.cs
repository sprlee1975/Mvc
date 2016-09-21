using BootHelloWord.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootHelloWord.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginViewModel login)
        {
            return RedirectToAction("Login", "Home", login);
            //return RedirectToRoute(new { controller = "Home", action = "Login", model= login });
            //return View();
        }
    }
}