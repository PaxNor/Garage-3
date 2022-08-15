using Microsoft.AspNetCore.Mvc.Rendering;

namespace Garage_3.Services
{
    public interface IGenerateVehicleTypeSelectList
    {
        Task<IEnumerable<SelectListItem>> GetVehicleTypeSelectListAsync();
    }
}