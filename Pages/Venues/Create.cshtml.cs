using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Szilveszter_Levente_Artwork.Data;
using Szilveszter_Levente_Artwork.Models;

namespace Szilveszter_Levente_Artwork.Pages.Venues
{
    public class CreateModel : PageModel
    {
        private readonly Szilveszter_Levente_Artwork.Data.Szilveszter_Levente_ArtworkContext _context;

        public CreateModel(Szilveszter_Levente_Artwork.Data.Szilveszter_Levente_ArtworkContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Venue Venue { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Venue == null || Venue == null)
            {
                return Page();
            }

            _context.Venue.Add(Venue);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
