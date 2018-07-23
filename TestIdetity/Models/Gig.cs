using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestIdetity.Models
{
    public class Gig
    {
        public int Id { get; set; }
        [Required]
        public string ArtistId { get; set; }
        public ApplicationUser Artist { get; set; }
        [Required]
        [StringLength(255)]
        public string Venue { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]

        public byte GenreId { get; set; }
        public Genre genre { get; set; }
    }
}