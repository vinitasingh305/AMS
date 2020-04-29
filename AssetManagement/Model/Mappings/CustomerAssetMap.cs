using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.Model.Mappings
{
    public class CustomerAssetMap : IEntityTypeConfiguration<CustomerAsset>
    {
        public void Configure(EntityTypeBuilder<CustomerAsset> builder)
        {
            builder.HasKey(e => new { e.CustomerId, e.AssetId });
            // Properties
            builder.Property(t => t.CreatedBy).HasMaxLength(50);

            builder.Property(t => t.UpdatedBy).HasMaxLength(50);
            builder.Property(t => t.IssueDate).IsRequired(true);
            builder.Property(t => t.ReturnDate).IsRequired(true);

            // Table & Column Mappings
            builder.ToTable("Customer_Asset");
            builder.Property(t => t.CustomerId).HasColumnName("CustomerId");
            builder.Property(t => t.AssetId).HasColumnName("AssetId");
            builder.Property(t => t.IssueDate).HasColumnName("IssueDate").HasColumnType("datetime");
            builder.Property(t => t.ReturnDate).HasColumnName("ReturnDate").HasColumnType("datetime");
            builder.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            builder.Property(t => t.CreatedDate).HasColumnName("CreatedDate").HasColumnType("datetime");
            builder.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            builder.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate").HasColumnType("datetime");

            // Relationships
            builder.HasOne(t => t.Customer)
                .WithMany(t => t.CustomerAssets)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_CustomerAsset_Customer");

            builder.HasOne(t => t.Asset)
                .WithMany(t => t.CustomerAssets)
                .HasForeignKey(d => d.AssetId)
                .HasConstraintName("FK_CustomerAsset_Asset");
        }
    }
}
