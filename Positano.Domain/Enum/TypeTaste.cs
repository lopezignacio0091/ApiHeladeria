using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Positano.Domain.Enum
{
    public enum TypeTaste
    {
        [Display(Name = "Crema")]
        Cream,
        [Display(Name = "Fruta")]
        Fruit,

    }
}
