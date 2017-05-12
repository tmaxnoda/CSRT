using System;

namespace CSRT.Models
{
    public class BaseClass
    {
        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }
        public bool SignIn { get; set; }
        public bool SignOut { get; set; }
        public string Remark { get; set; }
    }
}