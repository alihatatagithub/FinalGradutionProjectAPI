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
    public class CompanyRequestTechnologiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CompanyRequestTechnologies
        public ActionResult Index()
        {
            var companyRequestTechnologies = db.CompanyRequestTechnologies.Include(c => c.CompanyRequest);
            return View(companyRequestTechnologies.ToList());
        }

        // GET: CompanyRequestTechnologies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyRequestTechnology companyRequestTechnology = db.CompanyRequestTechnologies.Find(id);
            if (companyRequestTechnology == null)
            {
                return HttpNotFound();
            }
            return View(companyRequestTechnology);
        }

        // GET: CompanyRequestTechnologies/Create
        public ActionResult Create()
        {
            ViewBag.RequestId = new SelectList(db.CompanyRequests, "RequestId", "CompanyRequestJobTitle");
            return View();
        }

        // POST: CompanyRequestTechnologies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RequestId,CompanyRequestTecnologiesName,CompanyRequestTecnologiesExperience")] CompanyRequestTechnology companyRequestTechnology)
        {
            if (ModelState.IsValid)
            {
                db.CompanyRequestTechnologies.Add(companyRequestTechnology);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RequestId = new SelectList(db.CompanyRequests, "RequestId", "CompanyRequestJobTitle", companyRequestTechnology.RequestId);
            return View(companyRequestTechnology);
        }

        // GET: CompanyRequestTechnologies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyRequestTechnology companyRequestTechnology = db.CompanyRequestTechnologies.Find(id);
            if (companyRequestTechnology == null)
            {
                return HttpNotFound();
            }
            ViewBag.RequestId = new SelectList(db.CompanyRequests, "RequestId", "CompanyRequestJobTitle", companyRequestTechnology.RequestId);
            return View(companyRequestTechnology);
        }

        // POST: CompanyRequestTechnologies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RequestId,CompanyRequestTecnologiesName,CompanyRequestTecnologiesExperience")] CompanyRequestTechnology companyRequestTechnology)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyRequestTechnology).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RequestId = new SelectList(db.CompanyRequests, "RequestId", "CompanyRequestJobTitle", companyRequestTechnology.RequestId);
            return View(companyRequestTechnology);
        }

        // GET: CompanyRequestTechnologies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyRequestTechnology companyRequestTechnology = db.CompanyRequestTechnologies.Find(id);
            if (companyRequestTechnology == null)
            {
                return HttpNotFound();
            }
            return View(companyRequestTechnology);
        }

        // POST: CompanyRequestTechnologies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompanyRequestTechnology companyRequestTechnology = db.CompanyRequestTechnologies.Find(id);
            db.CompanyRequestTechnologies.Remove(companyRequestTechnology);
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
