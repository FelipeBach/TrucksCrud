using Microsoft.AspNetCore.Mvc;
using TruckCrud.Data;
using TruckCrud.Interfaces;
using TruckCrud.Models;

namespace TruckCrud.Controllers
{
    public class TrucksController : Controller
    {
        private readonly DataContext _context;
        private readonly ITruckService _service;

        public TrucksController(DataContext context, ITruckService service)
        {
            _context = context;
            _service = service;
        }

        // GET: Trucks
        public async Task<IActionResult> Index()
        {

            return View(await _service.GetTrucks());
            
        }
                
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {

            if (id == 0)
            {
                return View(new Truck());
            }
            else
            {
                return  View(await _service.GetTruckById(id));
            }                        
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id,Model,ManufectureYear,ModelYear")] Truck truck)
        {
            if (ModelState.IsValid)
            {
                await _service.AddOrEditTruck(truck);  
                return RedirectToAction(nameof(Index));
            }
            return View(truck);
        }
              
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var dbTruck = await _context.Trucks.FindAsync(id);
        //    _context.Trucks.Remove(dbTruck);
        //    await _context.SaveChangesAsync();

        //    return RedirectToAction(nameof(Index));
        //}

        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteTruck(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
