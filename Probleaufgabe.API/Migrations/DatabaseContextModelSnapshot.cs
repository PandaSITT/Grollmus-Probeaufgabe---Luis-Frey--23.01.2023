﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Probleaufgabe.API.Models;

#nullable disable

namespace Probleaufgabe.API.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Probleaufgabe.API.Models.Device", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool?>("advancedEnvironmentalConditions")
                        .HasColumnType("bit");

                    b.Property<string>("deviceTypeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("failsafe")
                        .HasColumnType("bit");

                    b.Property<bool>("insertInto19InchCabinet")
                        .HasColumnType("bit");

                    b.Property<string>("installationPosition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("motionEnable")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("positionAxisNumber")
                        .HasColumnType("int");

                    b.Property<int>("rotationAxisNumber")
                        .HasColumnType("int");

                    b.Property<bool>("simaticCatalog")
                        .HasColumnType("bit");

                    b.Property<bool>("siplusCatalog")
                        .HasColumnType("bit");

                    b.Property<int>("tempMax")
                        .HasColumnType("int");

                    b.Property<int>("tempMin")
                        .HasColumnType("int");

                    b.Property<bool?>("terminalElement")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.ToTable("Devices");
                });
#pragma warning restore 612, 618
        }
    }
}
