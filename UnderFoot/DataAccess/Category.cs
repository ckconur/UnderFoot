using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnderFoot.DataAccess
{
    public class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}
