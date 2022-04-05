using Microsoft.EntityFrameworkCore;
using TruckCrud.Models;

namespace TruckCrud.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options ): base( options ){ }

        public DbSet<Truck> Trucks { get; set; }
    }
}
