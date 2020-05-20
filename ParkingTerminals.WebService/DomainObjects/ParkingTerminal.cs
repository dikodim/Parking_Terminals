using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingTerminals.DomainObjects
{
    public class ParkingTerminal : DomainObject
    {
        public string NumberParkingZone { get; set; }

        public string NamePark { get; set; }

        public string AdmDistrict { get; set; }

        public string District { get; set; }

        public string Street { get; set; }

        public string Location { get; set; }

    }
}
