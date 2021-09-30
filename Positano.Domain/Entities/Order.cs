using Positano.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Positano.Domain.Entities
{
    public class Order
    {
        public Order()
        {
            TypeOrders = new HashSet<TypeOrder>();
            Tastes = new HashSet<Taste>();
        }
        public int OrderId { get; set; }
        public int UserId { get; set;}
        public virtual  User User { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<TypeOrder> TypeOrders { get; set; }
        public virtual ICollection<Taste> Tastes { get; set; }
        public Status Status { get; set; }
    }
}
