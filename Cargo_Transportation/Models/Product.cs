using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cargo_Transportation.Models
{
    public enum StatusOfProduct
    {
        Current = 0,
        Completed = 1,
        Inpprocessing = 2
    }
    // TODO: bool Warning for glass etc.
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "smallint")]
        public int ProductWeight { get; set; }
        [Required]
        public StatusOfProduct Status { get; set; }
        [Required]
        public bool OutgoingIncoming { get; set; }

        public Product(StatusOfProduct status)
        {
            Status = status;
        }
    }
}
