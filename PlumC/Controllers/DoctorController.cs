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
using Microsoft.EntityFrameworkCore;

namespace PlumC.Controllers
{
    public class DoctorController : Controller
    {
        private PlumContext _db = new PlumContext();

        // GET: Doctor
        public async Task<ActionResult> Index()
        {
            return View(await _db.Doctors.ToListAsync());
        }

        // GET: Doctor/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = await _db.Doctors.Where(x => x.Id == id).SingleOrDefaultAsync();
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // GET: Doctor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Doctor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Surname,Major")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _db.Doctors.Add(doctor);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(doctor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
