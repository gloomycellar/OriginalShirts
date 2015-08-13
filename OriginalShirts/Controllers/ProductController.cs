using OriginalShirts.Dal;
using OriginalShirts.Domain;
using System;
using System.Dynamic;
using System.Linq;
using System.Web.Mvc;

namespace OriginalShirts.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index(string tag = null, int page = 1)
        {
            const int pageSize = 9;

            using (ApplicationContext context = new ApplicationContext())
            {
                IQueryable<Product> query = context.Set<Product>().Select(x => x);

                if (!string.IsNullOrWhiteSpace(tag))
                {
                    query = query.Where(x => x.Tags.Any(t => t.Name == tag));
                }

                Product[] shirts = query.OrderBy(x => x.Id).Skip((page - 1) * pageSize).Take(pageSize).ToArray();


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
                Product shirt = context.Set<Product>().Where(x => x.Id == id).FirstOrDefault();
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