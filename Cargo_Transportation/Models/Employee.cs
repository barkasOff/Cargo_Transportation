using System.ComponentModel.DataAnnotations;

namespace Cargo_Transportation.Models
{
    public class        Employee : User
    {
        [Required]
        [MaxLength(50)]
        public string   FullName { get; set; }
        [Required]
        [MaxLength(50)]
        public string   Email { get; set; }
        [Required]
        [MinLength(11)]
        [MaxLength(11)]
        public string   PhoneNumber { get; set; }
        [Required]
        public int      Salary { get; set; }
        [Required]
        public string   Position { get; set; }
        [Required]
        public string   Task { get; set; }
        public int?     CarId { get; set; }
        public Car      Car { get; set; }
    }
}
