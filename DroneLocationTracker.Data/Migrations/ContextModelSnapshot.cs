﻿// <auto-generated />
using System;
using DroneLocationTracker.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DroneLocationTracker.Data.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1");

            modelBuilder.Entity("DroneLocationTracker.Data.Models.Drone", b =>
                {
                    b.Property<Guid>("DroneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("LastLocationId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("DroneId");

                    b.HasIndex("LastLocationId")
                        .IsUnique();

                    b.ToTable("Drones");
                });

            modelBuilder.Entity("DroneLocationTracker.Data.Models.Location", b =>
                {
                    b.Property<Guid>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DroneId")
                        .HasColumnType("TEXT");

                    b.Property<double>("Latitude")
                        .HasColumnType("REAL");

                    b.Property<double>("Longitude")
                        .HasColumnType("REAL");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("DroneLocationTracker.Data.Models.Drone", b =>
                {
                    b.HasOne("DroneLocationTracker.Data.Models.Location", "LastLocation")
                        .WithOne("Drone")
                        .HasForeignKey("DroneLocationTracker.Data.Models.Drone", "LastLocationId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
