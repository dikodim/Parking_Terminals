using ParkingTerminals.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingTerminals.ApplicationServices.GetParkingTerminalListUseCase
{
    public class GetParkingTerminalListUseCaseRequest : IUseCaseRequest<GetParkingTerminalListUseCaseResponse>
    {
        public string District { get; private set; }
        public long? ParkingTerminalId { get; private set; }

        private GetParkingTerminalListUseCaseRequest()
        { }

        public static GetParkingTerminalListUseCaseRequest CreateAllParkingTerminalsRequest()
        {
            return new GetParkingTerminalListUseCaseRequest();
        }

        public static GetParkingTerminalListUseCaseRequest CreateParkingTerminalRequest(long parkingTerminalId)
        {
            return new GetParkingTerminalListUseCaseRequest() { ParkingTerminalId = parkingTerminalId };
        }
        public static GetParkingTerminalListUseCaseRequest CreateDistrictParkingTerminalsRequest(string district)
        {
            return new GetParkingTerminalListUseCaseRequest() { District = district };
        }
    }
}
