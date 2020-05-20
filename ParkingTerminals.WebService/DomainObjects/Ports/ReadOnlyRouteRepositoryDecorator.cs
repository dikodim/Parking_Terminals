using ParkingTerminals.DomainObjects;
using ParkingTerminals.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ParkingTerminals.DomainObjects.Repositories
{
    public abstract class ReadOnlyRouteRepositoryDecorator : IReadOnlyParkingTerminalRepository
    {
        private readonly IReadOnlyParkingTerminalRepository _parkingTerminalRepository;

        public ReadOnlyRouteRepositoryDecorator(IReadOnlyParkingTerminalRepository routeRepository)
        {
            _parkingTerminalRepository = routeRepository;
        }

        public virtual async Task<IEnumerable<ParkingTerminal>> GetAllParkingTerminals()
        {
            return await _parkingTerminalRepository?.GetAllParkingTerminals();
        }

        public virtual async Task<ParkingTerminal> GetParkingTerminal(long id)
        {
            return await _parkingTerminalRepository?.GetParkingTerminal(id);
        }

        public virtual async Task<IEnumerable<ParkingTerminal>> QueryParkingTerminals(ICriteria<ParkingTerminal> criteria)
        {
            return await _parkingTerminalRepository?.QueryParkingTerminals(criteria);
        }
    }
}
