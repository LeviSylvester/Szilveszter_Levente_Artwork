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

        [Display(Name = "Artwork Title")]
        public string Title { get; set; }
        public string Artist { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        //[DataType(DataType.Date)]
        public DateTime CompletionDate { get; set; }

        public int VenueID { get; set; }
        public Venue Venue { get; set; }

        public ICollection<ArtworkCategory> ArtworkCategories { get; set; }

    }
}
