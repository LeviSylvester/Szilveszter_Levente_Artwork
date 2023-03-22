﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Szilveszter_Levente_Artwork.Data;
using Szilveszter_Levente_Artwork.Models;

namespace Szilveszter_Levente_Artwork.Pages.Artworks
{
    public class CreateModel : ArtworkCategoriesPageModel
    {
        private readonly Szilveszter_Levente_Artwork.Data.Szilveszter_Levente_ArtworkContext _context;

        public CreateModel(Szilveszter_Levente_Artwork.Data.Szilveszter_Levente_ArtworkContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["VenueID"] = new SelectList(_context/*.Set<Venue>()*/.Venue, "ID", "VenueName");

            //inserted
            var artwork = new Artwork();
            artwork.ArtworkCategories = new List<ArtworkCategory>();

            PopulateAssignedCategoryData(_context, artwork);
            //

            return Page();
        }

        [BindProperty]
        public Artwork? Artwork { get; set; } /*= default!;*/

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            /*if (!ModelState.IsValid || _context.Artwork == null || Artwork == null)
              {
                  return Page();
              }*/

            /*
            _context.Artwork.Add(Artwork);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
            */

            var newArtwork = new Artwork();
            if (selectedCategories != null)
            {
                newArtwork.ArtworkCategories = new List<ArtworkCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new ArtworkCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newArtwork.ArtworkCategories.Add(catToAdd);
                }
            }

            if (await TryUpdateModelAsync<Artwork>(newArtwork, "Artwork",
                i => i.Title, i => i.Artist,
                 i => i.Price, i => i.CompletionDate, i => i.VenueID))
            {                
                _context.Artwork.Add(newArtwork);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
                
            }

            PopulateAssignedCategoryData(_context, newArtwork);
            return Page();
        }
    }
}
