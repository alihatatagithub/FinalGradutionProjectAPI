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
    public class CompanyRequestProgrammingLangsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CompanyRequestProgrammingLangs
        public ActionResult Index()
        {
            var companyRequestProgrammingLangs = db.CompanyRequestProgrammingLangs.Include(c => c.CompanyRequest);
            return View(companyRequestProgrammingLangs.ToList());
        }

        // GET: CompanyRequestProgrammingLangs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyRequestProgrammingLang companyRequestProgrammingLang = db.CompanyRequestProgrammingLangs.Find(id);
            if (companyRequestProgrammingLang == null)
            {
                return HttpNotFound();
            }
            return View(companyRequestProgrammingLang);
        }

        // GET: CompanyRequestProgrammingLangs/Create
        public ActionResult Create()
        {
            ViewBag.RequestId = new SelectList(db.CompanyRequests, "RequestId", "CompanyRequestJobTitle");
            return View();
        }

        // POST: CompanyRequestProgrammingLangs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CRPLName,RequestId,CRPLExperience")] CompanyRequestProgrammingLang companyRequestProgrammingLang)
        {
            if (ModelState.IsValid)
            {
                db.CompanyRequestProgrammingLangs.Add(companyRequestProgrammingLang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RequestId = new SelectList(db.CompanyRequests, "RequestId", "CompanyRequestJobTitle", companyRequestProgrammingLang.RequestId);
            return View(companyRequestProgrammingLang);
        }

        // GET: CompanyRequestProgrammingLangs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyRequestProgrammingLang companyRequestProgrammingLang = db.CompanyRequestProgrammingLangs.Find(id);
            if (companyRequestProgrammingLang == null)
            {
                return HttpNotFound();
            }
            ViewBag.RequestId = new SelectList(db.CompanyRequests, "RequestId", "CompanyRequestJobTitle", companyRequestProgrammingLang.RequestId);
            return View(companyRequestProgrammingLang);
        }

        // POST: CompanyRequestProgrammingLangs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CRPLName,RequestId,CRPLExperience")] CompanyRequestProgrammingLang companyRequestProgrammingLang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyRequestProgrammingLang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RequestId = new SelectList(db.CompanyRequests, "RequestId", "CompanyRequestJobTitle", companyRequestProgrammingLang.RequestId);
            return View(companyRequestProgrammingLang);
        }

        // GET: CompanyRequestProgrammingLangs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyRequestProgrammingLang companyRequestProgrammingLang = db.CompanyRequestProgrammingLangs.Find(id);
            if (companyRequestProgrammingLang == null)
            {
                return HttpNotFound();
            }
            return View(companyRequestProgrammingLang);
        }

        // POST: CompanyRequestProgrammingLangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CompanyRequestProgrammingLang companyRequestProgrammingLang = db.CompanyRequestProgrammingLangs.Find(id);
            db.CompanyRequestProgrammingLangs.Remove(companyRequestProgrammingLang);
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
