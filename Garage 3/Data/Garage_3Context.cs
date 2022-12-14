using Garage_3.Models;
using Microsoft.EntityFrameworkCore;

namespace Garage_3.Data
{
    public class Garage_3Context : DbContext
    {
        public Garage_3Context (DbContextOptions<Garage_3Context> options)
            : base(options)
        {
        }

        public DbSet<Garage_3.Models.Member> Member { get; set; } = default!;

        public DbSet<Garage_3.Models.Vehicle> Vehicle => Set<Vehicle>();

        public DbSet<Garage_3.Models.VehicleType> VehicleType { get; set; } = null!;

        public DbSet<Garage_3.Models.Parking> Parking { get; set; }
    }
}
