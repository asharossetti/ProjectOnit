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

namespace Service.Pages.ProductFromCart
{
    public class IndexModel : PageModel
    {
        private readonly Service.Data.ServiceContext _context;

        public IndexModel(Service.Data.ServiceContext context)
        {
            _context = context;
        }

        public IList<ProductDTO> Products { get; set; }

        public async Task OnGetAsync()
        {
            Products = new List<ProductDTO>();
            foreach (var item in _context.Products)
            {
                var productDto = new ProductDTO()
                {
                    Code = item.Code,
                    Note = item.Note,
                    Description = item.Description,
                };

                var pippo = await _context.Carts
                .Where(x => x.Rows.Any(r=>r.Product.Code == item.Code))
                .Select(x =>
                        new CartRowDTO
                        { 
                            Location= x.Location,
                            SerialNumber= x.SerialNumber,
                            StokPosition= x.StokPosition,
                            Quantity = x.Rows.SingleOrDefault(r=>r.Product.Code==item.Code).Quantity
                        }
                    ).ToListAsync();

                productDto.CartRows = pippo;
                productDto.Quantity = pippo.Sum(x=>x.Quantity);
                Products.Add(productDto);
            }
            
        }
    }



    public class ProductDTO
    {
        public ProductDTO()
        {
            CartRows = new List<CartRowDTO>();
        }
        public int Quantity { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public List<CartRowDTO> CartRows { get; set; }
    }
    public class CartRowDTO
    {
        public string SerialNumber { get; set; }
        public StokPosition StokPosition { get; set; }
        public Location Location { get; set; }
        public int Quantity { get; set; }
    }
}
