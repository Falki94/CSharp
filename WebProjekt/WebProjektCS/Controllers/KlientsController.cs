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
using WebProjektCS.Models;

namespace WebProjektCS.Controllers
{
    public class KlientsController : ApiController
    {
        private SklepEntities db = new SklepEntities();

        // GET: api/Klients
        [ResponseType(typeof(IEnumerable<Klient>))]
        [Route("api/Klient")]
        public IQueryable<Klient> GetKlients()
        {
            return db.Klients;
        }

        // GET: api/Klients/5
        [ResponseType(typeof(Klient))]
        public IHttpActionResult GetKlient(int id)
        {
            Klient klient = db.Klients.Find(id);
            if (klient == null)
            {
                return NotFound();
            }

            return Ok(klient);
        }

        // PUT: api/Klients/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKlient(int id, Klient klient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != klient.id_klient)
            {
                return BadRequest();
            }

            db.Entry(klient).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KlientExists(id))
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

        // POST: api/Klients
        [ResponseType(typeof(Klient))]
        public IHttpActionResult PostKlient(Klient klient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Klients.Add(klient);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = klient.id_klient }, klient);
        }

        // DELETE: api/Klients/5
        [ResponseType(typeof(Klient))]
        public IHttpActionResult DeleteKlient(int id)
        {
            Klient klient = db.Klients.Find(id);
            if (klient == null)
            {
                return NotFound();
            }

            db.Klients.Remove(klient);
            db.SaveChanges();

            return Ok(klient);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KlientExists(int id)
        {
            return db.Klients.Count(e => e.id_klient == id) > 0;
        }
    }
}