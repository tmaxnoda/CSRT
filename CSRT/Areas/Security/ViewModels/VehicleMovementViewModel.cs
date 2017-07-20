using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using CSRT.HelperClass;
using CSRT.Models;

namespace CSRT.Areas.Security.ViewModels
{
    public class VehicleMovementViewModel
    {
        public VehicleMovementViewModel() { }

        public VehicleMovementViewModel(VehicleMovement model)
        {
            Id = model.Id;
            MotoId = model.MotoId;
            Moto = model.Moto.PlateNumber;
            DriverId = model.DriverId;
            Driver = model.Driver.Name;
            DepartmentId = model.DepartmentId;
            Department = model.Department.Name;
            NumberOfPeopleGoingOut = model.NumberOfPeopleGoingOut;
            NameOfPeopleGoingOut = model.NameOfPeopleGoingOut;
            TimeOut = model.TimeOut.ToString("HH:mm");
            Date = model.Date.ToString("d MMM yyyy");
            MilageOut = model.MilageOut;
            Purpose = model.Purpose;
            MotoMake = model.Moto.MottorModel.Make;
            MotoModel = model.Moto.MottorModel.Name;
            Destination = model.Destination;
        }
        //[Key]
        public int Id { get; set; }

        [Required]
        public int MotoId { get; set; }
        [Display(Name = "Plate Number")]
        public string  Moto { get; set; }

        public string MotoMake { get; set; }

        public string MotoModel { get; set; }
        [Required]
        public int DriverId { get; set; }
        [Display(Name = "Driver")]
        public string Driver { get; set; }

        [Required]
        public int DepartmentId { get; set; }
        [Display(Name = "Department")]
        public string Department { get; set; }
        [Required]
        [Display(Name = "Number(s) of people going out")]
        public string NumberOfPeopleGoingOut { get; set; }
        [Required]
        [Display(Name = "Names of people going out")]
        public string NameOfPeopleGoingOut { get; set; }
        [Required]
        [Display(Name = "Time")]
        [ValidTime]
        //[DataType(DataType.Time)]
        ////[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        //[RegularExpression(@"^(0[1-9]|1[0-2]):[0-5][0-9] (am|pm|AM|PM)$", ErrorMessage = "Invalid Time.")]
        public string TimeOut { get; set; }
        [Display(Name = "Date")]
        [FutureDate]
        [Required]
     
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public string Date { get; set; }
        [Required]
        [Display(Name = "Milage out(km)")]
        public string MilageOut { get; set; }
        [Required]
        [Display(Name = "Purpose")]
        public string Purpose { get; set; }
        [Required]
        [Display(Name = "Destination")]
        public string Destination { get; set; }
        public ApplicationUser User { get; set; }


        //[Required]
        //[RegularExpression(@"^(0[1-9]|1[0-2]):[0-5][0-9] (am|pm|AM|PM)$", ErrorMessage = "Invalid Time.")]
        //public string timeout
        //{
        //    get
        //    {
        //        return TimeOut.HasValue ? TimeOut.Value.ToString("hh:mm tt") : string.Empty;
        //    }

        //    set
        //    {
        //        TimeOut = DateTime.Parse(value);
        //    }
        //}

        public ICollection<Department> Departments { get; set; }
        public ICollection<Mottor> Mottors { get; set; }
        public ICollection<Driver> Drivers{ get; set; }
        


        public void SelectLists(List<Department> _departments, List<Mottor> _mottorModels, List<Driver> _drivers)
        {
            Departments = _departments;
            Mottors = _mottorModels;
            Drivers = _drivers;
        }

        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}",Date,TimeOut));
        }
    }
}