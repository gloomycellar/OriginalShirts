using System.Collections.Generic;

namespace OriginalShirts.Dal.Models
{
    public class Shirt : EntityBase
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public Size Size { get; set; }
        public Color Color { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
