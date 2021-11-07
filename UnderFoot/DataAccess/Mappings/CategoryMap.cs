using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnderFoot.DataAccess.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.CategoryID);
            builder.HasMany<Product>(x => x.Products).WithOne(x => x.Category).HasForeignKey(x => x.CategoryID).OnDelete(DeleteBehavior.Cascade);
            builder.Property(x => x.CategoryName).HasMaxLength(30).HasColumnType("nvarchar").IsRequired();
            builder.Property(x => x.Description).HasMaxLength(100).HasColumnType("nvarchar");

            // Table
            builder.ToTable("Categories");

            // Columns
            builder.Property(x => x.CategoryID).HasColumnName("CategoryID");
            builder.Property(x => x.CategoryName).HasColumnName("CategoryName");
            builder.Property(x => x.Description).HasColumnName("Description");
        }
    }
}
