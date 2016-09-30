﻿using BootHelloWord.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootHelloWord.Controllers
{
    [Authorize()]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Text()
        {
            return View();
        }

        public ActionResult Table()
        {
            return View();
        }

        public ActionResult Form()
        {
            return View();
        }

        public ActionResult BootstrapCss()
        {
            return View();
        }

        public ActionResult Menu()
        {
            return View();
        }

       
    }
}