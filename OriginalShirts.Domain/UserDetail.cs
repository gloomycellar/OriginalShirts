using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriginalShirts.Domain
{
    public class UserDetail : EntityBase
    {
        public UserDetail()
        {
            Phone = new List<string>();
            Addresses = new List<string>();
        }

        public Guid UserId { get; set; }

        public string Name { get; set; }

        public ICollection<string> Phone { get; set; }

        public ICollection<string> Addresses { get; set; }
    }
}
