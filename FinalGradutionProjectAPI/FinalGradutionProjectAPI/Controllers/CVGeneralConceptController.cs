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
    [Authorize(Roles = "JobSeekerRole")]
    public class CVGeneralConceptController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/CVGeneralConcept
        public IQueryable<CVGeneralConcept> GetCVGeneralConcepts()
        {
            return db.CVGeneralConcepts;
        }

        // GET: api/CVGeneralConcept/5
        [ResponseType(typeof(CVGeneralConcept))]
        public IHttpActionResult GetCVGeneralConcept(int id)
        {
            CVGeneralConcept cVGeneralConcept = db.CVGeneralConcepts.Find(id);
            if (cVGeneralConcept == null)
            {
                return NotFound();
            }

            return Ok(cVGeneralConcept);
        }

        // PUT: api/CVGeneralConcept/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCVGeneralConcept(int id, CVGeneralConcept cVGeneralConcept)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cVGeneralConcept.CVID)
            {
                return BadRequest();
            }

            db.Entry(cVGeneralConcept).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CVGeneralConceptExists(id))
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

        // POST: api/CVGeneralConcept
        [ResponseType(typeof(CVGeneralConcept))]
        public IHttpActionResult PostCVGeneralConcept(CVGeneralConcept cVGeneralConcept)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CVGeneralConcepts.Add(cVGeneralConcept);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CVGeneralConceptExists(cVGeneralConcept.CVID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cVGeneralConcept.CVID }, cVGeneralConcept);
        }

        // DELETE: api/CVGeneralConcept/5
        [ResponseType(typeof(CVGeneralConcept))]
        public IHttpActionResult DeleteCVGeneralConcept(int id)
        {
            CVGeneralConcept cVGeneralConcept = db.CVGeneralConcepts.Find(id);
            if (cVGeneralConcept == null)
            {
                return NotFound();
            }

            db.CVGeneralConcepts.Remove(cVGeneralConcept);
            db.SaveChanges();

            return Ok(cVGeneralConcept);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CVGeneralConceptExists(int id)
        {
            return db.CVGeneralConcepts.Count(e => e.CVID == id) > 0;
        }
    }
}