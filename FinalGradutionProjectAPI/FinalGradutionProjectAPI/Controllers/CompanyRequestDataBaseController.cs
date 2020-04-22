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
    public class CompanyRequestDataBaseController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/CompanyRequestDataBase
        public IQueryable<CompanyRequestDataBase> GetCompanyRequestDataBases()
        {
            return db.CompanyRequestDataBases;
        }

        // GET: api/CompanyRequestDataBase/5
        [ResponseType(typeof(CompanyRequestDataBase))]
        public IHttpActionResult GetCompanyRequestDataBase(int id)
        {
            CompanyRequestDataBase companyRequestDataBase = db.CompanyRequestDataBases.Find(id);
            if (companyRequestDataBase == null)
            {
                return NotFound();
            }

            return Ok(companyRequestDataBase);
        }

        // PUT: api/CompanyRequestDataBase/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCompanyRequestDataBase(int id, CompanyRequestDataBase companyRequestDataBase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != companyRequestDataBase.RequestId)
            {
                return BadRequest();
            }

            db.Entry(companyRequestDataBase).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyRequestDataBaseExists(id))
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

        // POST: api/CompanyRequestDataBase
        [ResponseType(typeof(CompanyRequestDataBase))]
        public IHttpActionResult PostCompanyRequestDataBase(CompanyRequestDataBase companyRequestDataBase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CompanyRequestDataBases.Add(companyRequestDataBase);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CompanyRequestDataBaseExists(companyRequestDataBase.RequestId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = companyRequestDataBase.RequestId }, companyRequestDataBase);
        }

        // DELETE: api/CompanyRequestDataBase/5
        [ResponseType(typeof(CompanyRequestDataBase))]
        public IHttpActionResult DeleteCompanyRequestDataBase(int id)
        {
            CompanyRequestDataBase companyRequestDataBase = db.CompanyRequestDataBases.Find(id);
            if (companyRequestDataBase == null)
            {
                return NotFound();
            }

            db.CompanyRequestDataBases.Remove(companyRequestDataBase);
            db.SaveChanges();

            return Ok(companyRequestDataBase);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CompanyRequestDataBaseExists(int id)
        {
            return db.CompanyRequestDataBases.Count(e => e.RequestId == id) > 0;
        }
    }
}