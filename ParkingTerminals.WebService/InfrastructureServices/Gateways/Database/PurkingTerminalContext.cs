using Microsoft.EntityFrameworkCore;
using ParkingTerminals.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingTerminals.InfrastructureServices.Gateways.Database
{
    public class PurkingTerminalContext : DbContext
    {
        public DbSet<ParkingTerminal> ParkingTerminals { get; set; }


        public PurkingTerminalContext(DbContextOptions options)
            : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParkingTerminal>().HasData(
                new ParkingTerminal()
                {
                    Id = 1,
                    AdmDistrict = "Северный административный округ",
                    District = "Северный",
                    Street = "улица Авиаконструктора Яковлева",
                    Location = "улица Авиаконструктора Яковлева,дом 27,корпус 2",
                    NamePark = "Паркомат № 2071",
                    NumberParkingZone = "4014"
                }
             );
        }
    }
}
