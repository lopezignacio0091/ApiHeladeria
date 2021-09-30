using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Positano.Domain.Enum
{
    public enum Status
    {
        [Display(Name = "Entregado")]
        Delivered,
        [Display(Name = "Pendiente")]
        Pending,
       
    }
}
