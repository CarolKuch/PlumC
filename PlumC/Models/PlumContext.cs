using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PlumC.Models
{
    public class PlumContext : DbContext
    {
        public PlumContext()
        {
        }

        public IDbSet<Doctor> Doctors { get; set; }
    }
}