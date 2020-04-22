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
    public class CVWorkHistoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CVWorkHistories
        public ActionResult Index()
        {
            var cVWorkHistories = db.CVWorkHistories.Include(c => c.CV);
            return View(cVWorkHistories.ToList());
        }

        // GET: CVWorkHistories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CVWorkHistory cVWorkHistory = db.CVWorkHistories.Find(id);
            if (cVWorkHistory == null)
            {
                return HttpNotFound();
            }
            return View(cVWorkHistory);
        }

        // GET: CVWorkHistories/Create
        public ActionResult Create()
        {
            ViewBag.CVID = new SelectList(db.CVs, "CVID", "Objective");
            return View();
        }

        // POST: CVWorkHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CVID,CVWorkHistoryCompanyName,CVWorkHistoryJobTitle,CVWorkHistoryDuration")] CVWorkHistory cVWorkHistory)
        {
            if (ModelState.IsValid)
            {
                db.CVWorkHistories.Add(cVWorkHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CVID = new SelectList(db.CVs, "CVID", "Objective", cVWorkHistory.CVID);
            return View(cVWorkHistory);
        }

        // GET: CVWorkHistories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CVWorkHistory cVWorkHistory = db.CVWorkHistories.Find(id);
            if (cVWorkHistory == null)
            {
                return HttpNotFound();
            }
            ViewBag.CVID = new SelectList(db.CVs, "CVID", "Objective", cVWorkHistory.CVID);
            return View(cVWorkHistory);
        }

        // POST: CVWorkHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CVID,CVWorkHistoryCompanyName,CVWorkHistoryJobTitle,CVWorkHistoryDuration")] CVWorkHistory cVWorkHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cVWorkHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CVID = new SelectList(db.CVs, "CVID", "Objective", cVWorkHistory.CVID);
            return View(cVWorkHistory);
        }

        // GET: CVWorkHistories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CVWorkHistory cVWorkHistory = db.CVWorkHistories.Find(id);
            if (cVWorkHistory == null)
            {
                return HttpNotFound();
            }
            return View(cVWorkHistory);
        }

        // POST: CVWorkHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CVWorkHistory cVWorkHistory = db.CVWorkHistories.Find(id);
            db.CVWorkHistories.Remove(cVWorkHistory);
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
