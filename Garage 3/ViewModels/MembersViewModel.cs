using System.ComponentModel;

namespace Garage_3.ViewModels
{
    public class MembersViewModel
    {
        // member
        [DisplayName("Förnamn")]
        public string FirstName { get; set; }
        [DisplayName("Efternamn")]
        public string LastName { get; set; }
        [DisplayName("Personnummer")]
        public string PersonNumber { get; set; }

        // meta
        [DisplayName("Antal Fordon")]
        public int NumberOfVehicles { get; set; }
        [DisplayName("Parkerad")]
        public string IsParked { get; set; }

        // vehicle
        [DisplayName("Registreringsnummer")]
        public string RegNbr { get; set; }
        [DisplayName("Märke")]
        public string Brand { get; set; }
        [DisplayName("Modell")]
        public string Model { get; set; }
        [DisplayName("Fordonstyp")]
        public string Type { get; set; }
        [DisplayName("Färg")]
        public string Color { get; set; }
        [DisplayName("Hjulantal")]
        public string WheelCount { get; set; }
    }
}
