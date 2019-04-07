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
    public class DostawasController : ApiController
    {
        private SklepEntities db = new SklepEntities();

        // GET: api/Dostawas
        [ResponseType(typeof(IEnumerable<Dostawa>))]
        [Route("api/Dostawa")]
        public IQueryable<Dostawa> GetDostawas()
        {
            return db.Dostawas;
        }

        // GET: api/Dostawas/5
        [ResponseType(typeof(Dostawa))]
        public IHttpActionResult GetDostawa(int id)
        {
            Dostawa dostawa = db.Dostawas.Find(id);
            if (dostawa == null)
            {
                return NotFound();
            }

            return Ok(dostawa);
        }

        // PUT: api/Dostawas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDostawa(int id, Dostawa dostawa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dostawa.id_dostawa)
            {
                return BadRequest();
            }

            db.Entry(dostawa).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DostawaExists(id))
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

        // POST: api/Dostawas
        [ResponseType(typeof(Dostawa))]
        public IHttpActionResult PostDostawa(Dostawa dostawa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Dostawas.Add(dostawa);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dostawa.id_dostawa }, dostawa);
        }

        // DELETE: api/Dostawas/5
        [ResponseType(typeof(Dostawa))]
        public IHttpActionResult DeleteDostawa(int id)
        {
            Dostawa dostawa = db.Dostawas.Find(id);
            if (dostawa == null)
            {
                return NotFound();
            }

            db.Dostawas.Remove(dostawa);
            db.SaveChanges();

            return Ok(dostawa);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DostawaExists(int id)
        {
            return db.Dostawas.Count(e => e.id_dostawa == id) > 0;
        }
    }
}