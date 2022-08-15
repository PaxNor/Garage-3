using System.ComponentModel;

namespace Garage_3.ViewModels
{
    public class ParkedVehiclesViewModel
    {
        public int Id { get; set; }

        // member
        [DisplayName("Förnamn")]
        public string FirstName { get; set; }

        [DisplayName("Efternamn")]
        public string LastName { get; set; }

        [DisplayName("Personnummer")]
        public string PersNr { get; set; }

        [DisplayName("Parkerad tid")]
        public string ParkedTime { get; set; }

        // vehicle
        [DisplayName("Registreringsnummer")]
        public string RegNr { get; set; }

        [DisplayName("Märke")]
        public string Brand { get; set; }

        [DisplayName("Modell")]
        public string VehicleModel { get; set; }

        [DisplayName("Fordonstyp")]
        public string Type { get; set; }

        [DisplayName("Färg")]
        public string Color { get; set; }

        [DisplayName("Hjulantal")]
        public int WheelCount { get; set; }
    }
}
