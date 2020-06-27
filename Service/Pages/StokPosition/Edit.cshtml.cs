using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Service.Data;
using Service.Data.Model;
using Model = Service.Data.Model;

namespace Service.Pages.StokPosition
{
    public class EditModel : PageModel
    {
        private readonly Service.Data.ServiceContext _context;

        public EditModel(Service.Data.ServiceContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Model.StokPosition StokPosition { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StokPosition = await _context.StokPositions.FirstOrDefaultAsync(m => m.Id == id);

            if (StokPosition == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(StokPosition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StokPositionExists(StokPosition.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StokPositionExists(int id)
        {
            return _context.StokPositions.Any(e => e.Id == id);
        }
    }
}
