namespace Szilveszter_Levente_Artwork.Models
{
    public class ArtworkCategory
    {
        public int ID { get; set; }
        public int ArtworkID { get; set; }
        public Artwork Artwork { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
