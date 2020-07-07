using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Data.Model
{
    public static class IntialDataEntry
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ServiceContext(serviceProvider.GetRequiredService<DbContextOptions<ServiceContext>>()))
            {
                // Look for any movies.
                if (context.Locations.Any() && context.StokPositions.Any() && context.Products.Any())
                {
                    return;   // DB has been seeded
                }
                context.Locations.AddRange(
                   new Location { Code = "MD2" },
                   new Location { Code = "MD3" }
                   );

                context.StokPositions.AddRange(
                   new StokPosition { Code = "AS1" },
                   new StokPosition { Code = "AS2" }
                   );

                context.Products.AddRange(
                    new Product { Code = "BT1000", Description = "Batteria 1000" },
                    new Product { Code= "BT2000", Description= "Batteria 2000", Note= "Maneggiare con cura e con l’utilizzo di guanti." },
                    new Product { Code= "MTH30", Description= "Montante H30", Note = "Montante utilizzato in carrelli di color giallo e nero."},
                    new Product { Code= "MTH45", Description= "Montante H45" },
                    new Product { Code= "FR343", Description= "Forca 343", Note = "Forca allungabile" },
                    new Product { Code ="SR3", Description= "Sirena 3", Note = "Rumorosa e adatta ad ambienti aperti" }
                    );

                context.SaveChanges();
            }
        }
    }
}
