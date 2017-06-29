using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CSRT.Areas.Security.ViewModels
{
    public class MottorModelViewModel
    {
       
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Total { get; set; }
        //[Required]
        public DateTime Date { get; set; }

    }
}