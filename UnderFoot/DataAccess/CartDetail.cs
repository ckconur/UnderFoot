using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnderFoot.DataAccess
{
    public class CartDetail
    {
        public int Amount { get; set; }

        public decimal Price { get; set; }

        public decimal Total { get; set; }

        public string UserID { get; set; }
        public AppUser User { get; set; }

        public int ProductID { get; set; }
        public Product Product { get; set; }
    }
}
