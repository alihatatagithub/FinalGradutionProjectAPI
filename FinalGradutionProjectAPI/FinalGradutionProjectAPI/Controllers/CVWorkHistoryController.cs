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
    public class CVWorkHistoryController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/CVWorkHistory
        public IQueryable<CVWorkHistory> GetCVWorkHistories()
        {
            return db.CVWorkHistories;
        }

        // GET: api/CVWorkHistory/5
        [ResponseType(typeof(CVWorkHistory))]
        public IHttpActionResult GetCVWorkHistory(int id)
        {
            CVWorkHistory cVWorkHistory = db.CVWorkHistories.Find(id);
            if (cVWorkHistory == null)
            {
                return NotFound();
            }

            return Ok(cVWorkHistory);
        }

        // PUT: api/CVWorkHistory/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCVWorkHistory(int id, CVWorkHistory cVWorkHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cVWorkHistory.CVID)
            {
                return BadRequest();
            }

            db.Entry(cVWorkHistory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CVWorkHistoryExists(id))
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

        // POST: api/CVWorkHistory
        [ResponseType(typeof(CVWorkHistory))]
        public IHttpActionResult PostCVWorkHistory(CVWorkHistory cVWorkHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CVWorkHistories.Add(cVWorkHistory);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CVWorkHistoryExists(cVWorkHistory.CVID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cVWorkHistory.CVID }, cVWorkHistory);
        }

        // DELETE: api/CVWorkHistory/5
        [ResponseType(typeof(CVWorkHistory))]
        public IHttpActionResult DeleteCVWorkHistory(int id)
        {
            CVWorkHistory cVWorkHistory = db.CVWorkHistories.Find(id);
            if (cVWorkHistory == null)
            {
                return NotFound();
            }

            db.CVWorkHistories.Remove(cVWorkHistory);
            db.SaveChanges();

            return Ok(cVWorkHistory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CVWorkHistoryExists(int id)
        {
            return db.CVWorkHistories.Count(e => e.CVID == id) > 0;
        }
    }
}