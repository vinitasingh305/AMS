﻿// <auto-generated />
using System;
using AssetManagement.Model.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AssetManagement.Migrations
{
    [DbContext(typeof(AssetDBContext))]
    [Migration("20200422082713_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AssetManagement.Model.Asset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AssetName")
                        .IsRequired()
                        .HasColumnName("AssetName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("BUName")
                        .HasColumnName("BUName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("CreatedBy")
                        .HasColumnName("CreatedBy")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnName("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("ItemBrand")
                        .HasColumnName("ItemBrand")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("ItemDesc")
                        .HasColumnName("ItemDesc")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("ManufacturingDate")
                        .HasColumnName("ManufacturingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantity")
                        .HasColumnName("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("TypeOfItem")
                        .HasColumnName("TypeOfItem")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("UpdatedBy")
                        .HasColumnName("UpdatedBy")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnName("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Asset");
                });

            modelBuilder.Entity("AssetManagement.Model.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Contactnumber")
                        .IsRequired()
                        .HasColumnName("ItemBrand")
                        .HasColumnType("int")
                        .HasMaxLength(50);

                    b.Property<string>("CreatedBy")
                        .HasColumnName("CreatedBy")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnName("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Customername")
                        .IsRequired()
                        .HasColumnName("AssetName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("ItemDesc")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("UpdatedBy")
                        .HasColumnName("UpdatedBy")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnName("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("AssetManagement.Model.CustomerAsset", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnName("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("AssetId")
                        .HasColumnName("AssetId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnName("CreatedBy")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnName("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("IssueDate")
                        .HasColumnName("IssueDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("ReturnDate")
                        .IsRequired()
                        .HasColumnName("ReturnDate")
                        .HasColumnType("datetime");

                    b.Property<string>("UpdatedBy")
                        .HasColumnName("UpdatedBy")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnName("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("CustomerId", "AssetId");

                    b.HasIndex("AssetId");

                    b.ToTable("Customer_Asset");
                });

            modelBuilder.Entity("AssetManagement.Model.Login", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Contactnumber")
                        .HasColumnName("Contactnumber")
                        .HasColumnType("int")
                        .HasMaxLength(50);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("Email")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Firstname")
                        .HasColumnName("Firstname")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Lastname")
                        .HasColumnName("Lastname")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnName("PasswordHash")
                        .HasColumnType("varbinary(50)")
                        .HasMaxLength(50);

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnName("PasswordSalt")
                        .HasColumnType("varbinary(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Login");
                });

            modelBuilder.Entity("AssetManagement.Model.CustomerAsset", b =>
                {
                    b.HasOne("AssetManagement.Model.Asset", "Asset")
                        .WithMany("CustomerAssets")
                        .HasForeignKey("AssetId")
                        .HasConstraintName("FK_CustomerAsset_Asset")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AssetManagement.Model.Customer", "Customer")
                        .WithMany("CustomerAssets")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_CustomerAsset_Customer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
