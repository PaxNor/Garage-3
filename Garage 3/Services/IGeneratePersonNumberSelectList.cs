using Microsoft.AspNetCore.Mvc.Rendering;

namespace Garage_3.Services
{
    public interface IGeneratePersonNumberSelectList
    {
        Task<IEnumerable<SelectListItem>> GetMemberPersonNumberAsync();
    }
}