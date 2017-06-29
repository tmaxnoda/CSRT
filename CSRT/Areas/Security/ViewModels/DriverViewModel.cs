using System.ComponentModel.DataAnnotations;
using CSRT.Models;
using Microsoft.Owin.Security.Provider;

namespace CSRT.Areas.Security.ViewModels
{
    public class DriverViewModel
    {
        /// <summary>
        /// Constructor for maping model to view nodel
        /// </summary>
        /// <param name="model"></param>
        public DriverViewModel(Driver model)
        {
            this.Id = model.Id;
            this.Name = model.Name;
            this.IsAvailable = model.IsAvailable;
            this.PhoneNumber = model.PhoneNumber;
        }
        public DriverViewModel() { }
        public int Id { get; set; }
        [Required, Display(Name = "Name"), StringLength(100)]
        public string Name { get; set; }
        [Required, Display(Name = "Status")]
        public bool IsAvailable { get; set; }
        [Required,Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }


        

    }
        //public string Title
        //{
        //    get
        //    {
        //        string dicision = ((Id != 0) ? "Edit Driver" : "Add New Driver");
        //        return dicision;
        //    }
        //}

    
}