using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnderFoot.DataAccess.Mappings;

namespace UnderFoot.DataAccess
{
    public class UnderFootDBContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public UnderFootDBContext(DbContextOptions<UnderFootDBContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<CartDetail> CartDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductMap());
            builder.ApplyConfiguration(new CategoryMap());
            builder.ApplyConfiguration(new CartDetailsMap());
            base.OnModelCreating(builder);
        }
    }
}
