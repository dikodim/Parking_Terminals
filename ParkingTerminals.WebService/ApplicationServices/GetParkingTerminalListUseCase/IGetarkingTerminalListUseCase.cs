using System;
using System.Collections.Generic;
using System.Text;
using ParkingTerminals.ApplicationServices.Interfaces;

namespace ParkingTerminals.ApplicationServices.GetParkingTerminalListUseCase
{
    public interface IGetParkingTerminalListUseCase : IUseCase<GetParkingTerminalListUseCaseRequest, GetParkingTerminalListUseCaseResponse>
    {
    }
}
