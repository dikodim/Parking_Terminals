using ParkingTerminals.DomainObjects;
using ParkingTerminals.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ParkingTerminals.ApplicationServices.GetParkingTerminalListUseCase
{
    public class DistrictCriteria : ICriteria<ParkingTerminal>
    {
        public string District { get; }

        public DistrictCriteria(string district)
            => District = district;

        public Expression<Func<ParkingTerminal, bool>> Filter
            => (pt => pt.District == District);
    }
}
