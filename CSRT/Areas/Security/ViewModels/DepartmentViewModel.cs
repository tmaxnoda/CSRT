using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CSRT.Models;

namespace CSRT.Areas.Security.ViewModels
{
    public class DepartmentViewModel
    {

        public int Id { get; set; }
        [Required, Display(Name = "Department")]
        public string Name { get; set; }

        //public List<MotorViewModel> Mottors { get; set; }
    }
}