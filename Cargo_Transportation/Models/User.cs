using System.ComponentModel.DataAnnotations;

namespace Cargo_Transportation.Models
{
    public class        User
    {
        public int      Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string   Login { get; set; }
        [Required]
        [MaxLength(20)]
        public string   Parol { get; set; }
    }
}
