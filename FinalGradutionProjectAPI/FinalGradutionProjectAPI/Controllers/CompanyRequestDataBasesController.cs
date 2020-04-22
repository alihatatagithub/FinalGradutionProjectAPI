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
    public class CompanyRequestDataBasesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CompanyRequestDataBases
        public ActionResult Index()
        {
            var companyRequestDataBases = db.CompanyRequestDataBases.Include(c => c.CompanyRequest);
            return View(companyRequestDataBases.ToList());
        }

        // GET: CompanyRequestDataBases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyRequestDataBase companyRequestDataBase = db.CompanyRequestDataBases.Find(id);
            if (companyRequestDataBase == null)
            {
                return HttpNotFound();
            }
            return View(companyRequestDataBase);
        }

        // GET: CompanyRequestDataBases/Create
        public ActionResult Create()
        {
            ViewBag.RequestId = new SelectList(db.CompanyRequests, "RequestId", "CompanyRequestJobTitle");
            return View();
        }

        // POST: CompanyRequestDataBases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RequestId,CompanyRequestDataBaseName,CompanyRequestDataBaseExperience")] CompanyRequestDataBase companyRequestDataBase)
        {
            if (ModelState.IsValid)
            {
                db.CompanyRequestDataBases.Add(companyRequestDataBase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RequestId = new SelectList(db.CompanyRequests, "RequestId", "CompanyRequestJobTitle", companyRequestDataBase.RequestId);
            return View(companyRequestDataBase);
        }

        // GET: CompanyRequestDataBases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyRequestDataBase companyRequestDataBase = db.CompanyRequestDataBases.Find(id);
            if (companyRequestDataBase == null)
            {
                return HttpNotFound();
            }
            ViewBag.RequestId = new SelectList(db.CompanyRequests, "RequestId", "CompanyRequestJobTitle", companyRequestDataBase.RequestId);
            return View(companyRequestDataBase);
        }

        // POST: CompanyRequestDataBases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RequestId,CompanyRequestDataBaseName,CompanyRequestDataBaseExperience")] CompanyRequestDataBase companyRequestDataBase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyRequestDataBase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RequestId = new SelectList(db.CompanyRequests, "RequestId", "CompanyRequestJobTitle", companyRequestDataBase.RequestId);
            return View(companyRequestDataBase);
        }

        // GET: CompanyRequestDataBases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyRequestDataBase companyRequestDataBase = db.CompanyRequestDataBases.Find(id);
            if (companyRequestDataBase == null)
            {
                return HttpNotFound();
            }
            return View(companyRequestDataBase);
        }

        // POST: CompanyRequestDataBases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompanyRequestDataBase companyRequestDataBase = db.CompanyRequestDataBases.Find(id);
            db.CompanyRequestDataBases.Remove(companyRequestDataBase);
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
