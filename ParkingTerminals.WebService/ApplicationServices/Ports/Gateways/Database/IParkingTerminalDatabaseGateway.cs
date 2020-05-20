using ParkingTerminals.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ParkingTerminals.ApplicationServices.Ports.Gateways.Database
{
    public interface IParkingTerminalDatabaseGateway
    {
        Task AddParkingTerminal(ParkingTerminal parkingTerminal);

        Task RemoveParkingTerminal(ParkingTerminal parkingTerminal);

        Task UpdateParkingTerminal(ParkingTerminal parkingTerminal);

        Task<ParkingTerminal> GetParkingTerminal(long id);

        Task<IEnumerable<ParkingTerminal>> GetAllParkingTerminals();

        Task<IEnumerable<ParkingTerminal>> QueryParkingTerminals(Expression<Func<ParkingTerminal, bool>> filter);

    }
}