using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Garage_3.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

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


        public VehicleType VehicleType { get; set; }
        public Parking? Parking { get; set; }
        public int MemberId { get; set; }
    }
}
