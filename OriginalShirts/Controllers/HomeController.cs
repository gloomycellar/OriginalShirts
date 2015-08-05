using OriginalShirts.Common;
using OriginalShirts.Dal;
using OriginalShirts.Dal.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web.Mvc;

namespace OriginalShirts.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string tagName, int page = 1)
        {
            const int pageSize = 12;

            using (ApplicationContext context = new ApplicationContext())
            {
                //IQueryable<Shirt> query = context.Set<Shirt>().Select(x => x);

                //if (null != tag)
                //{
                //    query = query.Where(x => x.Tags.Contains(tag));
                //}

                //var result = query.Select(shirt => new
                //{
                //    Id = shirt.Id,
                //    Color = shirt.Color,
                //    Image = shirt.Image,
                //    Name = shirt.Name,
                //    Price = shirt.Price,
                //    Size = shirt.Size,
                //    Tags = shirt.Tags.ToList()
                //}).ToList();

                //return View(result);

                IQueryable<Shirt> query = context.Set<Shirt>().Select(x => x);

                if (!string.IsNullOrWhiteSpace(tagName))
                {
                    query = query.Where(x => x.Tags.Any(t => t.Name == tagName));
                }

                Shirt[] shirts = query.OrderBy(x => x.Id).Skip((page - 1) * pageSize).Take(pageSize).ToArray();


                dynamic result = new ExpandoObject();
                result.Shirts = shirts;
                result.PageCount = Math.Ceiling((double)query.Count() / pageSize);
                result.CurrentPage = page;

                return View(result);
            }
        }

        public ActionResult Details(int id)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                Shirt shirt = context.Set<Shirt>().FirstOrDefault();
                return View(shirt);
            }
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