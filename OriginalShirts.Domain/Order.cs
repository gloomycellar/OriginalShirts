using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriginalShirts.Domain
{
    public class Order : EntityBase
    {
        public Order()
        {
            OrderItems = new List<OrderItem>();
        }

        public Order(Guid userId, ICollection<OrderItem> items, NpDepartment npDepartment, OrderStatus status)
        {
            UserId = userId;
            OrderItems = items;
            NpDepartment = npDepartment;
            Status = status;
        }

        [JsonProperty(PropertyName = "userId")]
        public Guid UserId { get; set; }

        [JsonProperty(PropertyName = "orderItems")]
        public ICollection<OrderItem> OrderItems { get; }

        public NpDepartment NpDepartment { get; set; }

        public OrderStatus Status { get; set; }
    }
}
