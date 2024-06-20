using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public DayOfWeek DayOfWeek { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DataType(DataType.Time)]
        public DateTime TimeStart { get; set; }
        [DataType(DataType.Time)]
        public DateTime TimeEnd { get; set; }
        public bool IsDoctorAvailable { get; set; }
    }
}