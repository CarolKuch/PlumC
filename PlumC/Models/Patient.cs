using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlumC.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
    }
}