using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriginalShirts.Domain
{
    public class TagGroup : EntityBase
    {
        public TagGroup()
        {
            Tags = new HashSet<Tag>();
        }

        public TagGroup(string name)
        {
            Name = name;
        }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "tags")]
        public ICollection<Tag> Tags { get; set; }
    }
}
