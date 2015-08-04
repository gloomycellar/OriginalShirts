using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OriginalShirts.Dal.Models
{
    public class Tag : EntityBase
    {
        public Tag() {
            Shirts = new HashSet<Shirt>();
        }

        public Tag(string name) : this()
        {
            Name = name;
        }

        public string Name { get; set; }

        public ICollection<Shirt> Shirts { get; set; }
    }
}
