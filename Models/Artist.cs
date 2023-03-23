using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Szilveszter_Levente_Artwork.Models
{
    public class Artist
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public ICollection<Artwork>? Artworks { get; set; }
    }
}
