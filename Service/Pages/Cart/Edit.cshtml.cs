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
namespace Service.Pages.Cart
{
    public class EditModel : PageModel
    {
        private readonly Service.Data.ServiceContext _context;

        public EditModel(Service.Data.ServiceContext context)
        {
            _context = context;
            Products = _context.Products.ToList();
            Locations = _context.Locations.ToList();
            StokPositions = _context.StokPositions.ToList();

        }

        [BindProperty]
        public Model.Cart Cart { get; set; }

        public List<Model.Location> Locations { get; set; }
        public List<Model.StokPosition> StokPositions { get; set; }
        public List<Model.Product> Products { get; set; }


        [BindProperty]
        public int PreSelectedLocationId { get; set; }
        [BindProperty]
        public int PreSelectedStokPositionId { get; set; }
        [BindProperty]
        public List<int> PreSelectedProductIds { get; set; }
        [BindProperty]
        public List<string> PreSelectedChecks { get; set; }
        [BindProperty]
        public List<int> PreSelectedQuatities { get; set; }



        [BindProperty]
        public int SelectedLocationId { get; set; }
        [BindProperty]
        public int SelectedStokPositionId { get; set; }
        [BindProperty]
        public List<int> SelectedProductIds { get; set; }
        [BindProperty]
        public List<string> SelectedChecks { get; set; }
        [BindProperty]
        public List<int> SelectedQuatities { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cart = await _context.Carts.Include(x=>x.Rows).FirstOrDefaultAsync(m => m.Id == id);

            if (Cart != null)
            {
                Cart.Location = _context.Locations.SingleOrDefault(l => l.Id == Cart.Location.Id);

                SelectedLocationId = Cart.Location.Id;
                Cart.StokPosition = _context.StokPositions.SingleOrDefault(sp => sp.Id == Cart.StokPosition.Id);
                SelectedStokPositionId = Cart.StokPosition.Id;
                PreSelectedChecks = new List<string>();
                PreSelectedProductIds = new List<int>();
                PreSelectedQuatities = new List<int>();
                foreach (var product in Products)
                {
                    PreSelectedChecks.Add(Cart.Rows.Any(r=>r.Product.Code == product.Code) ? "checked" : "false");
                    PreSelectedProductIds.Add(product.Id);
                    PreSelectedQuatities.Add(Cart.Rows.Any(r => r.Product.Code == product.Code) ? Cart.Rows.SingleOrDefault(r=>r.Product.Code==product.Code).Qantity : 0);
                }
            }

            if (Cart == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            _context.Attach(Cart).State = EntityState.Modified;

            try
            {
                Cart = await _context.Carts.Include(x => x.Rows).FirstOrDefaultAsync(m => m.Id == Cart.Id);
                Cart.Location = _context.Locations.SingleOrDefault(l => l.Id == SelectedLocationId);
                Cart.StokPosition = _context.StokPositions.SingleOrDefault(sp => sp.Id == SelectedStokPositionId);
                int i = 0;


                foreach (var product in Products)
                {
                    if (SelectedChecks[i] == "1")
                    {
                        if (Cart.Rows.Any(r => r.Product.Code == product.Code))
                        {
                            var row = Cart.Rows.SingleOrDefault(r => r.Product.Code == product.Code);
                            row.Cart = Cart;
                            row.Qantity = SelectedQuatities[i];
                        }
                        else
                        {
                            Cart.Rows.Add(new Row
                            {
                                Cart = Cart,
                                CreatedDate = DateTimeOffset.Now,
                                Product = _context.Products.SingleOrDefault(p => p.Code == product.Code),
                                Qantity = SelectedQuatities[i]
                            });
                        }
                    }
                    else
                    {
                        if (Cart.Rows.Any(r => r.Product.Code == product.Code))
                        { 
                            var toDell = Cart.Rows.SingleOrDefault(x => x.Product.Id == product.Id && x.Cart.Id == Cart.Id);
                            Cart.Rows.Remove(toDell);
                            _context.Rows.Remove(toDell);
                        }
                        else
                        { }
                    }
                    i++;
                }

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartExists(Cart.Id))
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

        private bool CartExists(int id)
        {
            return _context.Carts.Any(e => e.Id == id);
        }
    }
}
