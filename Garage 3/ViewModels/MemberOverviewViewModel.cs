using Garage_3.Models;

namespace Garage_3.ViewModels
{
    public class MemberOverviewViewModel
    {
        public IEnumerable<Member> Members { get; set; } = new List<Member>();
        public string FirstName { get; set; } = string.Empty;
        
    }
}
