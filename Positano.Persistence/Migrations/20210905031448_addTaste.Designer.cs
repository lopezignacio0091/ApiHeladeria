﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Positano.Persistence;

namespace Positano.Persistence.Migrations
{
    [DbContext(typeof(PositanoContext))]
    [Migration("20210905031448_addTaste")]
    partial class addTaste
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Positano.Domain.Entities.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Positano.Domain.Entities.Purchase", b =>
                {
                    b.Property<int>("PurchaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.HasKey("PurchaseId");

                    b.HasIndex("OrderId");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("Positano.Domain.Entities.Taste", b =>
                {
                    b.Property<int>("TasteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("TasteId");

                    b.HasIndex("OrderId");

                    b.ToTable("Tastes");
                });

            modelBuilder.Entity("Positano.Domain.Entities.TypeOrder", b =>
                {
                    b.Property<int>("TypeOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("TypeOrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("TypeOrders");
                });

            modelBuilder.Entity("Positano.Domain.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Direction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Positano.Domain.Entities.Order", b =>
                {
                    b.HasOne("Positano.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Positano.Domain.Entities.Purchase", b =>
                {
                    b.HasOne("Positano.Domain.Entities.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Positano.Domain.Entities.Taste", b =>
                {
                    b.HasOne("Positano.Domain.Entities.Order", null)
                        .WithMany("Tastes")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("Positano.Domain.Entities.TypeOrder", b =>
                {
                    b.HasOne("Positano.Domain.Entities.Order", null)
                        .WithMany("TypeOrders")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("Positano.Domain.Entities.Order", b =>
                {
                    b.Navigation("Tastes");

                    b.Navigation("TypeOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
