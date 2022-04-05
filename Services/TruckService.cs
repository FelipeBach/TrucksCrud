using Microsoft.EntityFrameworkCore;
using TruckCrud.Data;
using TruckCrud.Interfaces;
using TruckCrud.Models;

namespace TruckCrud.Services
{
    public class TruckService : ITruckService
    {

        private readonly DataContext _context;

        public TruckService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Truck>> GetTrucks()
        {
            return await _context.Trucks.ToListAsync();
        }

        public async Task<Truck> GetTruckById(int? id)
        {
            return await _context.Trucks.FindAsync(id);
        }

        public async Task<int> DeleteTruck(int id)
        {
            var dbTruck = await _context.Trucks.FindAsync(id);
            _context.Trucks.Remove(dbTruck);
            return await _context.SaveChangesAsync();            
        }

        public async Task<Truck> AddOrEditTruck(Truck truck)
        {
            if (truck.Id == 0)
                _context.Add(truck);
            else
                _context.Update(truck);

            await _context.SaveChangesAsync();

            return truck;
        }

    }
}
