using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriginalShirts.Dal.Models
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

        public string Name { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }
}
