using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using CSRT.Models;

namespace CSRT.Areas.Security.ViewModels
{
    public class MilageViewModel
    {
        
        public int Id { get; set; }
        public string MilageIn { get; set; }
        public string MilageOut { get; set; }
        public DateTime TimeIn { get; set; }

        public DateTime TimeOut { get; set; }

        public string MilageCovered { get; set; }
        [Required]
        public int VehicleMovementId { get; set; }
       
       
    }
}