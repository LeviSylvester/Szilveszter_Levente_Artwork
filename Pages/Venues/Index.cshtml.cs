using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Szilveszter_Levente_Artwork.Data;
using Szilveszter_Levente_Artwork.Models;
using Szilveszter_Levente_Artwork.Models.ViewModels;

namespace Szilveszter_Levente_Artwork.Pages.Venues
{
    public class IndexModel : PageModel
    {
        private readonly Szilveszter_Levente_Artwork.Data.Szilveszter_Levente_ArtworkContext _context;

        public IndexModel(Szilveszter_Levente_Artwork.Data.Szilveszter_Levente_ArtworkContext context)
        {
            _context = context;
        }

        public IList<Venue> Venue { get;set; } /*= default!;*/

        public VenueIndexData VenueData { get; set; }
        public int VenueID { get; set; }
        public int ArtworkID { get; set; }

        public async Task OnGetAsync(int? id, int? ArtworkID)
        {
            VenueData = new VenueIndexData();
            VenueData.Venues = await _context.Venue
                .Include(i => i.Artworks)
                    .ThenInclude(c => c.Artist)
                .OrderBy(i => i.VenueName)
                .ToListAsync();
            if (id != null)
            {
                VenueID = id.Value;
                Venue venue = VenueData.Venues
                .Where(i => i.ID == id.Value).Single();
                VenueData.Artworks = venue.Artworks;
            }
        }
    }
}
