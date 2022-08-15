using System.ComponentModel;

namespace Garage_3.Models
{
    public class VehicleType
    {
        public int Id { get; set; }

        [DisplayName("Namn")]
        public string Name { get; set; }

        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}
