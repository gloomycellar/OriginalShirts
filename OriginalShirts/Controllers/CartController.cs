using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using OriginalShirts.Dal;
using OriginalShirts.Domain;
using OriginalShirts.Domain.Account;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OriginalShirts.Controllers
{
    public class CartController : Controller
    {   
        private ApplicationUserManager userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                if (null == userManager)
                {
                    userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                }

                return userManager;
            }
            private set
            {
                userManager = value;
            }
        }

        // GET: Cart
        public ActionResult Index()
        {
            return View(Session["Cart"]);
        }


        public ActionResult AddtoCart(int id, int quontity)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                Shirt product = context.Set<Shirt>().Where(x => x.Id == id).First();
                Cart cart = (Cart)Session["Cart"];

                if (null == cart)
                {
                    ApplicationUser user = UserManager.FindById(User.Identity.GetUserId());
                    List<CartItem> items = new List<CartItem> { new CartItem(product,quontity) };

                    cart = new Cart(user, items);
                    Session.Add("Cart", cart);

                    context.Set<Cart>().Add(cart);
                }
                else
                {
                    cart.AddToCart(product, quontity);
                    TryUpdateModel(cart);
                }

                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}