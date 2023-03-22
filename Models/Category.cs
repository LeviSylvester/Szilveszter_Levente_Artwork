namespace Szilveszter_Levente_Artwork.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<ArtworkCategory>? ArtworkCategories { get; set; }
    }
}
