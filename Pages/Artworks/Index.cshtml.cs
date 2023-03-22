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

        public async Task OnGetAsync()
        {
            //if (_context.Artwork != null)
            //{
                Artwork = await _context.Artwork
                .Include(a=>a.Venue)
                .ToListAsync();
            //}
        }
    }
}
