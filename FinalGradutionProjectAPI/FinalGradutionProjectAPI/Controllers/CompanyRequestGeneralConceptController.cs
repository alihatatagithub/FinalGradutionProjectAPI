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
    public class CompanyRequestGeneralConceptController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/CompanyRequestGeneralConcept
        public IQueryable<CompanyRequestGeneralConcept> GetCompanyRequestGeneralConcepts()
        {
            return db.CompanyRequestGeneralConcepts;
        }

        // GET: api/CompanyRequestGeneralConcept/5
        [ResponseType(typeof(CompanyRequestGeneralConcept))]
        public IHttpActionResult GetCompanyRequestGeneralConcept(int id)
        {
            CompanyRequestGeneralConcept companyRequestGeneralConcept = db.CompanyRequestGeneralConcepts.Find(id);
            if (companyRequestGeneralConcept == null)
            {
                return NotFound();
            }

            return Ok(companyRequestGeneralConcept);
        }

        // PUT: api/CompanyRequestGeneralConcept/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCompanyRequestGeneralConcept(int id, CompanyRequestGeneralConcept companyRequestGeneralConcept)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != companyRequestGeneralConcept.RequestId)
            {
                return BadRequest();
            }

            db.Entry(companyRequestGeneralConcept).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyRequestGeneralConceptExists(id))
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

        // POST: api/CompanyRequestGeneralConcept
        [ResponseType(typeof(CompanyRequestGeneralConcept))]
        public IHttpActionResult PostCompanyRequestGeneralConcept(CompanyRequestGeneralConcept companyRequestGeneralConcept)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CompanyRequestGeneralConcepts.Add(companyRequestGeneralConcept);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CompanyRequestGeneralConceptExists(companyRequestGeneralConcept.RequestId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = companyRequestGeneralConcept.RequestId }, companyRequestGeneralConcept);
        }

        // DELETE: api/CompanyRequestGeneralConcept/5
        [ResponseType(typeof(CompanyRequestGeneralConcept))]
        public IHttpActionResult DeleteCompanyRequestGeneralConcept(int id)
        {
            CompanyRequestGeneralConcept companyRequestGeneralConcept = db.CompanyRequestGeneralConcepts.Find(id);
            if (companyRequestGeneralConcept == null)
            {
                return NotFound();
            }

            db.CompanyRequestGeneralConcepts.Remove(companyRequestGeneralConcept);
            db.SaveChanges();

            return Ok(companyRequestGeneralConcept);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CompanyRequestGeneralConceptExists(int id)
        {
            return db.CompanyRequestGeneralConcepts.Count(e => e.RequestId == id) > 0;
        }
    }
}