using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Szilveszter_Levente_Artwork.Data;
using Szilveszter_Levente_Artwork.Models;

namespace Szilveszter_Levente_Artwork.Pages.Artworks
{
    public class EditModel : PageModel
    {
        private readonly Szilveszter_Levente_Artwork.Data.Szilveszter_Levente_ArtworkContext _context;

        public EditModel(Szilveszter_Levente_Artwork.Data.Szilveszter_Levente_ArtworkContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Artwork Artwork { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null/* || _context.Artwork == null*/)
            {
                return NotFound();
            }

            //var artwork =  await _context.Artwork.FirstOrDefaultAsync(m => m.ID == id);
            Artwork = await _context.Artwork.FirstOrDefaultAsync(m => m.ID == id);

            //if (artwork == null)
            if (Artwork == null)
            {
                return NotFound();
            }

            //Artwork = artwork;
            ViewData["VenueID"] = new SelectList(_context.Set<Venue>(), "ID", "VenueName");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            /*if (!ModelState.IsValid)
            {
                return Page();
            }*/

            _context.Attach(Artwork).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtworkExists(Artwork.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ArtworkExists(int id)
        {
          return (_context.Artwork?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
