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
    public class CompanyRequestGeneralConceptsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CompanyRequestGeneralConcepts
        public ActionResult Index()
        {
            var companyRequestGeneralConcepts = db.CompanyRequestGeneralConcepts.Include(c => c.CompanyRequest);
            return View(companyRequestGeneralConcepts.ToList());
        }

        // GET: CompanyRequestGeneralConcepts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyRequestGeneralConcept companyRequestGeneralConcept = db.CompanyRequestGeneralConcepts.Find(id);
            if (companyRequestGeneralConcept == null)
            {
                return HttpNotFound();
            }
            return View(companyRequestGeneralConcept);
        }

        // GET: CompanyRequestGeneralConcepts/Create
        public ActionResult Create()
        {
            ViewBag.RequestId = new SelectList(db.CompanyRequests, "RequestId", "CompanyRequestJobTitle");
            return View();
        }

        // POST: CompanyRequestGeneralConcepts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RequestId,GeneralConcept")] CompanyRequestGeneralConcept companyRequestGeneralConcept)
        {
            if (ModelState.IsValid)
            {
                db.CompanyRequestGeneralConcepts.Add(companyRequestGeneralConcept);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RequestId = new SelectList(db.CompanyRequests, "RequestId", "CompanyRequestJobTitle", companyRequestGeneralConcept.RequestId);
            return View(companyRequestGeneralConcept);
        }

        // GET: CompanyRequestGeneralConcepts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyRequestGeneralConcept companyRequestGeneralConcept = db.CompanyRequestGeneralConcepts.Find(id);
            if (companyRequestGeneralConcept == null)
            {
                return HttpNotFound();
            }
            ViewBag.RequestId = new SelectList(db.CompanyRequests, "RequestId", "CompanyRequestJobTitle", companyRequestGeneralConcept.RequestId);
            return View(companyRequestGeneralConcept);
        }

        // POST: CompanyRequestGeneralConcepts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RequestId,GeneralConcept")] CompanyRequestGeneralConcept companyRequestGeneralConcept)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyRequestGeneralConcept).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RequestId = new SelectList(db.CompanyRequests, "RequestId", "CompanyRequestJobTitle", companyRequestGeneralConcept.RequestId);
            return View(companyRequestGeneralConcept);
        }

        // GET: CompanyRequestGeneralConcepts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyRequestGeneralConcept companyRequestGeneralConcept = db.CompanyRequestGeneralConcepts.Find(id);
            if (companyRequestGeneralConcept == null)
            {
                return HttpNotFound();
            }
            return View(companyRequestGeneralConcept);
        }

        // POST: CompanyRequestGeneralConcepts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompanyRequestGeneralConcept companyRequestGeneralConcept = db.CompanyRequestGeneralConcepts.Find(id);
            db.CompanyRequestGeneralConcepts.Remove(companyRequestGeneralConcept);
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
