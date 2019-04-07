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
    public class PracowniksController : ApiController
    {
        private SklepEntities db = new SklepEntities();

        // GET: api/Pracowniks
        [ResponseType(typeof(IEnumerable<Pracownik>))]
        [Route("api/Pracownik")]
        public IQueryable<Pracownik> GetPracowniks()
        {
            return db.Pracowniks;
        }

        // GET: api/Pracowniks/5
        [ResponseType(typeof(Pracownik))]
        [Route("api/Pracownik")]
        public IHttpActionResult GetPracownik(int id)
        {
            Pracownik pracownik = db.Pracowniks.Find(id);
            if (pracownik == null)
            {
                return NotFound();
            }

            return Ok(pracownik);
        }

        // PUT: api/Pracowniks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPracownik(int id, Pracownik pracownik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pracownik.id_pracownik)
            {
                return BadRequest();
            }

            db.Entry(pracownik).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PracownikExists(id))
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

        // POST: api/Pracowniks
        [ResponseType(typeof(Pracownik))]
        public IHttpActionResult PostPracownik(Pracownik pracownik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pracowniks.Add(pracownik);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pracownik.id_pracownik }, pracownik);
        }

        // DELETE: api/Pracowniks/5
        [ResponseType(typeof(Pracownik))]
        public IHttpActionResult DeletePracownik(int id)
        {
            Pracownik pracownik = db.Pracowniks.Find(id);
            if (pracownik == null)
            {
                return NotFound();
            }

            db.Pracowniks.Remove(pracownik);
            db.SaveChanges();

            return Ok(pracownik);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PracownikExists(int id)
        {
            return db.Pracowniks.Count(e => e.id_pracownik == id) > 0;
        }
    }
}