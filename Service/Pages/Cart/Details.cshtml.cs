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
    public class DetailsModel : PageModel
    {
        private readonly Service.Data.ServiceContext _context;

        public DetailsModel(Service.Data.ServiceContext context)
        {
            _context = context;
        }

        public Model.Cart Cart { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cart = await _context.Carts.Include(x => x.StokPosition).Include(x => x.Location).FirstOrDefaultAsync(m => m.Id == id);

            if (Cart == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
