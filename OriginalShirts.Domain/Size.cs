using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace OriginalShirts.Domain
{
    public class Size : EntityBase
    {
        public Size() { }

        public Size(string name)
        {
            Name = name;
        }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}