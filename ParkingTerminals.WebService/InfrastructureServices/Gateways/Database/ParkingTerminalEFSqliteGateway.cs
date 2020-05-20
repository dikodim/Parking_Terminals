using ParkingTerminals.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using ParkingTerminals.ApplicationServices.Ports.Gateways.Database;

namespace ParkingTerminals.InfrastructureServices.Gateways.Database
{
    public class ParkingTerminalEFSqliteGateway : IParkingTerminalDatabaseGateway
    {
        private readonly PurkingTerminalContext _parkingTerminalContext;

        public ParkingTerminalEFSqliteGateway(PurkingTerminalContext transportContext)
            => _parkingTerminalContext = transportContext;

        public async Task<ParkingTerminal> GetParkingTerminal(long id)
           => await _parkingTerminalContext.ParkingTerminals.Where(r => r.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<ParkingTerminal>> GetAllParkingTerminals()
            => await _parkingTerminalContext.ParkingTerminals.ToListAsync();
          
        public async Task<IEnumerable<ParkingTerminal>> QueryParkingTerminals(Expression<Func<ParkingTerminal, bool>> filter)
            => await _parkingTerminalContext.ParkingTerminals.Where(filter).ToListAsync();

        public async Task AddParkingTerminal(ParkingTerminal parkingTerminal)
        {
            _parkingTerminalContext.ParkingTerminals.Add(parkingTerminal);
            await _parkingTerminalContext.SaveChangesAsync();
        }

        public async Task UpdateParkingTerminal(ParkingTerminal parkingTerminal)
        {
            _parkingTerminalContext.Entry(parkingTerminal).State = EntityState.Modified;
            await _parkingTerminalContext.SaveChangesAsync();
        }

        public async Task RemoveParkingTerminal(ParkingTerminal parkingTerminal)
        {
            _parkingTerminalContext.ParkingTerminals.Remove(parkingTerminal);
            await _parkingTerminalContext.SaveChangesAsync();
        }

    }
}
