using Aeropuerto.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aeropuerto.Data
{
    public class AeroContext: DbContext
    {
        public AeroContext(DbContextOptions<AeroContext> options) : base(options)
        {
        }

        public DbSet<Aeropuerto.Models.ControlVuelos> ControlVuelos { get; set; }
        //public DbSet<ControlVuelos> ControlVuelos { get; set; }
        public DbSet<ControlAterrizaje> ControlAterrizaje { get; set; }
        public DbSet<ControlDespegue> ControlDespegue { get; set; }
        public DbSet<Aerolineas> Aerolineas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ControlVuelos>().ToTable("ControlVuelos");
            modelBuilder.Entity<ControlAterrizaje>().ToTable("ControlAterrizaje");
            modelBuilder.Entity<ControlDespegue>().ToTable("ControlDespegue");
            modelBuilder.Entity<Aerolineas>().ToTable("Aerolineas");

        }

        



    }
}
