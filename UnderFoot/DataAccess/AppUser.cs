using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnderFoot.DataAccess
{
    public class AppUser:IdentityUser
    {
        public AppUser()
        {
            CartDetails = new HashSet<CartDetail>();
        }

        public ICollection<CartDetail> CartDetails { get; set; }
    }
}
