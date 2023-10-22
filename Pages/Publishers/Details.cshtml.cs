﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cosma_Cosmin_Lab2.Data;
using Cosma_Cosmin_Lab2.Models;

namespace Cosma_Cosmin_Lab2.Pages.Publishers
{
    public class DetailsModel : PageModel
    {
        private readonly Cosma_Cosmin_Lab2.Data.Cosma_Cosmin_Lab2Context _context;

        public DetailsModel(Cosma_Cosmin_Lab2.Data.Cosma_Cosmin_Lab2Context context)
        {
            _context = context;
        }

      public Publisher Publisher { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Publisher == null)
            {
                return NotFound();
            }

            var publisher = await _context.Publisher.FirstOrDefaultAsync(m => m.ID == id);
            if (publisher == null)
            {
                return NotFound();
            }
            else 
            {
                Publisher = publisher;
            }
            return Page();
        }
    }
}
