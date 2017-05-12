using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSRT.Models
{
    public class CarDriver
    {
        public int Id { get; set; }

        [Key, Column(Order = 1)]
        public int CarId { get; set; }
        public Car Car { get; set; }

        [Key, Column(Order = 2)]
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
    }
}