using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cargo_Transportation.Models
{
    public class                Car
    {
        public int              Id { get; set; }
        [Required]
        [MaxLength(10)]
        public string           CarNumber { get; set; }
        [Required]
        [MaxLength(50)]
        public string           CarBrand { get; set; }
        [Required]
        [Column(TypeName = "smallint")]
        public int              CarWeight { get; set; }
        [Required]
        [Column(TypeName = "smallint")]
        public int              LiftingCapacity { get; set; }
        public List<Employee>   Drivers { get; set; }
        public List<Route>      Routes { get; set; }

        public Car()
        {
            Drivers = new List<Employee>();
            Routes = new List<Route>();
        }
    }
}
