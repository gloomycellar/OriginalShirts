using Microsoft.AspNet.Identity;
using OriginalShirts.Dal;
using OriginalShirts.Domain;
using System;
using System.Linq;
using System.Web.Mvc;

namespace OriginalShirts.Controllers
{
    public abstract class BaseController : Controller
    {
        public Guid? UserId
        {
            get
            {
                string id = User.Identity.GetUserId();
                return string.IsNullOrEmpty(id) ? null : (Guid?)Guid.Parse(User.Identity.GetUserId());
            }
        }

        public Cart UserCart
        {
            get
            {
                if (UserId.HasValue)
                {
                    using (ApplicationContext context = new ApplicationContext())
                    {
                        Cart cart = context
                                        .Set<Cart>()
                                        .Include("CartItems.Product")
                                        .Where(x => x.UserId == UserId.Value)
                                        .FirstOrDefault();

                        if (null == cart)
                        {
                            context.Set<Cart>().Add(new Cart(UserId.Value));
                            context.SaveChanges();

                            return context
                                        .Set<Cart>()
                                        .Include("CartItems.Product")
                                        .Where(x => x.UserId == UserId.Value)
                                        .First();
                        }

                        return cart;
                    }
                }

                if (null == Session["Cart"])
                {
                    Cart cart = new Cart();
                    Session["Cart"] = cart;
                    return cart;
                }

                return (Cart)Session["Cart"];
            }
        }
        
        protected void UpdateDbCart(Action<Cart, ApplicationContext> action, Guid? userId = null)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                Cart cart = context
                                .Set<Cart>()
                                .Include("CartItems.Product")
                                .Where(x => x.UserId == (userId ?? UserId))
                                .First();
                action(cart, context);
                context.SaveChanges();
            }
        }
    }
}