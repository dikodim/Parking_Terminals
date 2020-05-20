using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace ParkingTerminals.DomainObjects.Ports
{
    public interface IReadOnlyParkingTerminalRepository
    {
        Task<ParkingTerminal> GetParkingTerminal(long id);

        Task<IEnumerable<ParkingTerminal>> GetAllParkingTerminals();

        Task<IEnumerable<ParkingTerminal>> QueryParkingTerminals(ICriteria<ParkingTerminal> criteria);

    }

    public interface IParkingTerminalRepository
    {
        Task AddParkingTerminal(ParkingTerminal parkingTerminal);

        Task RemoveParkingTerminal(ParkingTerminal parkingTerminal);

        Task UpdateParkingTerminal(ParkingTerminal parkingTerminal);
    }
}
