using Newtonsoft.Json;
using Positano.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Positano.ApiModel
{
    public class TasteViewModel
    {
        [JsonProperty("id")]
        public int TasteId { get; set; }

        [JsonProperty("nombre")]
        public string Name { get; set; }

        [JsonProperty("cantidad")]
        public int  Quantity { get; set; }

        public TasteViewModel(Taste teste)
        {
            TasteId = teste.TasteId;
            Name = teste.Name;
            Quantity = teste.Quantity;
        }
    }
}
