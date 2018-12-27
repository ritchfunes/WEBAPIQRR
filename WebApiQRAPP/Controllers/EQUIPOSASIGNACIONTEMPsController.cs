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
using WebApiQRAPP.Models;

namespace WebApiQRAPP.Controllers
{
    public class EQUIPOSASIGNACIONTEMPsController : ApiController
    {
        private APPUNDQREntities db = new APPUNDQREntities();

        // GET: api/EQUIPOSASIGNACIONTEMPs
        public IQueryable<EQUIPOSASIGNACIONTEMP> GetEQUIPOSASIGNACIONTEMP()
        {
            return db.EQUIPOSASIGNACIONTEMP;
        }

        // GET: api/EQUIPOSASIGNACIONTEMPs/5
        [ResponseType(typeof(EQUIPOSASIGNACIONTEMP))]
        public IHttpActionResult GetEQUIPOSASIGNACIONTEMP(long id)
        {
            EQUIPOSASIGNACIONTEMP eQUIPOSASIGNACIONTEMP = db.EQUIPOSASIGNACIONTEMP.Find(id);
            if (eQUIPOSASIGNACIONTEMP == null)
            {
                return NotFound();
            }

            return Ok(eQUIPOSASIGNACIONTEMP);
        }

        // PUT: api/EQUIPOSASIGNACIONTEMPs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEQUIPOSASIGNACIONTEMP(long id, EQUIPOSASIGNACIONTEMP eQUIPOSASIGNACIONTEMP)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eQUIPOSASIGNACIONTEMP.ID)
            {
                return BadRequest();
            }

            db.Entry(eQUIPOSASIGNACIONTEMP).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EQUIPOSASIGNACIONTEMPExists(id))
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

        // POST: api/EQUIPOSASIGNACIONTEMPs
        [ResponseType(typeof(EQUIPOSASIGNACIONTEMP))]
        public IHttpActionResult PostEQUIPOSASIGNACIONTEMP(EQUIPOSASIGNACIONTEMP eQUIPOSASIGNACIONTEMP)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EQUIPOSASIGNACIONTEMP.Add(eQUIPOSASIGNACIONTEMP);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = eQUIPOSASIGNACIONTEMP.ID }, eQUIPOSASIGNACIONTEMP);
        }

        // DELETE: api/EQUIPOSASIGNACIONTEMPs/5
        [ResponseType(typeof(EQUIPOSASIGNACIONTEMP))]
        public IHttpActionResult DeleteEQUIPOSASIGNACIONTEMP(long id)
        {
            EQUIPOSASIGNACIONTEMP eQUIPOSASIGNACIONTEMP = db.EQUIPOSASIGNACIONTEMP.Find(id);
            if (eQUIPOSASIGNACIONTEMP == null)
            {
                return NotFound();
            }

            db.EQUIPOSASIGNACIONTEMP.Remove(eQUIPOSASIGNACIONTEMP);
            db.SaveChanges();

            return Ok(eQUIPOSASIGNACIONTEMP);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EQUIPOSASIGNACIONTEMPExists(long id)
        {
            return db.EQUIPOSASIGNACIONTEMP.Count(e => e.ID == id) > 0;
        }
    }
}