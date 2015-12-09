﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using KUASCYCLAB.Models;
namespace KUASCYCLAB.Controllers
{
    public class HomeController : Controller
    {
        private KUASCYCEntities db = new KUASCYCEntities();

        public async Task<ActionResult> Index()
        {
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}