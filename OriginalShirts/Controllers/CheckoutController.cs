using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
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
    [Authorize]
    public class CheckoutController : BaseController
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
                List<NpDepartment> departments = context
                               .Set<NpDepartment>()
                               .Where(x => x.CityRu == name)
                               .ToList();

                return Json(departments, JsonRequestBehavior.AllowGet);
            }
        }

        public class SubmitViewModel
        {
            [JsonProperty(PropertyName = "npDepartmentId")]
            public int NpDepartmentId { get; set; }
            [JsonProperty(PropertyName = "name")]
            public string Name { get; set; }
            [JsonProperty(PropertyName = "phone")]
            public string Phone { get; set; }
        }

        public async Task<ActionResult> SubmitOrder(SubmitViewModel model)
        {
            NpDepartment dep = null;

            using (ApplicationContext context = new ApplicationContext())
            {
                dep = context.Set<NpDepartment>().Where(x => x.Id == model.NpDepartmentId).First();
            }

            var body = "<p>" +
                            "New Order Submitted" +
                       "</p>" +
                       "<table>" +
                            "<tbody>" +
                                "<tr>" +
                                    "<td>Name:</td><td>{0}</td>" +
                                "</tr>" +
                                "<tr>" +
                                    "<td>Phone:</td><td>{1}</td>" +
                                "</tr>" +
                                "<tr>" +
                                    "<td>City:</td><td>{2}</td>" +
                                "</tr>" +
                                "<tr>" +
                                    "<td>Nova Poshta Address:</td><td>{3}</td>" +
                                "</tr>" +
                            "</tbody>" +
                        "</table>";

            var message = new MailMessage();
            message.To.Add(new MailAddress("timursayfullin@gmail.com"));  // replace with valid value 
            message.From = new MailAddress("timursayfullin@gmail.com");  // replace with valid value
            message.Subject = "New Order Submitted";
            message.Body = string.Format(body, model.Name, model.Phone, dep.CityRu, dep.AddressRu);
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                //smtp.UseDefaultCredentials = true;
                //smtp.Credentials = new NetworkCredential("", "");
                //smtp.Host = "smtp.gmail.com";
                //smtp.Port = 587;
                //smtp.EnableSsl = true;
                //await smtp.SendMailAsync(message);

                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
    }
}