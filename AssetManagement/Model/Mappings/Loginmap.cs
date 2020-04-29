using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.Model.Mappings
{
    public class Loginmap : IEntityTypeConfiguration<Login>
    {
        public void Configure(EntityTypeBuilder<Login> builder)
        {
            // Primary Key
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id).ValueGeneratedOnAdd();

            // Properties

            builder.Property(t => t.Firstname).HasMaxLength(50);

            builder.Property(t => t.Lastname).HasMaxLength(50);

            builder.Property(t => t.Contactnumber).HasMaxLength(50);
            builder.Property(t => t.Email).HasMaxLength(50).IsRequired(true);

            builder.Property(t => t.PasswordHash).HasMaxLength(50).IsRequired(true);

            builder.Property(t => t.PasswordSalt).HasMaxLength(50).IsRequired(true);


            // Table & Column Mappings

            builder.ToTable("Login");
            builder.Property(t => t.Id).HasColumnName("Id");
            builder.Property(t => t.Firstname).HasColumnName("Firstname");
            builder.Property(t => t.Lastname).HasColumnName("Lastname");
            builder.Property(t => t.Email).HasColumnName("Email");
            builder.Property(t => t.Contactnumber).HasColumnName("Contactnumber");
            builder.Property(t => t.PasswordHash).HasColumnName("PasswordHash");
            builder.Property(t => t.PasswordSalt).HasColumnName("PasswordSalt");
        }
    }
}
