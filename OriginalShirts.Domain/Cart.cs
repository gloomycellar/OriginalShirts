﻿using Newtonsoft.Json;
using OriginalShirts.Domain.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriginalShirts.Domain
{
    public class Cart : EntityBase
    {
        public Cart()
        {
            CartItems = new List<CartItem>();
        }

        public Cart(Guid userId, ICollection<CartItem> items)
        {
            UserId = userId;
            CartItems = items;
        }

        [JsonProperty(PropertyName ="userId")]
        public Guid UserId { get; set; }

        [JsonProperty(PropertyName = "cartItems")]
        public ICollection<CartItem> CartItems { get; }

        //public void AddToCart(Shirt product, int quontity)
        //{
        //    if (null == product)
        //    {
        //        throw new ArgumentNullException("product");
        //    }

        //    if (0 >= quontity)
        //    {
        //        throw new ArgumentException("quontity should be more then 0");
        //    }

        //    CartItem item = CartItems.Where(x => x.Product.Id == product.Id).FirstOrDefault();
        //    if (null == item)
        //    {
        //        CartItems.Add(new CartItem(product, quontity));
        //    }
        //    else
        //    {
        //        item.Quontity += quontity;
        //    }
        //}

        //public void RemoveFromCart(Shirt product, int quontity)
        //{
        //    if (null == product)
        //    {
        //        throw new ArgumentNullException("product");
        //    }

        //    if (0 >= quontity)
        //    {
        //        throw new ArgumentException("quontity should be more then 0");
        //    }

        //    CartItem item = CartItems.Where(x => x.Product.Name == product.Name).FirstOrDefault();
        //    if (null == item)
        //    {
        //        return;
        //    }

        //    if ((item.Quontity - quontity) <= 0)
        //    {
        //        CartItems.Remove(item);
        //    }
        //    else
        //    {
        //        item.Quontity -= quontity;
        //    }
        //}
    }
}