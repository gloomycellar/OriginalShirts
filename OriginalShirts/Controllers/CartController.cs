using Microsoft.AspNet.Identity;
using OriginalShirts.Dal;
using OriginalShirts.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace OriginalShirts.Controllers
{
    public class CartController : BaseController
    {
        public ActionResult Index()
        {
            return View(UserCart);
        }

        public ActionResult GetCartCount()
        {
            int result = 0;
            foreach (CartItem item in UserCart.CartItems)
            {
                result += item.Quontity;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RemoveCartItem(int id)
        {
            if (UserId.HasValue)
            {
                UpdateDbCart((cart, context) =>
                {
                    CartItem item = cart.CartItems.Where(x => x.Product.Id == id).First();
                    context.Set<CartItem>().Remove(item);
                });
            }
            else
            {
                CartItem item = UserCart.CartItems.Where(x => x.Product.Id == id).First();
                UserCart.CartItems.Remove(item);
            }

            return Json(UserCart, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SetQuontity(int id, int quontity)
        {
            if (UserId.HasValue)
            {
                UpdateDbCart((cart, context) =>
                {
                    CartItem item = cart.CartItems.Where(x => x.Product.Id == id).First();
                    if (0 >= quontity)
                        context.Set<CartItem>().Remove(item);
                    else
                        item.Quontity = quontity;
                });
            }
            else
            {
                CartItem item = UserCart.CartItems.Where(x => x.Product.Id == id).First();
                if (0 >= quontity)
                    UserCart.CartItems.Remove(item);
                else
                    item.Quontity = quontity;
            }

            return Json(UserCart, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddToCart(int id, int quontity)
        {
            if (UserId.HasValue)
            {
                UpdateDbCart((cart, context) =>
                {
                    Product product = context.Set<Product>().Where(x => x.Id == id).First();
                    CartItem item = cart.CartItems.Where(x => x.Product.Id == id).FirstOrDefault();
                    if (null == item)
                        cart.CartItems.Add(new CartItem(product, quontity));
                    else
                        item.Quontity += quontity;
                });
            }
            else
            {
                Product product;
                using (ApplicationContext context = new ApplicationContext())
                {
                    product = context.Set<Product>().Where(x => x.Id == id).First();
                }

                CartItem item = UserCart.CartItems.Where(x => x.Product.Id == id).FirstOrDefault();
                if (null == item)
                    UserCart.CartItems.Add(new CartItem(product, quontity));
                else
                    item.Quontity += quontity;
            }

            return Json(UserCart, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult RemoveFromCart(int id, int quontity)
        {
            if (UserId.HasValue)
            {
                UpdateDbCart((cart, context) =>
                {
                    CartItem item = cart.CartItems.Where(x => x.Product.Id == id).FirstOrDefault();
                    if (null != item)
                    {
                        if (0 >= (item.Quontity - quontity))
                            context.Set<CartItem>().Remove(item);
                        else
                            item.Quontity -= quontity;
                    }
                });
            }
            else
            {
                CartItem item = UserCart.CartItems.Where(x => x.Product.Id == id).FirstOrDefault();
                if (null != item)
                {
                    if (0 >= (item.Quontity - quontity))
                        UserCart.CartItems.Remove(item);
                    else
                        item.Quontity -= quontity;
                }

            }

            return Json(UserCart, JsonRequestBehavior.AllowGet);
        }
    }
}