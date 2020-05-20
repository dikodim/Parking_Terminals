﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParkingTerminals.InfrastructureServices.Gateways.Database;

namespace MoscowTransport.WebService.Migrations
{
    [DbContext(typeof(PurkingTerminalContext))]
    partial class PurkingTerminalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("ParkingTerminals.DomainObjects.ParkingTerminal", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AdmDistrict")
                        .HasColumnType("TEXT");

                    b.Property<string>("District")
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .HasColumnType("TEXT");

                    b.Property<string>("NamePark")
                        .HasColumnType("TEXT");

                    b.Property<string>("NumberParkingZone")
                        .HasColumnType("TEXT");

                    b.Property<string>("Street")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ParkingTerminals");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            AdmDistrict = "Северный административный округ",
                            District = "Северный",
                            Location = "улица Авиаконструктора Яковлева,дом 27,корпус 2",
                            NamePark = "Паркомат № 2071",
                            NumberParkingZone = "4014",
                            Street = "улица Авиаконструктора Яковлева"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
