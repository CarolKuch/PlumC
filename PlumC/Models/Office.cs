using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlumC.Models
{
    public class Office
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public int Floor { get; set; }
        public string Building { get; set; }
        public int? DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int MinutesForPatient { get; set; }
        public int FirstConsultationFee { get; set; }
        public int FollowUpConsultationFee { get; set; }
    }
}