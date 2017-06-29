using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CSRT.Models;

namespace CSRT.Areas.Security.ViewModels
{
    public class VehicleViewModel
    {
        public int Id { get; set; }
        [Required, Display(Name = "Type Of Vehicle"),MaxLength(20)]
        public string Type { get; set; }
        
    }
}