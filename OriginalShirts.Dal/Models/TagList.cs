using System.Collections.Generic;

namespace OriginalShirts.Dal.Models
{
    public class TagList
    {

        public TagList()
        {
            Tags = new List<Tag>();
        }

        public TagList(ICollection<Tag> childTags)
        {
            Tags = new List<Tag>(childTags);
        }

        public List<Tag> Tags { get; set; }
    }
}
