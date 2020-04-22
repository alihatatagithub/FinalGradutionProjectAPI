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
    public class CompanyHRsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CompanyHRs
        public ActionResult Index()
        {
            return View(db.CompanyHRs.ToList());
        }

        // GET: CompanyHRs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyHR companyHR = db.CompanyHRs.Find(id);
            if (companyHR == null)
            {
                return HttpNotFound();
            }
            return View(companyHR);
        }

        // GET: CompanyHRs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompanyHRs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyHRID,CompanyHRName")] CompanyHR companyHR)
        {
            if (ModelState.IsValid)
            {
                db.CompanyHRs.Add(companyHR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(companyHR);
        }

        // GET: CompanyHRs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyHR companyHR = db.CompanyHRs.Find(id);
            if (companyHR == null)
            {
                return HttpNotFound();
            }
            return View(companyHR);
        }

        // POST: CompanyHRs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompanyHRID,CompanyHRName")] CompanyHR companyHR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyHR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(companyHR);
        }

        // GET: CompanyHRs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyHR companyHR = db.CompanyHRs.Find(id);
            if (companyHR == null)
            {
                return HttpNotFound();
            }
            return View(companyHR);
        }

        // POST: CompanyHRs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompanyHR companyHR = db.CompanyHRs.Find(id);
            db.CompanyHRs.Remove(companyHR);
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
