using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CSRT.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
    }
}