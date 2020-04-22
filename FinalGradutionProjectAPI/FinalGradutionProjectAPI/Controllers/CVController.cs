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
    [Authorize(Roles ="JobSeekerRole")]
    public class CVController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/CV
        public IQueryable<CV> GetCVs()
        {
            return db.CVs;
        }

        // GET: api/CV/5
        [ResponseType(typeof(CV))]
        public IHttpActionResult GetCV(int id)
        {
            CV cV = db.CVs.Find(id);
            if (cV == null)
            {
                return NotFound();
            }

            return Ok(cV);
        }

        // PUT: api/CV/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCV(int id, CV cV)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cV.CVID)
            {
                return BadRequest();
            }

            db.Entry(cV).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CVExists(id))
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

        // POST: api/CV
        [ResponseType(typeof(CV))]
        public IHttpActionResult PostCV(CV cV)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CVs.Add(cV);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cV.CVID }, cV);
        }

        // DELETE: api/CV/5
        [ResponseType(typeof(CV))]
        public IHttpActionResult DeleteCV(int id)
        {
            CV cV = db.CVs.Find(id);
            if (cV == null)
            {
                return NotFound();
            }

            db.CVs.Remove(cV);
            db.SaveChanges();

            return Ok(cV);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CVExists(int id)
        {
            return db.CVs.Count(e => e.CVID == id) > 0;
        }
    }
}