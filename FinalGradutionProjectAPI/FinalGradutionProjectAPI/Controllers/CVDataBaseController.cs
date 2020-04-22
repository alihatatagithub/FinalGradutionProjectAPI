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
    public class CVDataBaseController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/CVDataBase
        public IQueryable<CVDataBase> GetCVDataBases()
        {
            return db.CVDataBases;
        }

        // GET: api/CVDataBase/5
        [ResponseType(typeof(CVDataBase))]
        public IHttpActionResult GetCVDataBase(int id)
        {
            CVDataBase cVDataBase = db.CVDataBases.Find(id);
            if (cVDataBase == null)
            {
                return NotFound();
            }

            return Ok(cVDataBase);
        }

        // PUT: api/CVDataBase/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCVDataBase(int id, CVDataBase cVDataBase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cVDataBase.CVID)
            {
                return BadRequest();
            }

            db.Entry(cVDataBase).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CVDataBaseExists(id))
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

        // POST: api/CVDataBase
        [ResponseType(typeof(CVDataBase))]
        public IHttpActionResult PostCVDataBase(CVDataBase cVDataBase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CVDataBases.Add(cVDataBase);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CVDataBaseExists(cVDataBase.CVID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cVDataBase.CVID }, cVDataBase);
        }

        // DELETE: api/CVDataBase/5
        [ResponseType(typeof(CVDataBase))]
        public IHttpActionResult DeleteCVDataBase(int id)
        {
            CVDataBase cVDataBase = db.CVDataBases.Find(id);
            if (cVDataBase == null)
            {
                return NotFound();
            }

            db.CVDataBases.Remove(cVDataBase);
            db.SaveChanges();

            return Ok(cVDataBase);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CVDataBaseExists(int id)
        {
            return db.CVDataBases.Count(e => e.CVID == id) > 0;
        }
    }
}