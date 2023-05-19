﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OilWellsWebApiTask.Data;

#nullable disable

namespace OilWellsWebApiTask.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("OilWellsWebApiTask.Models.DrillBlock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("DrillBlocks");
                });

            modelBuilder.Entity("OilWellsWebApiTask.Models.DrillBlockPoints", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DrillBlockId")
                        .HasColumnType("integer");

                    b.Property<int>("Sequence")
                        .HasColumnType("integer");

                    b.Property<int>("X")
                        .HasColumnType("integer");

                    b.Property<int>("Y")
                        .HasColumnType("integer");

                    b.Property<int>("Z")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DrillBlockId");

                    b.ToTable("DrillBlockPoints");
                });

            modelBuilder.Entity("OilWellsWebApiTask.Models.Hole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Depth")
                        .HasColumnType("integer");

                    b.Property<int>("DrillBlockId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DrillBlockId");

                    b.ToTable("Holes");
                });

            modelBuilder.Entity("OilWellsWebApiTask.Models.HolePoints", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("HoleId")
                        .HasColumnType("integer");

                    b.Property<int>("X")
                        .HasColumnType("integer");

                    b.Property<int>("Y")
                        .HasColumnType("integer");

                    b.Property<int>("Z")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("HoleId");

                    b.ToTable("HolePoints");
                });

            modelBuilder.Entity("OilWellsWebApiTask.Models.DrillBlockPoints", b =>
                {
                    b.HasOne("OilWellsWebApiTask.Models.DrillBlock", "DrillBlock")
                        .WithMany("DrillBlockPoints")
                        .HasForeignKey("DrillBlockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DrillBlock");
                });

            modelBuilder.Entity("OilWellsWebApiTask.Models.Hole", b =>
                {
                    b.HasOne("OilWellsWebApiTask.Models.DrillBlock", "DrillBlock")
                        .WithMany("Holes")
                        .HasForeignKey("DrillBlockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DrillBlock");
                });

            modelBuilder.Entity("OilWellsWebApiTask.Models.HolePoints", b =>
                {
                    b.HasOne("OilWellsWebApiTask.Models.Hole", "Hole")
                        .WithMany("HolePoints")
                        .HasForeignKey("HoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hole");
                });

            modelBuilder.Entity("OilWellsWebApiTask.Models.DrillBlock", b =>
                {
                    b.Navigation("DrillBlockPoints");

                    b.Navigation("Holes");
                });

            modelBuilder.Entity("OilWellsWebApiTask.Models.Hole", b =>
                {
                    b.Navigation("HolePoints");
                });
#pragma warning restore 612, 618
        }
    }
}