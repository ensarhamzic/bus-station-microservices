﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RoutesManagement.Data;

#nullable disable

namespace RoutesManagement.Migrations
{
    [DbContext(typeof(RoutesDbContext))]
    [Migration("20240106160417_LocationFieldsChange")]
    partial class LocationFieldsChange
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RoutesManagement.Data.Models.Bus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacity")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Plate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Buses");
                });

            modelBuilder.Entity("RoutesManagement.Data.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("RoutesManagement.Data.Models.Route", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("BusId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("DriverId")
                        .HasColumnType("integer");

                    b.Property<int>("FromLocationId")
                        .HasColumnType("integer");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<int>("ToLocationId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BusId");

                    b.HasIndex("FromLocationId");

                    b.HasIndex("ToLocationId");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("RoutesManagement.Data.Models.Route", b =>
                {
                    b.HasOne("RoutesManagement.Data.Models.Bus", "Bus")
                        .WithMany("Routes")
                        .HasForeignKey("BusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RoutesManagement.Data.Models.Location", "FromLocation")
                        .WithMany("RoutesFromLocation")
                        .HasForeignKey("FromLocationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RoutesManagement.Data.Models.Location", "ToLocation")
                        .WithMany("RoutesToLocation")
                        .HasForeignKey("ToLocationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Bus");

                    b.Navigation("FromLocation");

                    b.Navigation("ToLocation");
                });

            modelBuilder.Entity("RoutesManagement.Data.Models.Bus", b =>
                {
                    b.Navigation("Routes");
                });

            modelBuilder.Entity("RoutesManagement.Data.Models.Location", b =>
                {
                    b.Navigation("RoutesFromLocation");

                    b.Navigation("RoutesToLocation");
                });
#pragma warning restore 612, 618
        }
    }
}
