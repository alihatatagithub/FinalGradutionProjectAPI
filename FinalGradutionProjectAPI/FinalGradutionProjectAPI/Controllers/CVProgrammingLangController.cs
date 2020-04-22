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
    public class CVProgrammingLangController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/CVProgrammingLang
        public IQueryable<CVProgrammingLang> GetCVProgrammingLangs()
        {
            return db.CVProgrammingLangs;
        }

        // GET: api/CVProgrammingLang/5
        [ResponseType(typeof(CVProgrammingLang))]
        public IHttpActionResult GetCVProgrammingLang(int id)
        {
            CVProgrammingLang cVProgrammingLang = db.CVProgrammingLangs.Find(id);
            if (cVProgrammingLang == null)
            {
                return NotFound();
            }

            return Ok(cVProgrammingLang);
        }

        // PUT: api/CVProgrammingLang/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCVProgrammingLang(int id, CVProgrammingLang cVProgrammingLang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cVProgrammingLang.CVID)
            {
                return BadRequest();
            }

            db.Entry(cVProgrammingLang).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CVProgrammingLangExists(id))
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

        // POST: api/CVProgrammingLang
        [ResponseType(typeof(CVProgrammingLang))]
        public IHttpActionResult PostCVProgrammingLang(CVProgrammingLang cVProgrammingLang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CVProgrammingLangs.Add(cVProgrammingLang);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CVProgrammingLangExists(cVProgrammingLang.CVID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cVProgrammingLang.CVID }, cVProgrammingLang);
        }

        // DELETE: api/CVProgrammingLang/5
        [ResponseType(typeof(CVProgrammingLang))]
        public IHttpActionResult DeleteCVProgrammingLang(int id)
        {
            CVProgrammingLang cVProgrammingLang = db.CVProgrammingLangs.Find(id);
            if (cVProgrammingLang == null)
            {
                return NotFound();
            }

            db.CVProgrammingLangs.Remove(cVProgrammingLang);
            db.SaveChanges();

            return Ok(cVProgrammingLang);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CVProgrammingLangExists(int id)
        {
            return db.CVProgrammingLangs.Count(e => e.CVID == id) > 0;
        }
    }
}