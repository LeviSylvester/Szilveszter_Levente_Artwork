using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Szilveszter_Levente_Artwork.Models;

namespace Szilveszter_Levente_Artwork.Data
{
    public class Szilveszter_Levente_ArtworkContext : DbContext
    {
        public Szilveszter_Levente_ArtworkContext (DbContextOptions<Szilveszter_Levente_ArtworkContext> options)
            : base(options)
        {
        }

        public DbSet<Szilveszter_Levente_Artwork.Models.Artwork> Artwork { get; set; } = default!;

        public DbSet<Szilveszter_Levente_Artwork.Models.Venue>? Venue { get; set; }

        public DbSet<Szilveszter_Levente_Artwork.Models.Category>? Category { get; set; }

        public DbSet<Szilveszter_Levente_Artwork.Models.Artist>? Artist { get; set; }
    }
}
