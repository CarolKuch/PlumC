using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlumC.Models
{
    public class DoctorOfficeAvailability
    {
        public int Id { get; set; }
        public int OfficeId { get; set; }
        public Office Office { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public string DayOfWeek { get; set; }
        public DateTime TimeStart { get;set; }
        public DateTime TimeEnd { get;set; }
        public bool IsDoctorAvailable { get; set; }
    }
}