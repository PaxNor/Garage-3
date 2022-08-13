using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Garage_3.Models;

namespace Garage_3.Data
{
    public class Garage_3Context : DbContext
    {
        public Garage_3Context (DbContextOptions<Garage_3Context> options)
            : base(options)
        {
        }

        public DbSet<Garage_3.Models.Member> Member { get; set; } = default!;

        public DbSet<Garage_3.Models.Vehicle>? Vehicle { get; set; }

        public DbSet<Garage_3.Models.VehicleType>? VehicleType { get; set; }

        public DbSet<Garage_3.Models.Parking>? Parkings { get; set; }
    }
}
