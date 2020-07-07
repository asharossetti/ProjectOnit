using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service.Data;
using Service.Data.Model;
using Model = Service.Data.Model;

namespace Service.Pages.Cart
{
    public class CreateModel : PageModel
    {
        private readonly Service.Data.ServiceContext _context;

        public CreateModel(Service.Data.ServiceContext context)
        {
            _context = context;
            Products = _context.Products.ToList();
            Locations = _context.Locations.ToList();
            StokPositions = _context.StokPositions.ToList();
            //SelectedChecks = new List<string>();
            //SelectedProductIds = new List<int>();
            //SelectedQuatities = new List<int>();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Model.Cart Cart { get; set; }

        public List<Model.Location> Locations { get; set; }
        public List<Model.StokPosition> StokPositions { get; set; }
        public List<Model.Product> Products { get; set; }


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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        { 
            Cart.Location = _context.Locations.SingleOrDefault(l => l.Id == SelectedLocationId);
            Cart.StokPosition = _context.StokPositions.SingleOrDefault(sp => sp.Id == SelectedStokPositionId);

            var date = DateTimeOffset.Now;
            var rows = new List<Model.Row>();

            int i = 0;
            foreach(var id in SelectedProductIds)
            {
                if (SelectedChecks[i] == "1")
                {
                    rows.Add(new Row
                    {
                        Cart = Cart,
                        CreatedDate = date,
                        LastModifiedDate=date,
                        Product = _context.Products.SingleOrDefault(product => product.Id == id),
                        Quantity = SelectedQuatities[i]
                    });
                }
                i++;
            }
            Cart.CreatedDate = date;
            Cart.LastModifiedDate = date;
            Cart.Rows = rows;

            _context.Carts.Add(Cart);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
