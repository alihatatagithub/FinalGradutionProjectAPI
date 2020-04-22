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
    public class CVGeneralConceptsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CVGeneralConcepts
        public ActionResult Index()
        {
            var cVGeneralConcepts = db.CVGeneralConcepts.Include(c => c.CV);
            return View(cVGeneralConcepts.ToList());
        }

        // GET: CVGeneralConcepts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CVGeneralConcept cVGeneralConcept = db.CVGeneralConcepts.Find(id);
            if (cVGeneralConcept == null)
            {
                return HttpNotFound();
            }
            return View(cVGeneralConcept);
        }

        // GET: CVGeneralConcepts/Create
        public ActionResult Create()
        {
            ViewBag.CVID = new SelectList(db.CVs, "CVID", "Objective");
            return View();
        }

        // POST: CVGeneralConcepts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CVID,CVGeneralConcepts")] CVGeneralConcept cVGeneralConcept)
        {
            if (ModelState.IsValid)
            {
                db.CVGeneralConcepts.Add(cVGeneralConcept);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CVID = new SelectList(db.CVs, "CVID", "Objective", cVGeneralConcept.CVID);
            return View(cVGeneralConcept);
        }

        // GET: CVGeneralConcepts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CVGeneralConcept cVGeneralConcept = db.CVGeneralConcepts.Find(id);
            if (cVGeneralConcept == null)
            {
                return HttpNotFound();
            }
            ViewBag.CVID = new SelectList(db.CVs, "CVID", "Objective", cVGeneralConcept.CVID);
            return View(cVGeneralConcept);
        }

        // POST: CVGeneralConcepts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CVID,CVGeneralConcepts")] CVGeneralConcept cVGeneralConcept)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cVGeneralConcept).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CVID = new SelectList(db.CVs, "CVID", "Objective", cVGeneralConcept.CVID);
            return View(cVGeneralConcept);
        }

        // GET: CVGeneralConcepts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CVGeneralConcept cVGeneralConcept = db.CVGeneralConcepts.Find(id);
            if (cVGeneralConcept == null)
            {
                return HttpNotFound();
            }
            return View(cVGeneralConcept);
        }

        // POST: CVGeneralConcepts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CVGeneralConcept cVGeneralConcept = db.CVGeneralConcepts.Find(id);
            db.CVGeneralConcepts.Remove(cVGeneralConcept);
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
