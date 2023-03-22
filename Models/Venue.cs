namespace Szilveszter_Levente_Artwork.Models
{
    public class Venue
    {
        public int ID { get; set; }
        public string VenueName { get; set; }
        public ICollection<Artwork>? Artworks { get; set; } //navigation property
    }
}
