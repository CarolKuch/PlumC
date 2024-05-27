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
using System.Numerics;

namespace PlumC.Controllers
{
    public class OfficeController : Controller
    {
        private PlumContext _db = new PlumContext();

        // GET: Office
        public async Task<ActionResult> Index()
        {
            return View(await _db.Offices.ToListAsync());
        }

        // GET: Office/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Office office = await FindOfficeByIdAsync(id);
            if (office == null)
            {
                return HttpNotFound();
            }
            return View(office);
        }

        // GET: Office/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Office/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,RoomNumber,Floor,MinutesForPatient,FirstConsultationFee,FollowUpConsultationFee")] Office office)
        {
            if (ModelState.IsValid)
            {
                _db.Offices.Add(office);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(office);
        }

        // GET: Office/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Office office = await FindOfficeByIdAsync(id);
            if (office == null)
            {
                return HttpNotFound();
            }
            return View(office);
        }

        // POST: Office/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,RoomNumber,Floor,MinutesForPatient,FirstConsultationFee,FollowUpConsultationFee")] Office office)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(office).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(office);
        }

        // GET: Office/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Office office = await FindOfficeByIdAsync(id);
            if (office == null)
            {
                return HttpNotFound();
            }
            return View(office);
        }

        // POST: Office/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Office office = await FindOfficeByIdAsync(id);
            _db.Offices.Remove(office);
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
        private async Task<Office> FindOfficeByIdAsync(int? id)
        {
            return await _db.Offices.Where(d => d.Id == id).SingleOrDefaultAsync();
        }
    }
}
