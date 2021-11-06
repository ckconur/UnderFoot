using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnderFoot.DataAccess.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {

            builder.HasKey(x => x.ProductID);
            builder.Property(x => x.ProductName).HasMaxLength(60).IsRequired();
            builder.Property(x => x.Price).IsRequired().HasColumnType("smallmoney");
            builder.Property(x => x.PictureLink).IsRequired();

            // Table
            builder.ToTable("Products");

            // Columns
            builder.Property(x => x.ProductID).HasColumnName("ProductID");
            builder.Property(x => x.ProductName).HasColumnName("ProductName");
            builder.Property(x => x.Price).HasColumnName("Price");
            builder.Property(x => x.PictureLink).HasColumnName("PictureLink");
        }
    }
}
