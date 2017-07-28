using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using CSRT.Models;
using CSRT.HelperClass;

namespace CSRT.Areas.Security.ViewModels
{
    public class MilageViewModel
    {
        public MilageViewModel() { }

        public MilageViewModel(Milage model)
        {

            Id = model.Id;
            MilageIn =  model.MilageIn == null ? "still on duty" : model.MilageIn;
            MilageOut = model.MilageOut == null? "still on duty" : model.MilageOut;
            TimeIn = model.TimeIn.HasValue?  model.TimeIn.Value.ToString("HH:mm tt") : "Yet to return";
            TimeOut = model.TimeOut.Value.ToString("HH:mm tt");
            MilageCovered = model.MilageCovered ==null? "stil duty" : model.MilageCovered;
            VehicleMovementId = model.VehicleMovementId;
        }
        
        public int Id { get; set; }
        [Display(Name = "Milage in")]
        [Required]
        public string MilageIn { get; set; }
        [Display(Name = "Milage Out")]
        [Required]
        public string MilageOut { get; set; }
        [Display(Name = "Time in")]
        [Required]
        public string TimeIn { get; set; }

        [Display(Name = "Time out")]
        [Required]
        public string TimeOut { get; set; }

        [Display(Name = "Milage Covered")]
        [Required]
        public string MilageCovered { get; set; }
       
        public int VehicleMovementId { get; set; }

        //public DateTime GetDateTime()
        //{
        //    return DateTime.Parse(string.Format("{0}{1}",co,TimeIn));
        //}


    }
}