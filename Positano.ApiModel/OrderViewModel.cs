using Newtonsoft.Json;
using Positano.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Positano.ApiModel
{
    public class OrderViewModel
    {
        [JsonProperty("id")]
        public int OrderId { get; set; }
        [JsonProperty("usuarioId")]
        public int UserId { get; set; }
        [JsonProperty("usuario")]
        public  UserViewModel User { get; set; }
        [JsonProperty("tipoPedido")]
        public  ICollection<TypeOrderViewModel> TypeOrders { get; set; }
        [JsonProperty("gustos")]
        public  ICollection<TasteViewModel> Tastes { get; set; }

        [JsonProperty("fecha")]
        public DateTime Date;

        [JsonProperty("estado")]
        public string Status { get; set;}

        [JsonProperty("total")]
        public int Total { get; set; }
        public OrderViewModel(Order order)
        {
            OrderId= order.OrderId;
            Tastes = order.Tastes.Select(t => new TasteViewModel(t)).ToList();
            TypeOrders = order.TypeOrders.Select(o => new TypeOrderViewModel(o)).ToList();
            UserId = order.UserId;
            User = new UserViewModel(order.User);
            Date = order.Date;
            Status = order.Status.ToString();
            Total = order.TypeOrders.Sum(x=>x.Cost);
        }
    }
}
