﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TaxpayerLibrary.Data;
using TaxpayerLibrary.Models;


namespace TaxpayerValidation.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly Context _context;

        public DetailsModel(Context context)
        {
            _context = context;
        }

        public Taxpayer Taxpayer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxpayer = await _context.Taxpayer.FirstOrDefaultAsync(m => m.Id == id);
            if (taxpayer == null)
            {
                return NotFound();
            }
            else
            {
                Taxpayer = taxpayer;
            }
            return Page();
        }
    }
}
