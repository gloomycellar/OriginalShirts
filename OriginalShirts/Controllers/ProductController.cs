using OriginalShirts.Common;
using OriginalShirts.Dal;
using OriginalShirts.Domain;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace OriginalShirts.Controllers
{
    public class ProductController : BaseController
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

        public ActionResult GetImage()
        {
            string yellowSquarePath = Path.Combine(Server.MapPath("/Design/Patterns"), "23005_4978.png");
            string redSquarePath = Path.Combine(Server.MapPath("/Design/Patterns"), "Pic3.png");

            byte[] result = ImageHelper.GetTestImage(yellowSquarePath, redSquarePath);
            return this.File(result, "image/jpeg");
        }

        public ActionResult GetDetailsInitialData()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                List<Color> colors = context.Set<Color>().ToList();
                List<Size> sizes = context.Set<Size>().ToList();

                dynamic result = new ExpandoObject();

                result.Colors = colors;
                result.Sizes = sizes;

                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Details(int id)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                Product shirt = context.Set<Product>().Where(x => x.Id == id).FirstOrDefault();
                List<Color> colors = context.Set<Color>().ToList();
                List<Size> sizes = context.Set<Size>().ToList();

                dynamic result = new ExpandoObject();

                result.Shirt = shirt;
                result.Colors = colors;
                result.Sizes = sizes;

                return View(result);
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