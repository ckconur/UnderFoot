using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnderFoot.DataAccess.Mappings;

namespace UnderFoot.DataAccess
{
    public class UnderFootDBContext : IdentityDbContext<AppUser>
    {
        public UnderFootDBContext(DbContextOptions<UnderFootDBContext> options) : base(options)
        {
        }

        public DbSet<Products> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductMap());
            base.OnModelCreating(builder);
        }
    }
}
