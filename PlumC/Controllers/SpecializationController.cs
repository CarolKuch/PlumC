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
    public class SpecializationController : Controller
    {
        private PlumContext _db = new PlumContext();

        // GET: Specializations
        public async Task<ActionResult> Index()
        {
            return View(await _db.Specializations.ToListAsync());
        }

        // GET: Specializations/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Specialization specialization = await FindSpecializationByIdAsync(id);
            if (specialization == null)
            {
                return HttpNotFound();
            }
            return View(specialization);
        }

        // GET: Specializations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Specializations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name")] Specialization specialization)
        {
            if (ModelState.IsValid)
            {
                _db.Specializations.Add(specialization);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(specialization);
        }

        // GET: Specializations/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Specialization specialization = await FindSpecializationByIdAsync(id);
            if (specialization == null)
            {
                return HttpNotFound();
            }
            return View(specialization);
        }

        // POST: Specializations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] Specialization specialization)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(specialization).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(specialization);
        }

        // GET: Specializations/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Specialization specialization = await FindSpecializationByIdAsync(id);
            if (specialization == null)
            {
                return HttpNotFound();
            }
            return View(specialization);
        }

        // POST: Specializations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Specialization specialization = await FindSpecializationByIdAsync(id);
            _db.Specializations.Remove(specialization);
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
        private async Task<Specialization> FindSpecializationByIdAsync(int? id)
        {
            return await _db.Specializations.Where(d => d.Id == id).SingleOrDefaultAsync();
        }
    }
}
