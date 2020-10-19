using System;
using System.ComponentModel.DataAnnotations;

namespace Cargo_Transportation.Models
{
    public class            Route
    {
        public int          Id { get; set; }
        [MaxLength(10)]
        public int          DeliveryCost { get; set; }
        [Required]
        [MaxLength(50)]
        public string       From { get; set; }
        [Required]
        [MaxLength(50)]
        public string       To { get; set; }
        [Required]
        public bool         Status { get; set; }
        [Required]
        public DateTime     DepartureDate { get; set; }
        [Required]
        public DateTime     ArrivalDate { get; set; }
        public Product      Product { get; set; }
        public int?         CarId { get; set; }
        public Car          Car { get; set; }

        public Route(DateTime departureDate, DateTime arrivalDate)
        {
            DepartureDate = departureDate;
            ArrivalDate = arrivalDate;
        }
    }
}
