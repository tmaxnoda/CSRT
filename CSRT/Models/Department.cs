using System.Collections.Generic;

namespace CSRT.Models
{
    public class Department
    {
        public Department()
        {
            Cars = new HashSet<Car>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ApplicationUser User { get; set; }
      
        public ICollection<Car> Cars { get; set; }
    }
}