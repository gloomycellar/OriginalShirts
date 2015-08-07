using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OriginalShirts.Domain
{ 
    public class Shirt : EntityBase
    {
        public Shirt()
        {
            Size = new Size();
            Color = new Color();
            Tags = new List<Tag>();
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public Size Size { get; set; }
        public Color Color { get; set; }
        
        public ICollection<Tag> Tags { get; set; }
    }
}
