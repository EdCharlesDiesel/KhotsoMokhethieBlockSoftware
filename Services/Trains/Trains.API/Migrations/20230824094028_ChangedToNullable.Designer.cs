﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Trains.API.Context;

#nullable disable

namespace Trains.API.Migrations
{
    [DbContext(typeof(TrainsDbContext))]
    [Migration("20230824094028_ChangedToNullable")]
    partial class ChangedToNullable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Trains.API.Entities.FileDetails", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("FileData")
                        .IsRequired()
                        .HasColumnType("varbinary(MAX)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FileType")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("FileDetails");
                });
#pragma warning restore 612, 618
        }
    }
}