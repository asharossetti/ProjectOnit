using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Service.Data;
using Service.Data.Model;
using Model = Service.Data.Model;
namespace Service.Pages.Cart
{
    public class IndexModel : PageModel
    {
        private readonly Service.Data.ServiceContext _context;

        public IndexModel(Service.Data.ServiceContext context)
        {
            _context = context;
        }

        public IList<Model.Cart> Cart { get;set; }
        public Model.Product Product { get; set; }
        public Model.Row Row { get; set; }
        public async Task OnGetAsync()
        {
            Cart = await _context.Carts
                .Include(x=>x.StokPosition)
                .Include(x=>x.Location)
                .Include(x=>x.Rows)
                .ThenInclude(x=>x.Product)
                .ToListAsync();

        }
    }
}
