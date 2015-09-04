using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace OriginalShirts.Domain
{ 
    public class Color : EntityBase
    {
        public Color() { }

        public Color(string name, string styleColor)
        {
            Name = name;
            StyleColor = styleColor;
        }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "styleColor")]
        public string StyleColor { get; set; }
    }
}