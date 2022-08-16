using Garage_3.Auxiliary;
using Garage_3.Data;
using Garage_3.Models;
using Garage_3.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Garage_3.Controllers
{
    public class MembersController : Controller
    {
        private readonly Garage_3Context _context;

        public MembersController(Garage_3Context context)
        {
            _context = context;
        }

        // GET: Members
        //public async Task<IActionResult> Index()
        //{
        //    var viewModel = new MemberOverviewViewModel()
        //    {
        //        Members = await _context.Member.ToListAsync()
        //    };
        //    return View(viewModel);
        //}

        //public async Task<IActionResult> MemberOverviewSearch(MemberOverviewViewModel memberOverviewViewModel)
        //{
        //    var members = string.IsNullOrWhiteSpace(memberOverviewViewModel.FirstName) ?
        //        _context.Member :
        //        _context.Member.Where(m => m.FirstName.StartsWith(memberOverviewViewModel.FirstName));

        //    var viewModel = new MemberOverviewViewModel
        //    {
        //        Members = await members.ToListAsync()
        //    };

        //    return View(nameof(Index), viewModel);
        //}



        public async Task<IActionResult> Index()// string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            //ViewData["CurrentSort"] = sortOrder;
            //ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //ViewData["CurrentFilter"] = searchString;

            //if (searchString != null)
            //{
            //    pageNumber = 1;
            //}
            //else
            //{
            //    searchString = currentFilter;
            //}

            List<MembersViewModel> overviewList = new List<MembersViewModel>();
            var members = _context.Member.AsNoTracking().Include(m => m.Vehicles);//.Include(m => m.Vehicles.Parking);

           // var members = from m in _context.Member select m;

            foreach(var member in members) {

                int vehicleCount = member.Vehicles.Count;

                foreach(var vehicle in member.Vehicles) {

                    var overview = new MembersViewModel();
                    overview.FirstName = member.FirstName;
                    overview.LastName = member.LastName;
                    overview.PersonNumber = member.PersNr;

                    overview.Brand = vehicle.Brand;
                    overview.RegNbr = vehicle.RegNbr;
                    overview.Color = vehicle.Color;
                    overview.Model = vehicle.Model;
                    overview.WheelCount = vehicle.WheelCount;

                    overview.NumberOfVehicles = vehicleCount;
                    //overview.IsParked = vehicle.Parking == null ? "" : "P";// "🅿";
                    var parking = _context.Parking.Where(p => p.VehicleId == vehicle.Id).FirstOrDefault();
                    overview.IsParked = parking == null ? "" : "🅿";

                    overviewList.Add(overview);
                }
            }


            int pageSize = 3;


            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    //members = members.Where(m => m.LastName.Contains(searchString)
            //    //                       || m.FirstName.Contains(searchString));
            //    var m = overviewList.Where(m => m.LastName.Contains(searchString)
            //                            || m.FirstName.Contains(searchString)).AsQueryable();

            //    overviewList = await PaginatedList<MembersViewModel>.CreateAsync(m, pageNumber ?? 1, pageSize).ToList();//.ToList();                     
            //}

            //switch (sortOrder)
            //{
            //    case "name_desc":
            //        overviewList = overviewList.OrderByDescending(m => m.FirstName).ToList();
            //        break;

            //    default:
            //        overviewList = overviewList.OrderBy(m => m.FirstName).ToList();
            //        break;
            //    //case "name_desc":
            //    //    members = members.OrderByDescending(m => m.FirstName);
            //    //    break;

            //    //default:
            //    //    members = members.OrderBy(m => m.FirstName);
            //    //    break;
            //}

            return View(overviewList);
            //return View(await PaginatedList<Member>.CreateAsync(members.AsNoTracking(), pageNumber ?? 1, pageSize));
            
            //return View(await PaginatedList<MembersViewModel>.CreateAsync(overviewList.AsQueryable(), pageNumber ?? 1, pageSize));

            //var memmbers = _context.Member.OrderBy(m => m.FirstName.Substring(0, 2));

        }


        // GET: Members/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Member == null)
            {
                return NotFound();
            }

            var member = await _context.Member
                .FirstOrDefaultAsync(m => m.Id == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // GET: Members/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,PersNr")] Member member)
        {
            if (CheckPerNr(member.PersNr))
            {
                ModelState.AddModelError("PersNr", $"Personnummer: {member.PersNr} finns redan registrerat");
            }

            if (ModelState.IsValid)
            {
                member.PersNr = StringFormatter.CompactPersonNumber(member.PersNr);
                _context.Add(member);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Medlemmen har registrerats utan problem!";
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }

        private bool CheckPerNr(string persNr)
        {
            return _context.Member.Any(m => m.PersNr == persNr);
        }

        /* 
         * Check if a member is already in the data base
         * 
         * This does not work!
         * 
         * reference: https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-6.0#remote-attribute
         */
        [AcceptVerbs("GET", "POST")]
        public IActionResult IsInDataBase(string persNr)
        {
            
            if (CheckPerNr(persNr)) {
                return Json($"Personnummer: {persNr} finns redan registrerat");
            }
            return Json(true);
        }

        // GET: Members/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Member == null)
            {
                return NotFound();
            }

            var member = await _context.Member.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,PersNr")] Member member)
        {
            if (id != member.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(member);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberExists(member.Id))
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
            return View(member);
        }

        // GET: Members/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Member == null)
            {
                return NotFound();
            }

            var member = await _context.Member
                .FirstOrDefaultAsync(m => m.Id == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Member == null)
            {
                return Problem("Entity set 'Garage_3Context.Member'  is null.");
            }
            var member = await _context.Member.FindAsync(id);
            if (member != null)
            {
                _context.Member.Remove(member);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemberExists(int id)
        {
          return (_context.Member?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
