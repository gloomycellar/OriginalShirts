using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriginalShirts.Domain
{
    public class CartItem : EntityBase
    {
        public CartItem()
        {
        }

        public CartItem(Product product, int quontity)
        {
            Product = product;
            Quontity = quontity;
        }

        [JsonProperty(PropertyName = "quontity")]
        public int Quontity { get; set; }

        [JsonProperty(PropertyName = "product")]
        public Product Product { get; set; }
    }
}
