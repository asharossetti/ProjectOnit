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
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Model.Cart Cart { get; set; }

        [BindProperty]
        public List<Model.Product> Products { get; set; }

        private List<Model.Product> SelectedProducts { get; set; }

        [BindProperty]
        public List<int> SelectedProductIds { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            SelectedProducts = _context.Products.Where(product=> SelectedProductIds.Contains(product.Id)).ToList();

            var rows = new List<Model.Row>();

            foreach(var selectedProduct in SelectedProducts)
            {
                rows.Add(new Row
                { 
                    Cart= Cart,
                    CreatedDate= DateTimeOffset.Now,
                    Product= selectedProduct
                });
            }
            Cart.CreatedDate = DateTimeOffset.Now;
            Cart.Rows = rows;

            _context.Carts.Add(Cart);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
