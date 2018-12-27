using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiQRAPP.Models;
using Newtonsoft.Json ;
using Newtonsoft.Json.Linq;



namespace WebApiQRAPP.Controllers
{
    
    public class SalestablesController : ApiController
    {
        private APPUNDQREntities db = new APPUNDQREntities();
        Validacionsalestable validacion = new Validacionsalestable();
        
        
        // GET: api/Salestables
        public IQueryable<Salestable> GetSalestable()
        {   // IQueryable
         //   Object[] array = new Object[2];
         //   array[0] = "contactos";
         //   array[1] = db.Salestable.ToArray();
         //   var contacts =  db.Salestable.ToArray() ; 
         //     var json = Newtonsoft.Json.JsonConvert.SerializeObject(new { contacts = db.Salestable.ToArray() });
            //    var jsonliq = (from s in json select s ).ToList();
            // Json ajson = new Json(  db.Salestable);
            
            return db.Salestable ; //  db.Salestable;

        }
           
       
    

        // GET: api/Salestables/5
        [ResponseType(typeof(Salestable))]
        public IHttpActionResult GetSalestable(long id)
        {
            Salestable salestable = db.Salestable.Find(id);
            if (salestable == null)
            {
                return NotFound();
            }

            return Ok(salestable);
        }

        // PUT: api/Salestables/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSalestable(long id, Salestable salestable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != salestable.id)
            {
                return BadRequest();
            }

            db.Entry(salestable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalestableExists(id))
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

        // POST: api/Salestables
        [ResponseType(typeof(Salestable))]
        public IHttpActionResult PostSalestable(Salestable salestable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Salestable.Add(salestable);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = salestable.id }, salestable);
        }

        // DELETE: api/Salestables/5
        [ResponseType(typeof(Salestable))]
        public IHttpActionResult DeleteSalestable(long id)
        {
            Salestable salestable = db.Salestable.Find(id);
            if (salestable == null)
            {
                return NotFound();
            }

            db.Salestable.Remove(salestable);
            db.SaveChanges();

            return Ok(salestable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SalestableExists(long id)
        {
            return db.Salestable.Count(e => e.id == id) > 0;
        }
    }
}