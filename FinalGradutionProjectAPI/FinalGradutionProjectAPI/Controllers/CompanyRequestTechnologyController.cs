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
    public class CompanyRequestTechnologyController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/CompanyRequestTechnology
        public IQueryable<CompanyRequestTechnology> GetCompanyRequestTechnologies()
        {
            return db.CompanyRequestTechnologies;
        }

        // GET: api/CompanyRequestTechnology/5
        [ResponseType(typeof(CompanyRequestTechnology))]
        public IHttpActionResult GetCompanyRequestTechnology(int id)
        {
            CompanyRequestTechnology companyRequestTechnology = db.CompanyRequestTechnologies.Find(id);
            if (companyRequestTechnology == null)
            {
                return NotFound();
            }

            return Ok(companyRequestTechnology);
        }

        // PUT: api/CompanyRequestTechnology/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCompanyRequestTechnology(int id, CompanyRequestTechnology companyRequestTechnology)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != companyRequestTechnology.RequestId)
            {
                return BadRequest();
            }

            db.Entry(companyRequestTechnology).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyRequestTechnologyExists(id))
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

        // POST: api/CompanyRequestTechnology
        [ResponseType(typeof(CompanyRequestTechnology))]
        public IHttpActionResult PostCompanyRequestTechnology(CompanyRequestTechnology companyRequestTechnology)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CompanyRequestTechnologies.Add(companyRequestTechnology);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CompanyRequestTechnologyExists(companyRequestTechnology.RequestId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = companyRequestTechnology.RequestId }, companyRequestTechnology);
        }

        // DELETE: api/CompanyRequestTechnology/5
        [ResponseType(typeof(CompanyRequestTechnology))]
        public IHttpActionResult DeleteCompanyRequestTechnology(int id)
        {
            CompanyRequestTechnology companyRequestTechnology = db.CompanyRequestTechnologies.Find(id);
            if (companyRequestTechnology == null)
            {
                return NotFound();
            }

            db.CompanyRequestTechnologies.Remove(companyRequestTechnology);
            db.SaveChanges();

            return Ok(companyRequestTechnology);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CompanyRequestTechnologyExists(int id)
        {
            return db.CompanyRequestTechnologies.Count(e => e.RequestId == id) > 0;
        }
    }
}