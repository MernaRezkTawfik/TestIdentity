using System.ComponentModel.DataAnnotations;

namespace TestIdetity.Models
{
    public class Genre

    {
        public byte Id { get; set; }
        [Required]
        [StringLength(255)]///limit 255 character
        public string Name { get; set; }
        
    }
}