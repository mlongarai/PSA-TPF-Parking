using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Parking.business;

namespace Parking.Models
{
    public class ParkingContext : DbContext
    {
        public ParkingContext(DbContextOptions<ParkingContext> options)
            : base(options)
        {
        }

        public DbSet<Ticket> Parking { get; set; }

        public static readonly LoggerFactory FabricaLogger = new LoggerFactory(new[] { new
ConsoleLoggerProvider((_, __) => true, true) });
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            .UseLoggerFactory(FabricaLogger)

           .UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Parking;Trusted_Connection=True;");
        }
    }
}
