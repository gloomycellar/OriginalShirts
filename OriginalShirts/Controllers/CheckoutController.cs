using Microsoft.AspNet.Identity;
using OriginalShirts.Dal;
using OriginalShirts.Domain;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OriginalShirts.Controllers
{
    public class CheckoutController : Controller
    {
        public ActionResult Index()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                Guid userId = Guid.Parse(User.Identity.GetUserId());

                Cart cart = context
                                .Set<Cart>()
                                .Include("CartItems.Product")
                                .Where(x => x.UserId == userId)
                                .First();

                UserDetail userDetails = context
                                .Set<UserDetail>()
                                .Where(x => x.UserId == userId)
                                .FirstOrDefault() ?? new UserDetail();

                List<string> npCities = context
                               .Set<NpDepartment>()
                               .GroupBy(x => x.CityRu)
                               .Select(g => g.Key)
                               .ToList();

                dynamic result = new ExpandoObject();
                result.Cart = cart;
                result.UserDetails = userDetails;
                result.NpCities = npCities;

                return View(result);
            }
        }

        public ActionResult GetNpCities()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                List<string> npCities = context
                               .Set<NpDepartment>()
                               .GroupBy(x => x.CityRu)
                               .Select(g => g.Key)
                               .ToList();

                return Json(npCities, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetNpDepartments(string name)
        {

            using (ApplicationContext context = new ApplicationContext())
            {
                List<string> addresses = context
                               .Set<NpDepartment>()
                               .Where(x => x.CityRu == name)
                               .Select(d => d.AddressRu)
                               .ToList();

                return Json(addresses, JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<ActionResult> SubmitOrder()
        {
            var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
            var message = new MailMessage();
            message.To.Add(new MailAddress("timursayfullin@gmail.com"));  // replace with valid value 
            message.From = new MailAddress("timursayfullin@gmail.com");  // replace with valid value
            message.Subject = "Your email subject";
            message.Body = string.Format(body, "Tim", "timursayfullin@gmail.com", "test message");
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = new NetworkCredential("", "");
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);

                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
    }
}