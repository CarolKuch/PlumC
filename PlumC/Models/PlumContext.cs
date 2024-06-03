using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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
        public IDbSet<Patient> Patients { get; set; }
        public IDbSet<Appointment> Appointments { get; set; }
        public IDbSet<Specialization> Specializations { get; set; }
        public IDbSet<Office> Offices { get; set; }
        public IDbSet<DoctorOfficeAvailability> DoctorOfficeAvailabilities { get; set;}
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        }
    }
}