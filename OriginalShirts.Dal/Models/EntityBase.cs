using System.ComponentModel.DataAnnotations;

namespace OriginalShirts.Dal.Models
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}
