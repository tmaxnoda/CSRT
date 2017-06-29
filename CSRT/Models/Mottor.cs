using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CSRT.Models
{
    public class Mottor
    {

        //public Mottor()
        //{
        //    VehicleMovements = new HashSet<VehicleMovement>();
        //}
        [Key]
        public int Id { get; set; }
        [Required]
        public int MottorModelId { get; set; }
        [ForeignKey("Id")]
        public  MottorModel MottorModel { get; set; }

        [Required]
        public int VehicleId { get; set; }

        [ForeignKey("Id")]
        public Vehicle Vehicle { get; set; }

        [Required]
        public bool IsAvailable { get; set; }
        [Required]
        public string PlateNumber { get; set; }

        [Required]
        public int DepartmentId { get; set; }
        [ForeignKey("Id")]
        public Department Department { get; set; }

        public DateTime DateCreated { get; set; }
        //public virtual ICollection<VehicleMovement> VehicleMovements { get; set; }

    }
}