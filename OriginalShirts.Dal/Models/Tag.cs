using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriginalShirts.Dal.Models
{
    public class Tag : EntityBase
    {
        public Tag() { }

        public Tag(string name) : this()
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
