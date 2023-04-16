﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Szilveszter_Levente_Artwork.Data;
using Szilveszter_Levente_Artwork.Models;

namespace Szilveszter_Levente_Artwork.Pages.Artists
{
    public class DetailsModel : PageModel
    {
        private readonly Szilveszter_Levente_Artwork.Data.Szilveszter_Levente_ArtworkContext _context;

        public DetailsModel(Szilveszter_Levente_Artwork.Data.Szilveszter_Levente_ArtworkContext context)
        {
            _context = context;
        }

      public Artist Artist { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Artist == null)
            {
                return NotFound();
            }

            var artist = await _context.Artist.FirstOrDefaultAsync(m => m.ID == id);
            if (artist == null)
            {
                return NotFound();
            }
            else 
            {
                Artist = artist;
            }
            return Page();
        }
    }
}
