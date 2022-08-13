using Garage_3.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Garage_3.ViewModels
{
    public class CheckinViewModel
    {
        public string PersNr { get; set; }

        public string VehicleType { get; set; }

        [RegularExpression(@"[A-z0-9 ]*", ErrorMessage = "Endast siffror och bokstäver")]
        [Required(ErrorMessage = "Ange ett registreringsnummer")]
        [DisplayName("Resistreringsnummer")]
        public string RegNbr { get; set; }

        [DisplayName("Färg")]
        public string Color { get; set; }

        [DisplayName("Märke")]
        public string Brand { get; set; }

        [DisplayName("Modell")]
        public string Model { get; set; }

        [DisplayName("Hjulantal")]
        public int WheelCount { get; set; }   
    }
}
