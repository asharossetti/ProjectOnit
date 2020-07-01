﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service.Data;
using Service.Data.Model;
using Model = Service.Data.Model;

namespace Service.Pages.StokPosition
{
    public class CreateModel : PageModel
    {
        private readonly Service.Data.ServiceContext _context;

        public CreateModel(Service.Data.ServiceContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Model.StokPosition StokPosition { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.StokPositions.Add(StokPosition);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}