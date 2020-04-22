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
    public class CVProgrammingLangsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CVProgrammingLangs
        public ActionResult Index()
        {
            var cVProgrammingLangs = db.CVProgrammingLangs.Include(c => c.CV);
            return View(cVProgrammingLangs.ToList());
        }

        // GET: CVProgrammingLangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CVProgrammingLang cVProgrammingLang = db.CVProgrammingLangs.Find(id);
            if (cVProgrammingLang == null)
            {
                return HttpNotFound();
            }
            return View(cVProgrammingLang);
        }

        // GET: CVProgrammingLangs/Create
        public ActionResult Create()
        {
            ViewBag.CVID = new SelectList(db.CVs, "CVID", "Objective");
            return View();
        }

        // POST: CVProgrammingLangs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CVID,CVProgrammingLangName,CVProgrammingLangExperience")] CVProgrammingLang cVProgrammingLang)
        {
            if (ModelState.IsValid)
            {
                db.CVProgrammingLangs.Add(cVProgrammingLang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CVID = new SelectList(db.CVs, "CVID", "Objective", cVProgrammingLang.CVID);
            return View(cVProgrammingLang);
        }

        // GET: CVProgrammingLangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CVProgrammingLang cVProgrammingLang = db.CVProgrammingLangs.Find(id);
            if (cVProgrammingLang == null)
            {
                return HttpNotFound();
            }
            ViewBag.CVID = new SelectList(db.CVs, "CVID", "Objective", cVProgrammingLang.CVID);
            return View(cVProgrammingLang);
        }

        // POST: CVProgrammingLangs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CVID,CVProgrammingLangName,CVProgrammingLangExperience")] CVProgrammingLang cVProgrammingLang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cVProgrammingLang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CVID = new SelectList(db.CVs, "CVID", "Objective", cVProgrammingLang.CVID);
            return View(cVProgrammingLang);
        }

        // GET: CVProgrammingLangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CVProgrammingLang cVProgrammingLang = db.CVProgrammingLangs.Find(id);
            if (cVProgrammingLang == null)
            {
                return HttpNotFound();
            }
            return View(cVProgrammingLang);
        }

        // POST: CVProgrammingLangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CVProgrammingLang cVProgrammingLang = db.CVProgrammingLangs.Find(id);
            db.CVProgrammingLangs.Remove(cVProgrammingLang);
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
