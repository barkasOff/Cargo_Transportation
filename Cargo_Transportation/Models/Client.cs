using System.ComponentModel.DataAnnotations;

namespace Cargo_Transportation.Models
{
    public class Client : User
    {
        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        [MinLength(11)]
        [MaxLength(11)]
        public string PhoneNumber { get; set; }
        [MaxLength(20)]
        public string CompanyName { get; set; }
        public Product Product { get; set; }
    }
}
