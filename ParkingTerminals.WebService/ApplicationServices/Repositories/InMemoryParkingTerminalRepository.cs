using ParkingTerminals.DomainObjects;
using ParkingTerminals.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ParkingTerminals.ApplicationServices.Repositories
{
    public class InMemoryParkingTerminalRepository : IReadOnlyParkingTerminalRepository,
                                                     IParkingTerminalRepository 
    {
        private readonly List<ParkingTerminal> _parkingTerminals = new List<ParkingTerminal>();

        public InMemoryParkingTerminalRepository(IEnumerable<ParkingTerminal> parkingTerminals = null)
        {
            if (parkingTerminals != null)
            {
                _parkingTerminals.AddRange(parkingTerminals);
            }
        }

        public Task AddParkingTerminal(ParkingTerminal parkingTerminal)
        {
            _parkingTerminals.Add(parkingTerminal);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<ParkingTerminal>> GetAllParkingTerminals()
        {
            return Task.FromResult(_parkingTerminals.AsEnumerable());
        }

        public Task<ParkingTerminal> GetParkingTerminal(long id)
        {
            return Task.FromResult(_parkingTerminals.Where(r => r.Id == id).FirstOrDefault());
        }

        public Task<IEnumerable<ParkingTerminal>> QueryParkingTerminals(ICriteria<ParkingTerminal> criteria)
        {
            return Task.FromResult(_parkingTerminals.Where(criteria.Filter.Compile()).AsEnumerable());
        }

        public Task RemoveParkingTerminal(ParkingTerminal parkingTerminal)
        {
            _parkingTerminals.Remove(parkingTerminal);
            return Task.CompletedTask;
        }

        public Task UpdateParkingTerminal(ParkingTerminal parkingTerminal)
        {
            var foundParkingTerminal = GetParkingTerminal(parkingTerminal.Id).Result;
            if (foundParkingTerminal == null)
            {
                AddParkingTerminal(parkingTerminal);
            }
            else
            {
                if (foundParkingTerminal != parkingTerminal)
                {
                    _parkingTerminals.Remove(foundParkingTerminal);
                    _parkingTerminals.Add(parkingTerminal);
                }
            }
            return Task.CompletedTask;
        }
    }
}
