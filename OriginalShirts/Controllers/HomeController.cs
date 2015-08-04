using OriginalShirts.Dal;
using OriginalShirts.Dal.Models;
using System.Collections.Generic;
using System.Linq;
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

                var a1 = shirts[0].Tags.ToList();
                var a2 = shirts[1].Tags.ToList();
                var a3 = shirts[2].Tags.ToList();
                var a4 = shirts[3].Tags.ToList();
                var a5 = shirts[4].Tags.ToList();

                return View(shirts);
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