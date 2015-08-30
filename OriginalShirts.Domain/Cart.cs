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
    }
}
