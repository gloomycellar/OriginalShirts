using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriginalShirts.Domain
{
    public class CartItem : EntityBase
    {
        public CartItem(Shirt product, int quontity)
        {
            Product = product;
            Quontity = quontity;
        }

        public int Quontity { get; set; }

        public Shirt Product { get; set; }
    }
}
