﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using mission8group.Models;

#nullable disable

namespace mission8group.Migrations
{
    [DbContext(typeof(TimeManagementContext))]
    [Migration("20250228182748_SeedCategoryTable")]
    partial class SeedCategoryTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.13");

            modelBuilder.Entity("mission8group.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Home"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "School"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Work"
                        },
                        new
                        {
                            CategoryId = 4,
                            CategoryName = "Church"
                        });
                });

            modelBuilder.Entity("mission8group.Models.TimeManagementForm", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Completed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DueDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Quadrant")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Task")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TaskId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("mission8group.Models.TimeManagementForm", b =>
                {
                    b.HasOne("mission8group.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
