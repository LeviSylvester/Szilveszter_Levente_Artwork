namespace Szilveszter_Levente_Artwork.Models
{
    public class ArtworkData
    {

        public IEnumerable<Artwork> Artworks { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<ArtworkCategory> ArtworkCategories { get; set; }

    }
}
