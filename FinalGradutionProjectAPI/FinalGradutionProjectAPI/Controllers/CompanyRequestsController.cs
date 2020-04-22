﻿using System;
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
    public class CompanyRequestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CompanyRequests
        public ActionResult Index()
        {
            var companyRequests = db.CompanyRequests.Include(c => c.CompanyHR);
            return View(companyRequests.ToList());
        }

        // GET: CompanyRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyRequest companyRequest = db.CompanyRequests.Find(id);
            if (companyRequest == null)
            {
                return HttpNotFound();
            }
            return View(companyRequest);
        }

        // GET: CompanyRequests/Create
        public ActionResult Create()
        {
            ViewBag.CompanyHRID = new SelectList(db.CompanyHRs, "CompanyHRID", "CompanyHRName");
            return View();
        }

        // POST: CompanyRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RequestId,CompanyRequestJobTitle,CompanyRequestJobRequirement,CompanyRequestJobExperience,ProgrammingLanguage,CompanyHRID")] CompanyRequest companyRequest)
        {
            if (ModelState.IsValid)
            {
                db.CompanyRequests.Add(companyRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyHRID = new SelectList(db.CompanyHRs, "CompanyHRID", "CompanyHRName", companyRequest.CompanyHRID);
            return View(companyRequest);
        }

        // GET: CompanyRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyRequest companyRequest = db.CompanyRequests.Find(id);
            if (companyRequest == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyHRID = new SelectList(db.CompanyHRs, "CompanyHRID", "CompanyHRName", companyRequest.CompanyHRID);
            return View(companyRequest);
        }

        // POST: CompanyRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RequestId,CompanyRequestJobTitle,CompanyRequestJobRequirement,CompanyRequestJobExperience,ProgrammingLanguage,CompanyHRID")] CompanyRequest companyRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyHRID = new SelectList(db.CompanyHRs, "CompanyHRID", "CompanyHRName", companyRequest.CompanyHRID);
            return View(companyRequest);
        }

        // GET: CompanyRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyRequest companyRequest = db.CompanyRequests.Find(id);
            if (companyRequest == null)
            {
                return HttpNotFound();
            }
            return View(companyRequest);
        }

        // POST: CompanyRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompanyRequest companyRequest = db.CompanyRequests.Find(id);
            db.CompanyRequests.Remove(companyRequest);
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