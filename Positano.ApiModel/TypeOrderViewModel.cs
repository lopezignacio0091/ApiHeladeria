using Newtonsoft.Json;
using Positano.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Positano.ApiModel
{
    public class TypeOrderViewModel
    {
        [JsonProperty("id")]
        public int TypeOrderId { get; set; }

        [JsonProperty("nombre")]
        public string Name { get; set; }

        [JsonProperty("valor")]
        public int  Cost { get; set; }

        [JsonProperty("seleccionado")]
        public Boolean Select;
        public TypeOrderViewModel(TypeOrder typeOrder)
        {
            TypeOrderId = typeOrder.TypeOrderId;
            Name = typeOrder.Name;
            Cost = typeOrder.Cost;
            Select = false;
        }
    }
}
