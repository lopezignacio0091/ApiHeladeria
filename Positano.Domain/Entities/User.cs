using System;
using System.Collections.Generic;
using System.Text;

namespace Positano.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string LastName { get; set; }
        public string Direction { get; set; }
        public int  Phone { get; set;}

    }
}
