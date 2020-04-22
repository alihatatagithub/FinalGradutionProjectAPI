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
    public class CompanyRequestProgrammingLangController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/CompanyRequestProgrammingLang
        public IQueryable<CompanyRequestProgrammingLang> GetCompanyRequestProgrammingLangs()
        {
            return db.CompanyRequestProgrammingLangs;
        }

        // GET: api/CompanyRequestProgrammingLang/5
        [ResponseType(typeof(CompanyRequestProgrammingLang))]
        public IHttpActionResult GetCompanyRequestProgrammingLang(string id)
        {
            CompanyRequestProgrammingLang companyRequestProgrammingLang = db.CompanyRequestProgrammingLangs.Find(id);
            if (companyRequestProgrammingLang == null)
            {
                return NotFound();
            }

            return Ok(companyRequestProgrammingLang);
        }

        // PUT: api/CompanyRequestProgrammingLang/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCompanyRequestProgrammingLang(string id, CompanyRequestProgrammingLang companyRequestProgrammingLang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != companyRequestProgrammingLang.CRPLName)
            {
                return BadRequest();
            }

            db.Entry(companyRequestProgrammingLang).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyRequestProgrammingLangExists(id))
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

        // POST: api/CompanyRequestProgrammingLang
        [ResponseType(typeof(CompanyRequestProgrammingLang))]
        public IHttpActionResult PostCompanyRequestProgrammingLang(CompanyRequestProgrammingLang companyRequestProgrammingLang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CompanyRequestProgrammingLangs.Add(companyRequestProgrammingLang);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CompanyRequestProgrammingLangExists(companyRequestProgrammingLang.CRPLName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = companyRequestProgrammingLang.CRPLName }, companyRequestProgrammingLang);
        }

        // DELETE: api/CompanyRequestProgrammingLang/5
        [ResponseType(typeof(CompanyRequestProgrammingLang))]
        public IHttpActionResult DeleteCompanyRequestProgrammingLang(string id)
        {
            CompanyRequestProgrammingLang companyRequestProgrammingLang = db.CompanyRequestProgrammingLangs.Find(id);
            if (companyRequestProgrammingLang == null)
            {
                return NotFound();
            }

            db.CompanyRequestProgrammingLangs.Remove(companyRequestProgrammingLang);
            db.SaveChanges();

            return Ok(companyRequestProgrammingLang);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CompanyRequestProgrammingLangExists(string id)
        {
            return db.CompanyRequestProgrammingLangs.Count(e => e.CRPLName == id) > 0;
        }
    }
}