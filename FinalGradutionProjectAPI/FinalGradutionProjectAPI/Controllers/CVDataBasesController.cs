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
    public class CVDataBasesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CVDataBases
        public ActionResult Index()
        {
            var cVDataBases = db.CVDataBases.Include(c => c.CV);
            return View(cVDataBases.ToList());
        }

        // GET: CVDataBases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CVDataBase cVDataBase = db.CVDataBases.Find(id);
            if (cVDataBase == null)
            {
                return HttpNotFound();
            }
            return View(cVDataBase);
        }

        // GET: CVDataBases/Create
        public ActionResult Create()
        {
            ViewBag.CVID = new SelectList(db.CVs, "CVID", "Objective");
            return View();
        }

        // POST: CVDataBases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CVID,CVDataBaseName,CVDataBaseExperience")] CVDataBase cVDataBase)
        {
            if (ModelState.IsValid)
            {
                db.CVDataBases.Add(cVDataBase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CVID = new SelectList(db.CVs, "CVID", "Objective", cVDataBase.CVID);
            return View(cVDataBase);
        }

        // GET: CVDataBases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CVDataBase cVDataBase = db.CVDataBases.Find(id);
            if (cVDataBase == null)
            {
                return HttpNotFound();
            }
            ViewBag.CVID = new SelectList(db.CVs, "CVID", "Objective", cVDataBase.CVID);
            return View(cVDataBase);
        }

        // POST: CVDataBases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CVID,CVDataBaseName,CVDataBaseExperience")] CVDataBase cVDataBase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cVDataBase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CVID = new SelectList(db.CVs, "CVID", "Objective", cVDataBase.CVID);
            return View(cVDataBase);
        }

        // GET: CVDataBases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CVDataBase cVDataBase = db.CVDataBases.Find(id);
            if (cVDataBase == null)
            {
                return HttpNotFound();
            }
            return View(cVDataBase);
        }

        // POST: CVDataBases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CVDataBase cVDataBase = db.CVDataBases.Find(id);
            db.CVDataBases.Remove(cVDataBase);
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
