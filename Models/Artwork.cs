using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Szilveszter_Levente_Artwork.Models
{
    public class Artwork
    {

        public int ID { get; set; }

        [Required, StringLength(150, MinimumLength = 1)]
        [Display(Name = "Artwork Title")]
        public string Title { get; set; }

        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Numele autorului trebuie sa fie de forma 'Prenume Nume'"), 
            Required, StringLength(50, MinimumLength = 3)]
        //^ marks the beginning of the character string
        //[A-Z][a-z]+ the first name - a capital letter followed by any number of lowercase letters
        //\s space
        //[A-Z][a-z]+ the last name - a capital letter followed by any number of lowercase letters
        //$ marks the end of the character string
        public int ArtistID { get; set; }
        public Artist Artist { get; set; }

        [Range(1, 9999)]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime CompletionDate { get; set; }

        public int VenueID { get; set; }
        public Venue Venue { get; set; }

        public ICollection<ArtworkCategory> ArtworkCategories { get; set; }

    }
}
