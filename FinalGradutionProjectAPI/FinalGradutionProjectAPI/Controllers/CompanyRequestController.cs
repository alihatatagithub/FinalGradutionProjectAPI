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
    public class CompanyRequestController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/CompanyRequest
        public IQueryable<CompanyRequest> GetCompanyRequests()
        {
            return db.CompanyRequests;
        }

        // GET: api/CompanyRequest/5
        [ResponseType(typeof(CompanyRequest))]
        public IHttpActionResult GetCompanyRequest(int id)
        {
            CompanyRequest companyRequest = db.CompanyRequests.Find(id);
            if (companyRequest == null)
            {
                return NotFound();
            }

            return Ok(companyRequest);
        }

        // PUT: api/CompanyRequest/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCompanyRequest(int id, CompanyRequest companyRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != companyRequest.RequestId)
            {
                return BadRequest();
            }

            db.Entry(companyRequest).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyRequestExists(id))
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

        // POST: api/CompanyRequest
        [ResponseType(typeof(CompanyRequest))]
        public IHttpActionResult PostCompanyRequest(CompanyRequest companyRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CompanyRequests.Add(companyRequest);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = companyRequest.RequestId }, companyRequest);
        }

        // DELETE: api/CompanyRequest/5
        [ResponseType(typeof(CompanyRequest))]
        public IHttpActionResult DeleteCompanyRequest(int id)
        {
            CompanyRequest companyRequest = db.CompanyRequests.Find(id);
            if (companyRequest == null)
            {
                return NotFound();
            }

            db.CompanyRequests.Remove(companyRequest);
            db.SaveChanges();

            return Ok(companyRequest);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CompanyRequestExists(int id)
        {
            return db.CompanyRequests.Count(e => e.RequestId == id) > 0;
        }
    }
}