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
    public class ZamowieniesController : ApiController
    {
        private SklepEntities db = new SklepEntities();

        // GET: api/Zamowienies
        [ResponseType(typeof(IEnumerable<Zamowienie>))]
        [Route("api/Zamowienie")]
        public IQueryable<Zamowienie> GetZamowienies()
        {
            return db.Zamowienies;
        }

        // GET: api/Zamowienies/5
        [ResponseType(typeof(Zamowienie))]
        public IHttpActionResult GetZamowienie(int id)
        {
            Zamowienie zamowienie = db.Zamowienies.Find(id);
            if (zamowienie == null)
            {
                return NotFound();
            }

            return Ok(zamowienie);
        }

        // PUT: api/Zamowienies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutZamowienie(int id, Zamowienie zamowienie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != zamowienie.id_zamowienie)
            {
                return BadRequest();
            }

            db.Entry(zamowienie).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZamowienieExists(id))
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

        // POST: api/Zamowienies
        [ResponseType(typeof(Zamowienie))]
        public IHttpActionResult PostZamowienie(Zamowienie zamowienie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Zamowienies.Add(zamowienie);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = zamowienie.id_zamowienie }, zamowienie);
        }

        // DELETE: api/Zamowienies/5
        [ResponseType(typeof(Zamowienie))]
        public IHttpActionResult DeleteZamowienie(int id)
        {
            Zamowienie zamowienie = db.Zamowienies.Find(id);
            if (zamowienie == null)
            {
                return NotFound();
            }

            db.Zamowienies.Remove(zamowienie);
            db.SaveChanges();

            return Ok(zamowienie);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ZamowienieExists(int id)
        {
            return db.Zamowienies.Count(e => e.id_zamowienie == id) > 0;
        }
    }
}