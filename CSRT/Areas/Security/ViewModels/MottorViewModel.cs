using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using CSRT.Models;

namespace CSRT.Areas.Security.ViewModels
{


    public class MottorViewModel
    {
        public MottorViewModel() { }

        public MottorViewModel(Mottor model)
        {
            this.Id = model.Id;
            this.MottorModelId = model.MottorModel.Id;
            this.MottorModelName = model.MottorModel.Name;
            this.PlateNumber = model.PlateNumber;
            this.IsAvailable = model.IsAvailable;
            this.VehicleId = model.Vehicle.Id;
            this.VehicleName = model.Vehicle.Type;
            this.DepartmentId = model.Department.Id;
            this.DepartmentName = model.Department.Name;
            this.modelMake = model.MottorModel.Make;
            this.DateCreated = DateTime.UtcNow;

            
        }
        
        public int Id { get; set; }
        [Required,Display(Name ="Vehicle Model")]
        public int MottorModelId { get; set; }
        [Display(Name = "Vehicle Model")]
        public string MottorModelName { get; set; }
       
        [Required, Display(Name = "Vehicle Type")]
        public int VehicleId { get; set; }
        [Display(Name = "Vehicle Type")]
        public string VehicleName { get; set; }

        [Required, Display(Name = "Status")]
        public bool IsAvailable { get; set; }
        [Required, Display(Name = "Plate Number")]
        public string PlateNumber { get; set; }

        [Required, Display(Name = "Department")]
        public int DepartmentId { get; set; }
        [Display(Name = "Department")]
        public string DepartmentName { get; set; }

        [Display(Name = "Date Added")]
        public  DateTime DateCreated { get; set; }

        public string modelMake { get; set; }

        public ICollection<Department> Departments { get; set; }
        public ICollection<MottorModel> MottorModels { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }
        public  ICollection<VehicleMovement> VehicleMovements { get; set; }

        public void SelectLists(List<Department> _departments, List<MottorModel> _mottorModels, List<Vehicle> _vehicles)
        {
            Departments = _departments;
            MottorModels = _mottorModels;
            Vehicles = _vehicles;
        }
    }
}