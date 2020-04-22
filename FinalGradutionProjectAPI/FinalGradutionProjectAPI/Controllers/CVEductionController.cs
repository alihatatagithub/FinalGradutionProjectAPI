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
    public class CVEductionController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/CVEduction
        public IQueryable<CVEduction> GetCVEductions()
        {
            return db.CVEductions;
        }

        // GET: api/CVEduction/5
        [ResponseType(typeof(CVEduction))]
        public IHttpActionResult GetCVEduction(int id)
        {
            CVEduction cVEduction = db.CVEductions.Find(id);
            if (cVEduction == null)
            {
                return NotFound();
            }

            return Ok(cVEduction);
        }

        // PUT: api/CVEduction/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCVEduction(int id, CVEduction cVEduction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cVEduction.CVID)
            {
                return BadRequest();
            }

            db.Entry(cVEduction).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CVEductionExists(id))
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

        // POST: api/CVEduction
        [ResponseType(typeof(CVEduction))]
        public IHttpActionResult PostCVEduction(CVEduction cVEduction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CVEductions.Add(cVEduction);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CVEductionExists(cVEduction.CVID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cVEduction.CVID }, cVEduction);
        }

        // DELETE: api/CVEduction/5
        [ResponseType(typeof(CVEduction))]
        public IHttpActionResult DeleteCVEduction(int id)
        {
            CVEduction cVEduction = db.CVEductions.Find(id);
            if (cVEduction == null)
            {
                return NotFound();
            }

            db.CVEductions.Remove(cVEduction);
            db.SaveChanges();

            return Ok(cVEduction);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CVEductionExists(int id)
        {
            return db.CVEductions.Count(e => e.CVID == id) > 0;
        }
    }
}