using Garage_3.Auxiliary;
using Garage_3.Data;
using Garage_3.Models;
using Garage_3.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Garage_3.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly Garage_3Context _context;

        public VehiclesController(Garage_3Context context)
        {
            _context = context;
        }

        // GET: Vehicles
        public async Task<IActionResult> Index()
        {
            List<ParkedVehiclesViewModel> vmList = new();
            int hours, minutes;


            foreach (var parkingSpot in _context.Parking) {

                double parkedTime = (DateTime.Now - parkingSpot.ArrivalTime).TotalMinutes;
                Vehicle? vehicle = await _context.Vehicle.Include(v => v.Member).Include(v => v.VehicleType).FirstOrDefaultAsync(v => v.Id == parkingSpot.VehicleId);//.FirstOrDefault();
                                                                                                                                                                     // Member? member    = _context.Member.Where(m => m.Id == vehicle.MemberId).FirstOrDefault();
                                                                                                                                                                     //VehicleType type  = vehicle.VehicleType;

                hours = (int)parkedTime / 60;
                minutes = (int)(parkedTime - (hours * 60));
                      

                if (vehicle != null) { 
                    ParkedVehiclesViewModel vm = new();
                    vm.FirstName = vehicle.Member.FirstName;
                    vm.LastName = vehicle.Member.LastName;
                    vm.PersNr = vehicle.Member.PersNr;
                    vm.ParkedTime = String.Format("{0}:{1}", hours, minutes);
                    vm.RegNr = vehicle.RegNbr;
                    vm.Brand = vehicle.Brand;
                    vm.VehicleModel = vehicle.Model;
                    vm.Type = vehicle.VehicleType.Name;//type.Name;
                    vm.Color = vehicle.Color;
                    vm.WheelCount = vehicle.WheelCount;
                    vm.Id = vehicle.Id;

                    vmList.Add(vm);
                }
            }

            return View(vmList);

            //return _context.Vehicle != null ? 
            //              View(await _context.Vehicle.ToListAsync()) :
            //              Problem("Entity set 'Garage_3Context.Vehicle'  is null.");
        }

        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vehicle == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // GET: Vehicles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CheckinViewModel checkinViewModel)
        {
            if (ModelState.IsValid) {

              //  var member = _context.Member.Where(m => m.PersNr == checkinViewModel.PersNr).First();
                //var vehicleType = _context.VehicleType.Where(vt => vt.Id == checkinViewModel.VehicleTypeId).First();

                Parking parking = new Parking() {
                    ArrivalTime = DateTime.Now
                };

                Vehicle vehicle = new Vehicle() {
                    WheelCount = checkinViewModel.WheelCount,
                    Color = checkinViewModel.Color,
                    Brand = checkinViewModel.Brand,
                    RegNbr = StringFormatter.CompactLicensePlate(checkinViewModel.RegNbr),
                    Model = checkinViewModel.VehicleModel,

                    // navigation properties
                    //VehicleType = vehicleType,
                    VehicleTypeId = checkinViewModel.VehicleTypeId,
                    Parking = parking,
                    
                    // foreign key
                    MemberId = checkinViewModel.MemberId                };

                _context.Add(vehicle);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Fordonet har checkat in utan problem!";
                return RedirectToAction(nameof(Index));
            }
            return View(checkinViewModel);
        }

        // GET: Vehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vehicle == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, /*[Bind("Id,RegNbr,Color,Brand,Model,WheelCount,MemberId")]*/ Vehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(vehicle.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vehicle == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Vehicle == null)
        //    {
        //        return Problem("Entity set 'Garage_3Context.Vehicle'  is null.");
        //    }
        //    var vehicle = await _context.Vehicle.FindAsync(id);
        //    if (vehicle != null)
        //    {
        //        _context.Vehicle.Remove(vehicle);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vehicle == null)
            {
                return Problem("Entity set 'Garage_2_0Context.ParkedVehicle'  is null.");
            }

            var vehicle = await _context.Vehicle.FindAsync(id);
            var parking = vehicle.Parking;
            var vehicleType = vehicle.VehicleType;
            var member = _context.Member.Where(m => m.Id == vehicle.MemberId).FirstOrDefault();
            //vehicleType.Vehicles.Remove(vehicle);
 
            if (vehicle != null && member != null && parking != null)
            {
               _context.Parking.Remove(parking);
               _context.Member.Remove(member);
               _context.Vehicle.Remove(vehicle);
            }
            
            
            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Checkout(int id)
        {
            var vehicle = await _context.Vehicle.Include(v => v.Parking).FirstOrDefaultAsync(v => v.Id == id);
            var member = await _context.Member.Where(m => m.Id == vehicle.MemberId).FirstOrDefaultAsync();

            var receipt = new ReceiptViewModel(
                vehicle.Parking.ArrivalTime,
                vehicle.RegNbr,
                vehicle.Color!,
                vehicle.Brand!,
                member.PersNr,
                member.FirstName,
                member.LastName);

            vehicle.Parking = null;
            _context.Update(vehicle);
            await _context.SaveChangesAsync();

            return View("Receipt", receipt);
        }

        private bool VehicleExists(int id)
        {
          return (_context.Vehicle?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
