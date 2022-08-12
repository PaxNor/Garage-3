namespace Garage_3.Models
{
    public class Parking
    {
        public int Id { get; set; }
        public DateTime ArrivalTime { get; set; }

        public int? VehicleId { get; set; }
    }
}
