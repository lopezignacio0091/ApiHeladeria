using Positano.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Positano.Domain.Entities
{
    public class Taste
    {
        public int TasteId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        public TypeTaste TypeTaste { get; set; }
    }
}
