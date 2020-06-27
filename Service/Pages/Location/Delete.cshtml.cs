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
namespace Service.Pages.Location
{
    public class DeleteModel : PageModel
    {
        private readonly Service.Data.ServiceContext _context;

        public DeleteModel(Service.Data.ServiceContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Model.Location Location { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Location = await _context.Locations.FirstOrDefaultAsync(m => m.Id == id);

            if (Location == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Location = await _context.Locations.FindAsync(id);

            if (Location != null)
            {
                _context.Locations.Remove(Location);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
