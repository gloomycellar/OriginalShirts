using System.ComponentModel.DataAnnotations.Schema;

namespace OriginalShirts.Dal.Models
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