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
    public class CVTechnologyController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/CVTechnology
        public IQueryable<CVTechnology> GetCVTechnologies()
        {
            return db.CVTechnologies;
        }

        // GET: api/CVTechnology/5
        [ResponseType(typeof(CVTechnology))]
        public IHttpActionResult GetCVTechnology(int id)
        {
            CVTechnology cVTechnology = db.CVTechnologies.Find(id);
            if (cVTechnology == null)
            {
                return NotFound();
            }

            return Ok(cVTechnology);
        }

        // PUT: api/CVTechnology/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCVTechnology(int id, CVTechnology cVTechnology)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cVTechnology.CVID)
            {
                return BadRequest();
            }

            db.Entry(cVTechnology).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CVTechnologyExists(id))
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

        // POST: api/CVTechnology
        [ResponseType(typeof(CVTechnology))]
        public IHttpActionResult PostCVTechnology(CVTechnology cVTechnology)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CVTechnologies.Add(cVTechnology);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CVTechnologyExists(cVTechnology.CVID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cVTechnology.CVID }, cVTechnology);
        }

        // DELETE: api/CVTechnology/5
        [ResponseType(typeof(CVTechnology))]
        public IHttpActionResult DeleteCVTechnology(int id)
        {
            CVTechnology cVTechnology = db.CVTechnologies.Find(id);
            if (cVTechnology == null)
            {
                return NotFound();
            }

            db.CVTechnologies.Remove(cVTechnology);
            db.SaveChanges();

            return Ok(cVTechnology);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CVTechnologyExists(int id)
        {
            return db.CVTechnologies.Count(e => e.CVID == id) > 0;
        }
    }
}