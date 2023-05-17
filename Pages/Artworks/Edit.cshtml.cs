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
    public class EditModel : ArtworkCategoriesPageModel
    {
        private readonly Szilveszter_Levente_Artwork.Data.Szilveszter_Levente_ArtworkContext _context;

        public EditModel(Szilveszter_Levente_Artwork.Data.Szilveszter_Levente_ArtworkContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Artwork? Artwork { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Artwork = await _context.Artwork
                .Include(a => a.Artist)
                .Include(a => a.Venue)
                .Include(a => a.ArtworkCategories)
                    .ThenInclude(a => a.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Artwork == null)
            {
                return NotFound();
            }

            //get checkbox data
            PopulateAssignedCategoryData(_context, Artwork);

            ViewData["ArtistID"] = new SelectList(_context.Artist, "ID", "FullName");
            ViewData["VenueID"] = new SelectList(_context.Venue, "ID", "VenueName");            

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {

            if (id == null)
            {
                return NotFound();
            }

            var artworkToUpdate = await _context.Artwork
                .Include(i => i.Artist)
                .Include(i => i.Venue)
                .Include(i => i.ArtworkCategories)
                    .ThenInclude(i => i.Category)
                .FirstOrDefaultAsync(s => s.ID == id);

            if (artworkToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Artwork>(artworkToUpdate, "Artwork",
                i => i.Title, i => i.ArtistID,
                 i => i.Price, i => i.CompletionDate, i => i.VenueID))
            {
                UpdateArtworkCategories(_context, selectedCategories, artworkToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            //to also add checkbox data when editing an artwork
            UpdateArtworkCategories(_context, selectedCategories, artworkToUpdate);
            PopulateAssignedCategoryData(_context, artworkToUpdate);
            return Page();
        }
    }
}
