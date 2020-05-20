using ParkingTerminals.DomainObjects;
using ParkingTerminals.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingTerminals.ApplicationServices.GetParkingTerminalListUseCase
{
    public class GetParkingTerminalListUseCaseResponse : UseCaseResponse
    {
        public IEnumerable<ParkingTerminal> ParkingTerminals { get; }

        public GetParkingTerminalListUseCaseResponse(IEnumerable<ParkingTerminal> parkingTerminals) => ParkingTerminals = parkingTerminals;
    }
}
