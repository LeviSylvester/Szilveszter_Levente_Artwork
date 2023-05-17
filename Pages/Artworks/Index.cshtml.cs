using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Szilveszter_Levente_Artwork.Data;
using Szilveszter_Levente_Artwork.Models;

namespace Szilveszter_Levente_Artwork.Pages.Artworks
{
    public class IndexModel : PageModel
    {
        private readonly Szilveszter_Levente_Artwork.Data.Szilveszter_Levente_ArtworkContext _context;

        public IndexModel(Szilveszter_Levente_Artwork.Data.Szilveszter_Levente_ArtworkContext context)
        {
            _context = context;
        }

        public IList<Artwork> Artwork { get;set; } = default!;
        public ArtworkData ArtworkD { get; set; }
        public int ArtworkID { get; set; }
        public int CategoryID { get; set; }

        public string TitleSort { get; set; }
        public string ArtistSort { get; set; }

        public string CurrentFilter { get; set; }


        public async Task OnGetAsync(int? id, int? categoryID, string sortOrder, string searchString)
        {

            ArtworkD = new ArtworkData();

            TitleSort = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ArtistSort = String.IsNullOrEmpty(sortOrder) ? "artist_desc" : "";

            CurrentFilter = searchString;

            ArtworkD.Artworks = await _context.Artwork
                .Include(a => a.Artist)
                .Include(a => a.Venue)
                .Include(a => a.ArtworkCategories)
                    .ThenInclude(a => a.Category)
                .AsNoTracking()
                .OrderBy(a => a.Title)
                .ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                ArtworkD.Artworks = ArtworkD.Artworks.Where(s => s.Artist.FirstName.Contains(searchString)
                                                               || s.Artist.LastName.Contains(searchString)
                                                               || s.Title.Contains(searchString));
            }

            if (id != null)
            {
                ArtworkID = id.Value;
                Artwork artwork = ArtworkD.Artworks
                    .Where(i => i.ID == id.Value).Single();
                ArtworkD.Categories = artwork.ArtworkCategories.Select(s => s.Category);
            }

            switch (sortOrder)
            {
                case "title_desc":
                    ArtworkD.Artworks = ArtworkD.Artworks.OrderByDescending(s => s.Title);
                    break;
                case "artist_desc":
                    ArtworkD.Artworks = ArtworkD.Artworks.OrderByDescending(s => s.Artist.FullName);
                    break;

            }
        }
    }
}
