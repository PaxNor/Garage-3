using Garage_3.Models;

namespace Garage_3.ViewModels
{
    public class ParkedVehiclesViewModel
    {
        // member

        public IEnumerable<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersNr { get; set; }

        public string ParkedTime { get; set; }

        // vehicle
        public string RegNr { get; set; }
        public string Brand { get; set; }
        public string VehicleModel { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
        public int WheelCount { get; set; }
    }
}
