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
    public class AdresController : ApiController
    {
        private SklepEntities db = new SklepEntities();

        // GET: api/Adres
        [ResponseType(typeof(IEnumerable<Adre>))]
        [Route("api/Adres")]
        public IQueryable<Adre> GetAdres()
        {
            return db.Adres;
        }

        // GET: api/Adres/5
        [ResponseType(typeof(Adre))]
        public IHttpActionResult GetAdre(int id)
        {
            Adre adre = db.Adres.Find(id);
            if (adre == null)
            {
                return NotFound();
            }

            return Ok(adre);
        }

        // PUT: api/Adres/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdre(int id, Adre adre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adre.id_adres)
            {
                return BadRequest();
            }

            db.Entry(adre).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdreExists(id))
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

        // POST: api/Adres
        [ResponseType(typeof(Adre))]
        public IHttpActionResult PostAdre(Adre adre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Adres.Add(adre);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = adre.id_adres }, adre);
        }

        // DELETE: api/Adres/5
        [ResponseType(typeof(Adre))]
        public IHttpActionResult DeleteAdre(int id)
        {
            Adre adre = db.Adres.Find(id);
            if (adre == null)
            {
                return NotFound();
            }

            db.Adres.Remove(adre);
            db.SaveChanges();

            return Ok(adre);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdreExists(int id)
        {
            return db.Adres.Count(e => e.id_adres == id) > 0;
        }
    }
}