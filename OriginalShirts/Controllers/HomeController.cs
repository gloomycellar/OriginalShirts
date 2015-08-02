﻿using OriginalShirts.Dal;
using OriginalShirts.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OriginalShirts.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(Tag tag)
        {
            List<Shirt> shirts = new List<Shirt>();

            using (ApplicationContext context = new ApplicationContext())
            {
                if (null != tag)
                {
                    shirts = context.Set<Shirt>().ToList();
                }
                else
                {
                    shirts = context.Set<Shirt>().Where(x => x.Tags.Contains(tag)).ToList();
                }

            }

            return View(shirts);
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