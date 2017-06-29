using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSRT.Models
{
    public class MottoDriver
    {
        public MottoDriver()
        {
            Date =  DateTime.UtcNow;
        }
        public int Id { get; set; }

        [Key, Column(Order = 1)]
        public int MotoId { get; set; }
        public Mottor Moto { get; set; }

        [Key, Column(Order = 2)]
        public int DriverId { get; set; }
        public Driver Driver { get; set; }

        public DateTime Date { get; set; }
    }
}