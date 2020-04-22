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
    public class CVEductionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CVEductions
        public ActionResult Index()
        {
            var cVEductions = db.CVEductions.Include(c => c.CV);
            return View(cVEductions.ToList());
        }

        // GET: CVEductions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CVEduction cVEduction = db.CVEductions.Find(id);
            if (cVEduction == null)
            {
                return HttpNotFound();
            }
            return View(cVEduction);
        }

        // GET: CVEductions/Create
        public ActionResult Create()
        {
            ViewBag.CVID = new SelectList(db.CVs, "CVID", "Objective");
            return View();
        }

        // POST: CVEductions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CVID,UniversityName,Major,FacultyName,Languages")] CVEduction cVEduction)
        {
            if (ModelState.IsValid)
            {
                db.CVEductions.Add(cVEduction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CVID = new SelectList(db.CVs, "CVID", "Objective", cVEduction.CVID);
            return View(cVEduction);
        }

        // GET: CVEductions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CVEduction cVEduction = db.CVEductions.Find(id);
            if (cVEduction == null)
            {
                return HttpNotFound();
            }
            ViewBag.CVID = new SelectList(db.CVs, "CVID", "Objective", cVEduction.CVID);
            return View(cVEduction);
        }

        // POST: CVEductions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CVID,UniversityName,Major,FacultyName,Languages")] CVEduction cVEduction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cVEduction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CVID = new SelectList(db.CVs, "CVID", "Objective", cVEduction.CVID);
            return View(cVEduction);
        }

        // GET: CVEductions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CVEduction cVEduction = db.CVEductions.Find(id);
            if (cVEduction == null)
            {
                return HttpNotFound();
            }
            return View(cVEduction);
        }

        // POST: CVEductions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CVEduction cVEduction = db.CVEductions.Find(id);
            db.CVEductions.Remove(cVEduction);
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
