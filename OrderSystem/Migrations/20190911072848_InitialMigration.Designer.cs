﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrderSystem.Repository;

namespace OrderSystem.Migrations
{
    [DbContext(typeof(OrdersDBContext))]
    [Migration("20190911072848_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OrderSystem.Model.Core.Orders", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("status");

                    b.HasKey("OrderID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OrderSystem.Model.Core.Orders", b =>
                {
                    b.OwnsOne("OrderSystem.Model.Core.OrderDateType", "OrderDate", b1 =>
                        {
                            b1.Property<int>("OrdersOrderID")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<DateTime>("OrderDate")
                                .HasColumnName("OrderDate");

                            b1.HasKey("OrdersOrderID");

                            b1.ToTable("Orders");

                            b1.HasOne("OrderSystem.Model.Core.Orders")
                                .WithOne("OrderDate")
                                .HasForeignKey("OrderSystem.Model.Core.OrderDateType", "OrdersOrderID")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsMany("OrderSystem.Model.Core.OrderItems", "lineItems", b1 =>
                        {
                            b1.Property<int>("OrderLineItemID")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("OrderLineItemID")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int>("OrderId");

                            b1.Property<int>("ProductID")
                                .HasColumnName("ProductIdentifier");

                            b1.Property<int>("ProductPrice")
                                .HasColumnName("ProductPrice");

                            b1.Property<int>("ProductQuantity")
                                .HasColumnName("Quantity");

                            b1.HasKey("OrderLineItemID");

                            b1.HasIndex("OrderId");

                            b1.ToTable("OrderLine");

                            b1.HasOne("OrderSystem.Model.Core.Orders")
                                .WithMany("lineItems")
                                .HasForeignKey("OrderId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
