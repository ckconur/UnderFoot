using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnderFoot.DataAccess.Mappings
{
    public class CartDetailsMap : IEntityTypeConfiguration<CartDetail>
    {
        public void Configure(EntityTypeBuilder<CartDetail> builder)
        {
            // Pk and Fk

            builder.HasKey(x => new { x.ProductID, x.UserID });
            builder.HasOne<AppUser>(x => x.User).WithMany(x => x.CartDetails).HasForeignKey(x => x.UserID).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<Product>(x => x.Product).WithMany(x => x.CartDetails).HasForeignKey(x => x.ProductID).OnDelete(DeleteBehavior.Cascade);

            // Other Columns

            builder.Property(x => x.Price).HasColumnType("smallmoney");

            builder.Property(x => x.Total).HasColumnType("money");

            // Table

            builder.ToTable("CartDetails");

            // Column Name

            builder.Property(x => x.UserID).HasColumnName("UserID");

            builder.Property(x => x.ProductID).HasColumnName("ProductID");

            builder.Property(x => x.Amount).HasColumnName("Amount");

            builder.Property(x => x.Price).HasColumnName("Price");

            builder.Property(x => x.Total).HasColumnName("TotalPrice");
        }
    }
}
