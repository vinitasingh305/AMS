using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.Model.Mappings
{
    public class AssetMap : IEntityTypeConfiguration<Asset>
    {
        public void Configure(EntityTypeBuilder<Asset> builder)
        {
            // Primary Key
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id).ValueGeneratedOnAdd();

            // Properties

            builder.Property(t => t.AssetName).HasMaxLength(50).IsRequired(true);

            builder.Property(t => t.ItemBrand).HasMaxLength(500);

            builder.Property(t => t.ItemDesc).HasMaxLength(50);

            builder.Property(t => t.TypeOfItem).HasMaxLength(50);

            builder.Property(t => t.Quantity).IsRequired(true);
            builder.Property(t => t.ManufacturingDate).IsRequired(false);
            builder.Property(t => t.CreatedBy).HasMaxLength(50);

            builder.Property(t => t.UpdatedBy).HasMaxLength(50);
            builder.Property(t => t.BUName).HasMaxLength(50);

            // Table & Column Mappings

            builder.ToTable("Asset");
            builder.Property(t => t.Id).HasColumnName("Id");
            builder.Property(t => t.AssetName).HasColumnName("AssetName");
            builder.Property(t => t.ItemBrand).HasColumnName("ItemBrand");
            builder.Property(t => t.ItemDesc).HasColumnName("ItemDesc");
            builder.Property(t => t.ManufacturingDate).HasColumnName("ManufacturingDate");
            builder.Property(t => t.TypeOfItem).HasColumnName("TypeOfItem");
            builder.Property(t => t.Quantity).HasColumnName("Quantity");
            builder.Property(t => t.BUName).HasColumnName("BUName");
            builder.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            builder.Property(t => t.CreatedDate).HasColumnName("CreatedDate").HasColumnType("datetime");
            builder.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            builder.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate").HasColumnType("datetime");

          }
    }
}
