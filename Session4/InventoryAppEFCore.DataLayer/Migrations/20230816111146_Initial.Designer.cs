﻿// <auto-generated />
using System;
using InventoryAppEFCore.DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InventoryAppEFCore.DataLayer.Migrations
{
    [DbContext(typeof(InventoryAppEfCoreContext))]
    [Migration("20230816111146_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("InventoryAppEFCore.DataLayer.EfClasses.Client", b =>
                {
                    b.Property<int>("ClientKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientKey"), 1L, 1);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ClientKey");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("InventoryAppEFCore.DataLayer.EfClasses.LineItem", b =>
                {
                    b.Property<int>("LineItemKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LineItemKey"), 1L, 1);

                    b.Property<short>("NumOfProducts")
                        .HasColumnType("smallint");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("LineItemKey");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("LineItem");
                });

            modelBuilder.Entity("InventoryAppEFCore.DataLayer.EfClasses.Order", b =>
                {
                    b.Property<int>("OrderKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderKey"), 1L, 1);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOrderedUtc")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("OrderKey");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("InventoryAppEFCore.DataLayer.EfClasses.PriceOffer", b =>
                {
                    b.Property<int>("PriceOfferId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PriceOfferId"), 1L, 1);

                    b.Property<decimal>("NewPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("PromotinalText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PriceOfferId");

                    b.ToTable("PriceOffers");
                });

            modelBuilder.Entity("InventoryAppEFCore.DataLayer.EfClasses.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("InventoryAppEFCore.DataLayer.EfClasses.Review", b =>
                {
                    b.Property<int>("ReviewFluentKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewFluentKey"), 1L, 1);

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumStars")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("VoterName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReviewFluentKey");

                    b.HasIndex("ProductId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("InventoryAppEFCore.DataLayer.EfClasses.Supplier", b =>
                {
                    b.Property<int>("SupplierFluentKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplierFluentKey"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("SupplierFluentKey");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("InventoryAppEFCore.DataLayer.EfClasses.Tag", b =>
                {
                    b.Property<string>("TagFluentKey")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("TagFluentKey");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("ProductSupplier", b =>
                {
                    b.Property<int>("ProductsLinkProductId")
                        .HasColumnType("int");

                    b.Property<int>("SuppliersLinkSupplierFluentKey")
                        .HasColumnType("int");

                    b.HasKey("ProductsLinkProductId", "SuppliersLinkSupplierFluentKey");

                    b.HasIndex("SuppliersLinkSupplierFluentKey");

                    b.ToTable("ProductSupplier");
                });

            modelBuilder.Entity("ProductTag", b =>
                {
                    b.Property<int>("ProductsProductId")
                        .HasColumnType("int");

                    b.Property<string>("TagsTagFluentKey")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ProductsProductId", "TagsTagFluentKey");

                    b.HasIndex("TagsTagFluentKey");

                    b.ToTable("ProductTag");
                });

            modelBuilder.Entity("InventoryAppEFCore.DataLayer.EfClasses.LineItem", b =>
                {
                    b.HasOne("InventoryAppEFCore.DataLayer.EfClasses.Order", null)
                        .WithMany("LineItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InventoryAppEFCore.DataLayer.EfClasses.Product", "SelectedProduct")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SelectedProduct");
                });

            modelBuilder.Entity("InventoryAppEFCore.DataLayer.EfClasses.Review", b =>
                {
                    b.HasOne("InventoryAppEFCore.DataLayer.EfClasses.Product", null)
                        .WithMany("Reviews")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProductSupplier", b =>
                {
                    b.HasOne("InventoryAppEFCore.DataLayer.EfClasses.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsLinkProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InventoryAppEFCore.DataLayer.EfClasses.Supplier", null)
                        .WithMany()
                        .HasForeignKey("SuppliersLinkSupplierFluentKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProductTag", b =>
                {
                    b.HasOne("InventoryAppEFCore.DataLayer.EfClasses.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InventoryAppEFCore.DataLayer.EfClasses.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsTagFluentKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InventoryAppEFCore.DataLayer.EfClasses.Order", b =>
                {
                    b.Navigation("LineItems");
                });

            modelBuilder.Entity("InventoryAppEFCore.DataLayer.EfClasses.Product", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
