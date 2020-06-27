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
    public class IndexModel : PageModel
    {
        private readonly Service.Data.ServiceContext _context;

        public IndexModel(Service.Data.ServiceContext context)
        {
            _context = context;
        }

        public IList<Model.Location> Location { get;set; }

        public async Task OnGetAsync()
        {
            Location = await _context.Locations.ToListAsync();
        }
    }
}
