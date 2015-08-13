using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OriginalShirts.Domain
{
    public class Tag : EntityBase
    {
        public Tag()
        {
            Products = new HashSet<Product>();
            Groups = new HashSet<TagGroup>();
        }

        public Tag(string name, HashSet<TagGroup> groups) : this()
        {
            Name = name;
            Groups = groups;
        }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "products")]
        public ICollection<Product> Products { get; set; }

        [JsonProperty(PropertyName = "groups")]
        public ICollection<TagGroup> Groups { get; set; }
    }
}
