using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalGradutionProjectAPI.Models;

namespace FinalGradutionProjectAPI.Controllers
{
    public class CVTechnologiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CVTechnologies
        public ActionResult Index()
        {
            var cVTechnologies = db.CVTechnologies.Include(c => c.CV);
            return View(cVTechnologies.ToList());
        }

        // GET: CVTechnologies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CVTechnology cVTechnology = db.CVTechnologies.Find(id);
            if (cVTechnology == null)
            {
                return HttpNotFound();
            }
            return View(cVTechnology);
        }

        // GET: CVTechnologies/Create
        public ActionResult Create()
        {
            ViewBag.CVID = new SelectList(db.CVs, "CVID", "Objective");
            return View();
        }

        // POST: CVTechnologies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CVID,CVTechnologiesName,CVTechnologiesExperience")] CVTechnology cVTechnology)
        {
            if (ModelState.IsValid)
            {
                db.CVTechnologies.Add(cVTechnology);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CVID = new SelectList(db.CVs, "CVID", "Objective", cVTechnology.CVID);
            return View(cVTechnology);
        }

        // GET: CVTechnologies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CVTechnology cVTechnology = db.CVTechnologies.Find(id);
            if (cVTechnology == null)
            {
                return HttpNotFound();
            }
            ViewBag.CVID = new SelectList(db.CVs, "CVID", "Objective", cVTechnology.CVID);
            return View(cVTechnology);
        }

        // POST: CVTechnologies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CVID,CVTechnologiesName,CVTechnologiesExperience")] CVTechnology cVTechnology)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cVTechnology).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CVID = new SelectList(db.CVs, "CVID", "Objective", cVTechnology.CVID);
            return View(cVTechnology);
        }

        // GET: CVTechnologies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CVTechnology cVTechnology = db.CVTechnologies.Find(id);
            if (cVTechnology == null)
            {
                return HttpNotFound();
            }
            return View(cVTechnology);
        }

        // POST: CVTechnologies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CVTechnology cVTechnology = db.CVTechnologies.Find(id);
            db.CVTechnologies.Remove(cVTechnology);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
