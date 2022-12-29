using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Garage_my_version.Models;

namespace Garage_my_version.Data
{
    public class GarageContext : DbContext
    {
        public GarageContext (DbContextOptions<GarageContext> options)
            : base(options)
        {
        }

        public DbSet<Garage_my_version.Models.Vehicle> Vehicle { get; set; } = default!;
    }
}
