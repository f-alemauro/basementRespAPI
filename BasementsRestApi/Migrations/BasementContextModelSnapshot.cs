﻿// <auto-generated />
using System;
using BasementsRestApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BasementsRestApi.Migrations
{
    [DbContext(typeof(BasementContext))]
    partial class BasementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("BasementsRestApi.Models.Item", b =>
                {
                    b.Property<int>("ItemID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddedOn");

                    b.Property<DateTime>("ExpireOn");

                    b.Property<int>("ItemDefinitionID");

                    b.Property<int>("Quantity");

                    b.Property<int>("UserID");

                    b.HasKey("ItemID");

                    b.HasIndex("ItemDefinitionID");

                    b.HasIndex("UserID");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("BasementsRestApi.Models.ItemDefinition", b =>
                {
                    b.Property<int>("ItemDefinitionID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BarCode");

                    b.Property<string>("Description")
                        .HasMaxLength(30);

                    b.Property<int>("Type");

                    b.Property<int>("UnitOfMeasurement");

                    b.Property<int>("Volume");

                    b.HasKey("ItemDefinitionID");

                    b.ToTable("ItemDefinitions");
                });

            modelBuilder.Entity("BasementsRestApi.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LastActivityTimestamp");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BasementsRestApi.Models.Item", b =>
                {
                    b.HasOne("BasementsRestApi.Models.ItemDefinition", "ItemDefinition")
                        .WithMany("Items")
                        .HasForeignKey("ItemDefinitionID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BasementsRestApi.Models.User", "User")
                        .WithMany("Items")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
