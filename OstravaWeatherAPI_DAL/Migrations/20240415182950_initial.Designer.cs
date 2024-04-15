﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OstravaWeatherAPI_DAL.Data;

#nullable disable

namespace OstravaWeatherAPI_DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240415182950_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("OstravaWeatherAPI_DAL.Entities.DailyWeather", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<float>("RainSum")
                        .HasColumnType("real");

                    b.Property<float>("TemperatureMax")
                        .HasColumnType("real");

                    b.Property<float>("TemperatureMin")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("DailyWeather");
                });
#pragma warning restore 612, 618
        }
    }
}
