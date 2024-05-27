using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlumC.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int SpecializationId { get; set; }
        public Specialization Specialization { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
        public IEnumerable<Office> Offices { get; set; }
    }
}