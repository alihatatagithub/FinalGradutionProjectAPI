using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using FinalGradutionProjectAPI.Models;

namespace FinalGradutionProjectAPI.Controllers
{
    [Authorize(Roles = "CompanyRole")]
    public class CompanyHRController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/CompanyHR
        public IQueryable<CompanyHR> GetCompanyHRs()
        {
            return db.CompanyHRs;
        }

        // GET: api/CompanyHR/5
        [ResponseType(typeof(CompanyHR))]
        public IHttpActionResult GetCompanyHR(int id)
        {
            CompanyHR companyHR = db.CompanyHRs.Find(id);
            if (companyHR == null)
            {
                return NotFound();
            }

            return Ok(companyHR);
        }

        // PUT: api/CompanyHR/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCompanyHR(int id, CompanyHR companyHR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != companyHR.CompanyHRID)
            {
                return BadRequest();
            }

            db.Entry(companyHR).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyHRExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CompanyHR
        [ResponseType(typeof(CompanyHR))]
        public IHttpActionResult PostCompanyHR(CompanyHR companyHR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CompanyHRs.Add(companyHR);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = companyHR.CompanyHRID }, companyHR);
        }

        // DELETE: api/CompanyHR/5
        [ResponseType(typeof(CompanyHR))]
        public IHttpActionResult DeleteCompanyHR(int id)
        {
            CompanyHR companyHR = db.CompanyHRs.Find(id);
            if (companyHR == null)
            {
                return NotFound();
            }

            db.CompanyHRs.Remove(companyHR);
            db.SaveChanges();

            return Ok(companyHR);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CompanyHRExists(int id)
        {
            return db.CompanyHRs.Count(e => e.CompanyHRID == id) > 0;
        }
    }
}