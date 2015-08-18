using Microsoft.AspNet.Identity;
using OriginalShirts.Dal;
using OriginalShirts.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;

namespace OriginalShirts.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                Guid userId = Guid.Parse(User.Identity.GetUserId());
                Cart cart = context
                                .Set<Cart>()
                                .Include("CartItems.Product")
                                .Where(x => x.UserId == userId)
                                .FirstOrDefault() ?? new Cart();

                return View(cart);
            }
        }

        public ActionResult GetCartCount()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                Guid userId = Guid.Parse(User.Identity.GetUserId());
                Cart cart = context
                                .Set<Cart>()
                                .Include("CartItems")
                                .Where(x => x.UserId == userId)
                                .FirstOrDefault() ?? new Cart();

                int result = 0;
                foreach (CartItem item in cart.CartItems)
                {
                    result += item.Quontity;
                }

                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Checkout()
        {
            return View();
        }

        public ActionResult RemoveCartItemt(int id)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                Guid userId = Guid.Parse(User.Identity.GetUserId());
                Cart cart = context
                                .Set<Cart>()
                                .Include("CartItems")
                                .Where(x => x.UserId == userId)
                                .FirstOrDefault();

                CartItem item = cart.CartItems.Where(x => x.Id == id).First();
                context.Set<CartItem>().Remove(item);

                context.SaveChanges();

                return Json(cart, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult AddtoCart(int id, int quontity)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                Product product = context.Set<Product>().Where(x => x.Id == id).First();
                Guid userId = Guid.Parse(User.Identity.GetUserId());
                Cart cart = context
                                .Set<Cart>()
                                .Include("CartItems.Product")
                                .Where(x => x.UserId == userId)
                                .FirstOrDefault();

                if (null == cart)
                {
                    List<CartItem> items = new List<CartItem> { new CartItem(product, quontity) };
                    cart = new Cart(userId, items);
                    context.Set<Cart>().Add(cart);
                }
                else
                {
                    CartItem item = cart.CartItems.Where(x => x.Product.Id == product.Id).FirstOrDefault();
                    if (null == item)
                    {
                        cart.CartItems.Add(new CartItem(product, quontity));
                    }
                    else
                    {
                        item.Quontity += quontity;
                    }
                }

                context.SaveChanges();

                return Json(cart, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult RemoveFromCart(int id, int quontity)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                Product product = context.Set<Product>().Where(x => x.Id == id).First();
                Guid userId = Guid.Parse(User.Identity.GetUserId());
                Cart cart = context
                                .Set<Cart>()
                                .Include("CartItems.Product")
                                .Where(x => x.UserId == userId)
                                .FirstOrDefault();

                CartItem item = cart.CartItems.Where(x => x.Product.Name == product.Name).FirstOrDefault();
                if (null != item)
                {
                    if (0 >= (item.Quontity - quontity))
                    {
                        context.Set<CartItem>().Remove(item);
                    }
                    else
                    {
                        item.Quontity -= quontity;
                    };
                }

                context.SaveChanges();

                return Json(cart, JsonRequestBehavior.AllowGet);
            }
        }
    }
}