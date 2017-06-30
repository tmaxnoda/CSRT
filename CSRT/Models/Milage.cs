using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSRT.Models
{
    public class Milage
    {
       
        [Key]
        public int Id { get; set; }
        public string MilageIn { get; set; }
        public string MilageOut { get; set; }
        public string MilageCovered { get; set; }
        [Required]
        public int VehicleMovementId { get; set; }
        [ForeignKey("VehicleMovementId")]
        public VehicleMovement vehicleMovement{ get; set; }
       
    }
}