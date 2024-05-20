using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PlumC.Models;
using Microsoft.Ajax.Utilities;

namespace PlumC.Controllers
{
    public class AppointmentController : Controller
    {
        private PlumContext _db = new PlumContext();

        // GET: Appointment
        public async Task<ActionResult> Index()
        {
            var appointments = _db.Appointments.Include(a => a.Doctor).Include(a => a.Patient);
            return View(await appointments.ToListAsync());
        }

        // GET: Appointment/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = await FindAppointmentByIdAsync(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // GET: Appointment/Create
        public ActionResult Create()
        {
            ViewBag.DoctorId = new SelectList(_db.Doctors, "Id", "Name");
            ViewBag.PatientId = new SelectList(_db.Patients, "Id", "Name");
            return View();
        }

        // POST: Appointment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,DoctorId,Date,Time,PatientId ")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                appointment.Time = appointment.Time.ToUniversalTime();
                appointment.IsAvailable = appointment.PatientId.HasValue ? false : true;
                _db.Appointments.Add(appointment);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DoctorId = new SelectList(_db.Doctors, "Id", "Name", appointment.DoctorId);
            ViewBag.PatientId = new SelectList(_db.Patients, "Id", "Name", appointment.PatientId);
            return View(appointment);
        }

        // GET: Appointment/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = await FindAppointmentByIdAsync(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            ViewBag.DoctorId = new SelectList(_db.Doctors, "Id", "Name", appointment.DoctorId);
            ViewBag.PatientId = new SelectList(_db.Patients, "Id", "Name", appointment.PatientId);
            return View(appointment);
        }

        // POST: Appointment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,DoctorId,DateTime,IsAvailable,PatientId")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(appointment).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DoctorId = new SelectList(_db.Doctors, "Id", "Name", appointment.DoctorId);
            ViewBag.PatientId = new SelectList(_db.Patients, "Id", "Name", appointment.PatientId);
            return View(appointment);
        }

        // GET: Appointment/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = await FindAppointmentByIdAsync(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // POST: Appointment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Appointment appointment = await FindAppointmentByIdAsync(id);
            _db.Appointments.Remove(appointment);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private async Task<Appointment> FindAppointmentByIdAsync(int? id)
        {
            return await _db.Appointments.Where(d => d.Id == id).SingleOrDefaultAsync();
        }
    }
}
