using OriginalShirts.Dal;
using OriginalShirts.Dal.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OriginalShirts.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        public ActionResult Index()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                var shirts = context.Set<Shirt>().Select(x => new
                {
                    Id = x.Id,
                    Name = x.Name,
                    Size = x.Size.Name,
                    Color = x.Color.Name,
                    Price = x.Price,
                    Image = x.Image,
                    Tags = x.Tags.ToList()
                }).ToList().Select(i =>
                {
                    dynamic temp = new ExpandoObject();

                    temp.Id = i.Id;
                    temp.Name = i.Name;
                    temp.Size = i.Size;
                    temp.Color = i.Color;
                    temp.Price = i.Price;
                    temp.Tags = i.Tags;
                    temp.Image = i.Image;

                    return temp;
                });

                return View(shirts);
            }
        }
    }
}