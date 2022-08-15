using Garage_3.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Garage_3.Services
{
    public class GeneratePersonNumberSelectList : IGeneratePersonNumberSelectList
    {
        private readonly Garage_3Context _context;

        public GeneratePersonNumberSelectList(Garage_3Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<SelectListItem>> GetMemberPersonNumberAsync()
        {
            return await _context.Member
               // .Select(m => m.PersNr)
               // .Distinct()
                .Select(m => new SelectListItem
                {
                    Text = m.PersNr,
                    Value = m.Id.ToString()
                })
                .ToListAsync();
        }
    }
}
