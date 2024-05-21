using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlumC.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public Doctor Doctor { get; set; }
        public int DoctorId { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DataType(DataType.Time)]
        public DateTime TimeStart { get; set; }
        [DataType(DataType.Time)]
        public DateTime TimeEnd { get; set; }
        public bool IsAvailable { get; set; }
        public Patient Patient { get; set; }    
        public int? PatientId { get; set; }
        public int MinutesForEachPatient { get; set; }
    }
}