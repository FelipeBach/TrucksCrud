using TruckCrud.Models;

namespace TruckCrud.Interfaces
{
    public interface ITruckService
    {
        public Task<List<Truck>> GetTrucks();

        public Task<Truck> GetTruckById(int? id);

        public Task<int> DeleteTruck(int id);

        public Task<Truck> AddOrEditTruck(Truck truck);
    }
}
