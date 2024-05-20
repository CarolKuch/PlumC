using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlumC.Models
{
    public class Specialization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Doctor> Doctors { get; set; } = Enumerable.Empty<Doctor>();
    }
}