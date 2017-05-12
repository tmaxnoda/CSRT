using System.Collections.Generic;

namespace CSRT.Models
{
    public class Driver
    {
        public Driver()
        {
            CarDrivers = new HashSet<CarDriver>();
        } 
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAvailable { get; set; }
        public ICollection<CarDriver> CarDrivers { get; set; }

    }
}