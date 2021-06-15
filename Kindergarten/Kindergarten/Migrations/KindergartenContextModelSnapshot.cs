﻿// <auto-generated />
using System;
using Kindergarten.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Kindergarten.Migrations
{
    [DbContext(typeof(KindergartenContext))]
    partial class KindergartenContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Kindergarten.Models.Entities.Dish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DishNurseryNorm")
                        .HasColumnType("int");

                    b.Property<int>("DishYardNorm")
                        .HasColumnType("int");

                    b.Property<int?>("MenuFactId")
                        .HasColumnType("int");

                    b.Property<int>("MenuId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("MenuFactId");

                    b.HasIndex("MenuId");

                    b.ToTable("Dishes");
                });

            modelBuilder.Entity("Kindergarten.Models.Entities.DishFact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DishNurseryNorm")
                        .HasColumnType("int");

                    b.Property<int>("DishYardNorm")
                        .HasColumnType("int");

                    b.Property<int>("MenuFactId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("MenuFactId");

                    b.ToTable("DishFacts");
                });

            modelBuilder.Entity("Kindergarten.Models.Entities.DishItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DishId")
                        .HasColumnType("int");

                    b.Property<int>("NurseryNorm")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("YardNorm")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DishId");

                    b.HasIndex("ProductId");

                    b.ToTable("DishItems");
                });

            modelBuilder.Entity("Kindergarten.Models.Entities.DishItemFact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DishFactId")
                        .HasColumnType("int");

                    b.Property<int>("NurseryNorm")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("YardNorm")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DishFactId");

                    b.HasIndex("ProductId");

                    b.ToTable("DishItemFacts");
                });

            modelBuilder.Entity("Kindergarten.Models.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Patronymic")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Kindergarten.Models.Entities.Invoice", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.Property<string>("SupplierNumber")
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("ID");

                    b.HasIndex("SupplierId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("Kindergarten.Models.Entities.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("Kindergarten.Models.Entities.MenuFact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("MenuFacts");
                });

            modelBuilder.Entity("Kindergarten.Models.Entities.MovingProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<int?>("DishItemFactId")
                        .HasColumnType("int");

                    b.Property<int>("DishItemFatcId")
                        .HasColumnType("int");

                    b.Property<int>("NumberChildrenId")
                        .HasColumnType("int");

                    b.Property<int>("PartyId")
                        .HasColumnType("int");

                    b.Property<float>("Quantity")
                        .HasColumnType("real");

                    b.Property<int>("TypeMovingProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Date");

                    b.HasIndex("DishItemFactId");

                    b.HasIndex("NumberChildrenId");

                    b.HasIndex("PartyId");

                    b.HasIndex("TypeMovingProductId");

                    b.ToTable("MovingProducts");
                });

            modelBuilder.Entity("Kindergarten.Models.Entities.NumberChildren", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<int>("QuantityNursery")
                        .HasColumnType("int");

                    b.Property<int>("QuantityYard")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("NumberChildrens");
                });

            modelBuilder.Entity("Kindergarten.Models.Entities.Party", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateClosed")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<bool>("IsClosed")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<float>("Quantity")
                        .HasColumnType("real");

                    b.Property<int>("SuppleirId")
                        .HasColumnType("int");

                    b.Property<int?>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DateCreated");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("IsClosed");

                    b.HasIndex("ProductId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Parties");
                });

            modelBuilder.Entity("Kindergarten.Models.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Kindergarten.Models.Entities.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("Kindergarten.Models.Entities.TypeMovingProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TypeMovingProducts");
                });

            modelBuilder.Entity("Kindergarten.Models.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<byte>("LevelAccess")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasDefaultValue((byte)0);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Kindergarten.Models.Entities.Dish", b =>
                {
                    b.HasOne("Kindergarten.Models.Entities.MenuFact", null)
                        .WithMany("Dishes")
                        .HasForeignKey("MenuFactId");

                    b.HasOne("Kindergarten.Models.Entities.Menu", "Menu")
                        .WithMany("Dishes")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");
                });

            modelBuilder.Entity("Kindergarten.Models.Entities.DishFact", b =>
                {
                    b.HasOne("Kindergarten.Models.Entities.MenuFact", "MenuFact")
                        .WithMany()
                        .HasForeignKey("MenuFactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuFact");
                });

            modelBuilder.Entity("Kindergarten.Models.Entities.DishItem", b =>
                {
                    b.HasOne("Kindergarten.Models.Entities.Dish", "Dish")
                        .WithMany("DishItems")
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kindergarten.Models.Entities.Product", "Product")
                        .WithMany("DishItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dish");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Kindergarten.Models.Entities.DishItemFact", b =>
                {
                    b.HasOne("Kindergarten.Models.Entities.DishFact", "DishFact")
                        .WithMany("DishItemFacts")
                        .HasForeignKey("DishFactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kindergarten.Models.Entities.Product", "Product")
                        .WithMany("DishItemFacts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DishFact");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Kindergarten.Models.Entities.Invoice", b =>
                {
                    b.HasOne("Kindergarten.Models.Entities.Supplier", "Supplier")
                        .WithMany("Invoices")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Kindergarten.Models.Entities.MovingProduct", b =>
                {
                    b.HasOne("Kindergarten.Models.Entities.DishItemFact", "DishItemFact")
                        .WithMany("MovingProducts")
                        .HasForeignKey("DishItemFactId");

                    b.HasOne("Kindergarten.Models.Entities.NumberChildren", "NumberChildren")
                        .WithMany("MovingProducts")
                        .HasForeignKey("NumberChildrenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kindergarten.Models.Entities.Party", "Party")
                        .WithMany("MovingProducts")
                        .HasForeignKey("PartyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kindergarten.Models.Entities.TypeMovingProduct", "TypeMovingProduct")
                        .WithMany("MovingProducts")
                        .HasForeignKey("TypeMovingProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DishItemFact");

                    b.Navigation("NumberChildren");

                    b.Navigation("Party");

                    b.Navigation("TypeMovingProduct");
                });

            modelBuilder.Entity("Kindergarten.Models.Entities.Party", b =>
                {
                    b.HasOne("Kindergarten.Models.Entities.Invoice", "Invoice")
                        .WithMany("Party")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kindergarten.Models.Entities.Product", "Product")
                        .WithMany("Parties")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kindergarten.Models.Entities.Supplier", "Supplier")
                        .WithMany("Parties")
                        .HasForeignKey("SupplierId");

                    b.Navigation("Invoice");

                    b.Navigation("Product");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Kindergarten.Models.Entities.User", b =>
                {
                    b.HasOne("Kindergarten.Models.Entities.Employee", "Employee")
                        .WithMany("Users")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Kindergarten.Models.Entities.Dish", b =>
                {
                    b.Navigation("DishItems");
                });

            modelBuilder.Entity("Kindergarten.Models.Entities.DishFact", b =>
                {
                    b.Navigation("DishItemFacts");
                });

            modelBuilder.Entity("Kindergarten.Models.Entities.DishItemFact", b =>
                {
                    b.Navigation("MovingProducts");
                });

            modelBuilder.Entity("Kindergarten.Models.Entities.Employee", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Kindergarten.Models.Entities.Invoice", b =>
                {
                    b.Navigation("Party");
                });

            modelBuilder.Entity("Kindergarten.Models.Entities.Menu", b =>
                {
                    b.Navigation("Dishes");
                });

            modelBuilder.Entity("Kindergarten.Models.Entities.MenuFact", b =>
                {
                    b.Navigation("Dishes");
                });

            modelBuilder.Entity("Kindergarten.Models.Entities.NumberChildren", b =>
                {
                    b.Navigation("MovingProducts");
                });

            modelBuilder.Entity("Kindergarten.Models.Entities.Party", b =>
                {
                    b.Navigation("MovingProducts");
                });

            modelBuilder.Entity("Kindergarten.Models.Entities.Product", b =>
                {
                    b.Navigation("DishItemFacts");

                    b.Navigation("DishItems");

                    b.Navigation("Parties");
                });

            modelBuilder.Entity("Kindergarten.Models.Entities.Supplier", b =>
                {
                    b.Navigation("Invoices");

                    b.Navigation("Parties");
                });

            modelBuilder.Entity("Kindergarten.Models.Entities.TypeMovingProduct", b =>
                {
                    b.Navigation("MovingProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
