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
        public ActionResult Index(string tag = null, int page = 1)
        {
            const int pageSize = 12;

            using (ApplicationContext context = new ApplicationContext())
            {
                IQueryable<Shirt> query = context.Set<Shirt>().Select(x => x);

                if (!string.IsNullOrWhiteSpace(tag))
                {
                    query = query.Where(x => x.Tags.Any(t => t.Name == tag));
                }

                Shirt[] shirts = query.OrderBy(x => x.Id).Skip((page - 1) * pageSize).Take(pageSize).ToArray();


                dynamic result = new ExpandoObject();
                result.Shirts = shirts;
                result.PageCount = Math.Ceiling((double)query.Count() / pageSize);
                result.CurrentPage = page;
                result.TagName = tag;

                result.SportwearTags = context.Set<Tag>().Where(x => x.Groups.Any(y => y.Name == "Sportwear")).ToList();
                result.MensTags = context.Set<Tag>().Where(x => x.Groups.Any(y => y.Name == "Mens")).ToList();
                result.WomensTags = context.Set<Tag>().Where(x => x.Groups.Any(y => y.Name == "Womens")).ToList();

                result.TagsWithoutGroups = context.Set<Tag>().Where(x => x.Groups.Count == 0).ToList();

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