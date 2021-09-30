using Newtonsoft.Json;
using Positano.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Positano.ApiModel
{
   public class PurchaseViewModel
    {
        [JsonProperty("id")]
        public int PurchaseId { get; set; }

        [JsonProperty("fecha")]
        public DateTime Date { get; set; }
        [JsonProperty("pedidoId")]
        public  int OrderId { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("gustos")]
        public IEnumerable<TasteViewModel> Tastes { get; set; }

        [JsonProperty("usuario")]
        public UserViewModel User { get; set; }


        [JsonProperty("tipoPedidos")]
        public IEnumerable<TypeOrderViewModel> TypeOrders { get; set; }

        public PurchaseViewModel(Purchase purchase)
        {
            PurchaseId = purchase.PurchaseId;
            OrderId = purchase.Order.OrderId;
            Total = purchase.Total;
            User = new UserViewModel(purchase.Order.User);
            Date = purchase.Date;
            TypeOrders = purchase.Order.TypeOrders.Select(t => new TypeOrderViewModel(t));
            Tastes = purchase.Order.Tastes.Select(t => new TasteViewModel(t));
            
        }

        public PurchaseViewModel(Purchase purchase,Boolean value)
        {
            PurchaseId = purchase.PurchaseId;
            OrderId = purchase.Order.OrderId;
            Total = purchase.Total;
            User = new UserViewModel(purchase.Order.User);
            Date = purchase.Date;
        }

    }
}
