using System.ComponentModel.DataAnnotations.Schema;

namespace OriginalShirts.Domain
{ 
    public class Color : EntityBase
    {
        public Color() { }

        public Color(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}