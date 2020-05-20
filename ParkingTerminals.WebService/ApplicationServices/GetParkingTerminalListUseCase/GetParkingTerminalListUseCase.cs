using System.Threading.Tasks;
using System.Collections.Generic;
using ParkingTerminals.DomainObjects;
using ParkingTerminals.DomainObjects.Ports;
using ParkingTerminals.ApplicationServices.Ports;

namespace ParkingTerminals.ApplicationServices.GetParkingTerminalListUseCase
{
    public class GetParkingTerminalListUseCase : IGetParkingTerminalListUseCase
    {
        private readonly IReadOnlyParkingTerminalRepository _readOnlyParkingTerminalRepository;

        public GetParkingTerminalListUseCase(IReadOnlyParkingTerminalRepository readOnlyParkingTerminalRepository) 
            => _readOnlyParkingTerminalRepository = readOnlyParkingTerminalRepository;

        public async Task<bool> Handle(GetParkingTerminalListUseCaseRequest request, IOutputPort<GetParkingTerminalListUseCaseResponse> outputPort)
        {
            IEnumerable<ParkingTerminal> parkingTerminals = null;
            if (request.ParkingTerminalId != null)
            {
                var parkingTerminal = await _readOnlyParkingTerminalRepository.GetParkingTerminal(request.ParkingTerminalId.Value);
                parkingTerminals = (parkingTerminal != null) ? new List<ParkingTerminal>() { parkingTerminal } : new List<ParkingTerminal>();
                
            }
            else if (request.District != null)
            {
                parkingTerminals = await _readOnlyParkingTerminalRepository.QueryParkingTerminals(new DistrictCriteria(request.District));
            }
            else
            {
                parkingTerminals = await _readOnlyParkingTerminalRepository.GetAllParkingTerminals();
            }
            outputPort.Handle(new GetParkingTerminalListUseCaseResponse(parkingTerminals));
            return true;
        }
    }
}
