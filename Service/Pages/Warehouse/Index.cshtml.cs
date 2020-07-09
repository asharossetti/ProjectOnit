using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Service.Data.Model;
using Model = Service.Data.Model;

namespace Service.Pages.Warehouse
{
    public class IndexModel : PageModel
    {
        private readonly Service.Data.ServiceContext _context;

        public IndexModel(Service.Data.ServiceContext context)
        {
            _context = context;
        }

        public IList<Warehouse> Warehouses { get; set; }

        public async Task OnGetAsync()
        {
            Warehouses = new List<Warehouse>();
            foreach (var item in _context.Products)
            {
                var warehouse = new Warehouse()
                {
                    Code = item.Code,
                    Description = item.Description,
                };

                var cart = await _context.Carts
                .Where(x => x.Rows.Any(r=>r.Product.Code == item.Code))
                .Select(x =>
                        new WarehouseInfo
                        { 
                            Location= x.Location,
                            SerialNumber= x.SerialNumber,
                            StokPosition= x.StokPosition,
                            Quantity = x.Rows.SingleOrDefault(r=>r.Product.Code==item.Code).Quantity
                        }
                    ).ToListAsync();

                warehouse.CartRows = cart;
                warehouse.TotalQuantity = cart.Sum(x=>x.Quantity);
                if (warehouse.TotalQuantity > 0)
                {
                    Warehouses.Add(warehouse);
                }
            }
            
        }
    }



    public class Warehouse
    {
        public Warehouse()
        {
            CartRows = new List<WarehouseInfo>();
        }
        public int TotalQuantity { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public List<WarehouseInfo> CartRows { get; set; }
    }
    public class WarehouseInfo
    {
        public string SerialNumber { get; set; }
        public StokPosition StokPosition { get; set; }
        public Location Location { get; set; }
        public int Quantity { get; set; }
    }
}
