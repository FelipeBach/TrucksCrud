using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using TruckCrud.Data;
using TruckCrud.Models;
using TruckCrud.Services;

namespace TruckCrudTests
{
    [TestClass]
    public class TruckTests
    {        

        private async Task<DataContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new DataContext(options);
            databaseContext.Database.EnsureCreated();
            if (await databaseContext.Trucks.CountAsync() <= 0)
            {
                for (int i = 1; i <= 10; i++)
                {
                    databaseContext.Trucks.Add(new Truck()
                    {
                        Id = i,
                        ManufectureYear = 2022,
                        Model = "FH",
                        ModelYear = 2023,
                        Plate = "ABC12D3",
                        RegisterNumber = 51652,
                    });
                    await databaseContext.SaveChangesAsync();
                }
            }
            return databaseContext;
        }

        [TestMethod]
        public async Task Should_Return_All_Trucks_When_Calling_Get_Without_Parameters()
        {
            // arrange            
            var dbContext = await GetDatabaseContext();
            var truckService = new TruckService(dbContext);

            //act
            var trucks = truckService.GetTrucks();
            //assert
            Assert.IsNotNull(trucks);
        }

        [TestMethod]
        public async Task Should_Return_One_Truck_When_Calling_Get_With_ID()
        {
            // arrange            
            var dbContext = await GetDatabaseContext();
            var truckService = new TruckService(dbContext);

            //act
            var truck = truckService.GetTruckById(1);
            //assert
            Assert.IsNotNull(truck);
            Assert.AreEqual(1, truck.Id);
        }        
    }
}