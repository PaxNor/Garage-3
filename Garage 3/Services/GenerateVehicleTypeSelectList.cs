using Garage_3.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Garage_3.Services
{
    public class GenerateVehicleTypeSelectList : IGenerateVehicleTypeSelectList
    {

        private readonly Garage_3Context _context;

        public GenerateVehicleTypeSelectList(Garage_3Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<SelectListItem>> GetVehicleTypeSelectListAsync()
        {
            return await _context.VehicleType
                .Select(m => m.Name)
                .Distinct()
                .Select(m => new SelectListItem
                {
                    Text = m.ToString(),
                    Value = m.ToString()
                })
                .ToListAsync();
        }

    }
}
