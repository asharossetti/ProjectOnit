using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Model = Service.Data.Model;

namespace Service.Pages.Product
{
    public class IndexModel : PageModel
    {
        private readonly Service.Data.ServiceContext _context;

        public IndexModel(Service.Data.ServiceContext context)
        {
            _context = context;
        }

        public IList<Model.Product> Product { get;set; }

        public async Task OnGetAsync()
        {
            Product = await _context.Products.ToListAsync();
        }
    }
}
