using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.Model.Mappings
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            // Primary Key
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id).ValueGeneratedOnAdd();

            // Properties

            builder.Property(t => t.Customername).HasMaxLength(50).IsRequired(true);

            builder.Property(t => t.Email).HasMaxLength(50).IsRequired(true);

            builder.Property(t => t.Contactnumber).HasMaxLength(50).IsRequired(true);


            builder.Property(t => t.CreatedBy).HasMaxLength(50);

            builder.Property(t => t.UpdatedBy).HasMaxLength(50);


            // Table & Column Mappings

            builder.ToTable("Customer");
            builder.Property(t => t.Id).HasColumnName("Id");
            builder.Property(t => t.Customername).HasColumnName("Customername");
            builder.Property(t => t.Contactnumber).HasColumnName("ItemBrand");
            builder.Property(t => t.Email).HasColumnName("ItemDesc");
            builder.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            builder.Property(t => t.CreatedDate).HasColumnName("CreatedDate").HasColumnType("datetime");
            builder.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            builder.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate").HasColumnType("datetime");
        }
    }
}
