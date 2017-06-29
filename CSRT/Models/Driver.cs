using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CSRT.Models
{
    public class Driver
    {
        public Driver()
        {
            CarDrivers = new HashSet<MottoDriver>();
        }

        //public Driver()
        //{
            
        //}
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool IsAvailable { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
        public virtual ICollection<MottoDriver> CarDrivers { get; set; }

    }
}