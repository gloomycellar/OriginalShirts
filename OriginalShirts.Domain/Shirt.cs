using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OriginalShirts.Domain
{ 
    public class Product : EntityBase
    {
        public Product()
        {
            Size = new Size();
            Color = new Color();
            Tags = new List<Tag>();
        }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }

        [JsonProperty(PropertyName = "image")]
        public string Image { get; set; }

        [JsonProperty(PropertyName = "size")]
        public Size Size { get; set; }

        [JsonProperty(PropertyName = "color")]
        public Color Color { get; set; }

        [JsonProperty(PropertyName = "tags")]
        public ICollection<Tag> Tags { get; set; }
    }
}
