using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CSRT.Models
{
    public class Department
    {
        public Department()
        {
            Mottors = new HashSet<Mottor>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Mottor> Mottors { get; set; }
       
    }
}