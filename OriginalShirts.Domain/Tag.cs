using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OriginalShirts.Domain
{
    public class Tag : EntityBase
    {
        public Tag()
        {
            Shirts = new HashSet<Shirt>();
            Groups = new HashSet<TagGroup>();
        }

        public Tag(string name, HashSet<TagGroup> groups) : this()
        {
            Name = name;
            Groups = groups;
        }

        public string Name { get; set; }

        public ICollection<Shirt> Shirts { get; set; }

        public ICollection<TagGroup> Groups { get; set; }
    }
}
