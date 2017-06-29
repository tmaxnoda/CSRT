using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSRT.Models
{
    public class VehicleMovement
    {
        [Key]
        public int Id { get; set; }
       
        [Required]
        public int MotoId { get; set; }
        [ForeignKey("Id")]
        public Mottor Moto { get; set; }
       
        [Required]
        public int DriverId { get; set; }
        [ForeignKey("Id")]
        public Driver Driver { get; set; }
       
        [Required]
        public int DepartmentId { get; set; }
        [ForeignKey("Id")]
        public Department Department { get; set; }
        [Required]
        public string NumberOfPeopleGoingOut { get; set; }
        [Required]
        public string NameOfPeopleGoingOut { get; set; }
        [Required]
        public DateTime TimeOut { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public string MilageOut { get; set; }
        [Required]
        public string Purpose { get; set; }
        [Required]
        public string Destination { get; set; }
        public ApplicationUser User { get; set; }
        




    }
}