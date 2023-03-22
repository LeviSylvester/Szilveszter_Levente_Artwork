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

        public IList<Artwork> Artwork { get;set; } /*= default!;*/
        public ArtworkData ArtworkD { get; set; }
        public int ArtworkID { get; set; }
        public int CategoryID { get; set; }


        //public async Task OnGetAsync()
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            //if (_context.Artwork != null)
            //{
            /*
                Artwork = await _context.Artwork
                .Include(a=>a.Venue)
                .ToListAsync();
            */
            //}

            ArtworkD = new ArtworkData();

            ArtworkD.Artworks = await _context.Artwork
                .Include(a => a.Venue)
                .Include(a => a.ArtworkCategories)
                    .ThenInclude(a => a.Category)
                .AsNoTracking()
                .OrderBy(a => a.Title)
                .ToListAsync();

            if (id != null)
            {
                ArtworkID = id.Value;
                Artwork artwork = ArtworkD.Artworks
                    .Where(i => i.ID == id.Value).Single();
                ArtworkD.Categories = artwork.ArtworkCategories.Select(s => s.Category);
            }
        }
    }
}
