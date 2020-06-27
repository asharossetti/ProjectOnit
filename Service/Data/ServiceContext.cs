using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Service.Data.Model;

namespace Service.Data
{
    public class ServiceContext : DbContext
    {
        public ServiceContext (DbContextOptions<ServiceContext> options)
            : base(options)
        {
        }

        public DbSet<Service.Data.Model.Product> Products { get; set; }

        public DbSet<Service.Data.Model.Row> Rows { get; set; }

        public DbSet<Service.Data.Model.Cart> Carts { get; set; }


        public DbSet<Service.Data.Model.StokPosition> StokPositions { get; set; }
        public DbSet<Service.Data.Model.Location> Locations { get; set; }
    }
}
