using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Szilveszter_Levente_Artwork.Data;
using Szilveszter_Levente_Artwork.Models;

namespace Szilveszter_Levente_Artwork.Pages.Venues
{
    public class DetailsModel : PageModel
    {
        private readonly Szilveszter_Levente_Artwork.Data.Szilveszter_Levente_ArtworkContext _context;

        public DetailsModel(Szilveszter_Levente_Artwork.Data.Szilveszter_Levente_ArtworkContext context)
        {
            _context = context;
        }

      public Venue Venue { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Venue == null)
            {
                return NotFound();
            }

            var venue = await _context.Venue.FirstOrDefaultAsync(m => m.ID == id);
            if (venue == null)
            {
                return NotFound();
            }
            else 
            {
                Venue = venue;
            }
            return Page();
        }
    }
}
