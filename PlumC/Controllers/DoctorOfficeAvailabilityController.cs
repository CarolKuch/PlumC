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

namespace PlumC.Controllers
{
    public class DoctorOfficeAvailabilityController : Controller
    {
        private PlumContext _db = new PlumContext();

        // GET: DoctorOfficeAvailability
        public async Task<ActionResult> Index()
        {
            var doctorOfficeAvailabilities = _db.DoctorOfficeAvailabilities.Include(d => d.Doctor).Include(d => d.Office);
            return View(await doctorOfficeAvailabilities.ToListAsync());
        }

        // GET: DoctorOfficeAvailability/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorOfficeAvailability doctorOfficeAvailability = await FindAvailabilityByIdAsync(id);
            if (doctorOfficeAvailability == null)
            {
                return HttpNotFound();
            }
            return View(doctorOfficeAvailability);
        }

        // GET: DoctorOfficeAvailability/Create
        public ActionResult Create()
        {
            ViewBag.DoctorId = new SelectList(_db.Doctors, "Id", "Name");
            ViewBag.OfficeId = new SelectList(_db.Offices, "Id", "Id");
            return View();
        }

        // POST: DoctorOfficeAvailability/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,OfficeId,DoctorId,DayOfWeek,TimeStart,TimeEnd,IsDoctorAvailable")] DoctorOfficeAvailability doctorOfficeAvailability)
        {
            if (ModelState.IsValid)
            {
                _db.DoctorOfficeAvailabilities.Add(doctorOfficeAvailability);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DoctorId = new SelectList(_db.Doctors, "Id", "Name", doctorOfficeAvailability.DoctorId);
            ViewBag.OfficeId = new SelectList(_db.Offices, "Id", "Id", doctorOfficeAvailability.OfficeId);
            return View(doctorOfficeAvailability);
        }

        // GET: DoctorOfficeAvailability/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorOfficeAvailability doctorOfficeAvailability = await FindAvailabilityByIdAsync(id);
            if (doctorOfficeAvailability == null)
            {
                return HttpNotFound();
            }
            ViewBag.DoctorId = new SelectList(_db.Doctors, "Id", "Name", doctorOfficeAvailability.DoctorId);
            ViewBag.OfficeId = new SelectList(_db.Offices, "Id", "Id", doctorOfficeAvailability.OfficeId);
            return View(doctorOfficeAvailability);
        }

        // POST: DoctorOfficeAvailability/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,OfficeId,DoctorId,DayOfWeek,TimeStart,TimeEnd,IsDoctorAvailable")] DoctorOfficeAvailability doctorOfficeAvailability)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(doctorOfficeAvailability).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DoctorId = new SelectList(_db.Doctors, "Id", "Name", doctorOfficeAvailability.DoctorId);
            ViewBag.OfficeId = new SelectList(_db.Offices, "Id", "Id", doctorOfficeAvailability.OfficeId);
            return View(doctorOfficeAvailability);
        }

        // GET: DoctorOfficeAvailability/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorOfficeAvailability doctorOfficeAvailability = await FindAvailabilityByIdAsync(id);
            if (doctorOfficeAvailability == null)
            {
                return HttpNotFound();
            }
            return View(doctorOfficeAvailability);
        }

        // POST: DoctorOfficeAvailability/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DoctorOfficeAvailability doctorOfficeAvailability = await FindAvailabilityByIdAsync(id);
            _db.DoctorOfficeAvailabilities.Remove(doctorOfficeAvailability);
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
        private async Task<DoctorOfficeAvailability> FindAvailabilityByIdAsync(int? id)
        {
            return await _db.DoctorOfficeAvailabilities.Where(d => d.Id == id).SingleOrDefaultAsync();
        }
    }
}
