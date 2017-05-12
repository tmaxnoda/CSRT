using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CSRT.Models
{
    public class Car
    {
        public Car()
        {
            CarDrivers = new HashSet<CarDriver>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string VehicleNumber { get; set; }
        public string CarStatus { get; set; }
        public bool IsAvailable { get; set; }

        public ICollection<CarDriver> CarDrivers { get; set; }
        [Key]
        public int MilageId { get; set; }
        public Milage Milage { get; set; }
    }
}