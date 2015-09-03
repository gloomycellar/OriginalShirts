using Newtonsoft.Json;
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

        public Cart(Guid userId) : base()
        {
            UserId = userId;
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

        public Order GetOrder() {
            Order order = new Order();

            order.UserId = UserId;
            order.Status = OrderStatus.Default;
            foreach (CartItem item in CartItems)
            {
                order.OrderItems.Add(new OrderItem(item.Product,item.Quontity));
            }

            return order;
        }
    }
}
