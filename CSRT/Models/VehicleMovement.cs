using System.ComponentModel.DataAnnotations;

namespace CSRT.Models
{
    public class VehicleMovement : BaseClass
    {
        [Key]
        public int Id { get; set; }
        [Key]
        public int CarId { get; set; }
        public Car Car { get; set; }
        [Key]
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
        [Key]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public string NumberOfPeopleGoingOut { get; set; }
        public string NameOfPeopleGoingOut { get; set; }




    }
}