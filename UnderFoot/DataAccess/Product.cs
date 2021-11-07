using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnderFoot.DataAccess
{
    public class Product
    {
        public Product()
        {
            CartDetails = new HashSet<CartDetail>();
        }
        public int ProductID { get; set; }

        public int CategoryID { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public string PictureLink { get; set; }

        public Category Category { get; set; }

        public ICollection<CartDetail> CartDetails { get; set; }

    }
}
