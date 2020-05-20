using ParkingTerminals.ApplicationServices.Ports.Gateways.Database;
using ParkingTerminals.DomainObjects;
using ParkingTerminals.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ParkingTerminals.ApplicationServices.Repositories
{
    public class DbParkingTerminalRepository : IReadOnlyParkingTerminalRepository,
                                               IParkingTerminalRepository
    {
        private readonly IParkingTerminalDatabaseGateway _databaseGateway;

        public DbParkingTerminalRepository(IParkingTerminalDatabaseGateway databaseGateway)
            => _databaseGateway = databaseGateway;

        public async Task<ParkingTerminal> GetParkingTerminal(long id)
            => await _databaseGateway.GetParkingTerminal(id);

        public async Task<IEnumerable<ParkingTerminal>> GetAllParkingTerminals()
            => await _databaseGateway.GetAllParkingTerminals();

        public async Task<IEnumerable<ParkingTerminal>> QueryParkingTerminals(ICriteria<ParkingTerminal> criteria)
            => await _databaseGateway.QueryParkingTerminals(criteria.Filter);

        public async Task AddParkingTerminal(ParkingTerminal parkingTerminal)
            => await _databaseGateway.AddParkingTerminal(parkingTerminal);

        public async Task RemoveParkingTerminal(ParkingTerminal parkingTerminal)
            => await _databaseGateway.RemoveParkingTerminal(parkingTerminal);

        public async Task UpdateParkingTerminal(ParkingTerminal parkingTerminal)
            => await _databaseGateway.UpdateParkingTerminal(parkingTerminal);
    }
}
