using System;
using System.Collections.Generic;
using System.Text;

namespace Positano.Domain.Entities
{
    public class Purchase
    {
        public int PurchaseId { get; set; }

        public DateTime Date { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int Total { get; set; }
    }
}
