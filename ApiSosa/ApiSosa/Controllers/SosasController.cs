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
using ApiSosa.Models;

namespace ApiSosa.Controllers
{
    public class SosasController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Sosas
        public IQueryable<Sosa> GetSosas()
        {
            return db.Sosas;
        }

        // GET: api/Sosas/5
        [ResponseType(typeof(Sosa))]
        public IHttpActionResult GetSosa(int id)
        {
            Sosa sosa = db.Sosas.Find(id);
            if (sosa == null)
            {
                return NotFound();
            }

            return Ok(sosa);
        }

        // PUT: api/Sosas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSosa(int id, Sosa sosa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sosa.SosaID)
            {
                return BadRequest();
            }

            db.Entry(sosa).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SosaExists(id))
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

        // POST: api/Sosas
        [ResponseType(typeof(Sosa))]
        public IHttpActionResult PostSosa(Sosa sosa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sosas.Add(sosa);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sosa.SosaID }, sosa);
        }

        // DELETE: api/Sosas/5
        [ResponseType(typeof(Sosa))]
        public IHttpActionResult DeleteSosa(int id)
        {
            Sosa sosa = db.Sosas.Find(id);
            if (sosa == null)
            {
                return NotFound();
            }

            db.Sosas.Remove(sosa);
            db.SaveChanges();

            return Ok(sosa);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SosaExists(int id)
        {
            return db.Sosas.Count(e => e.SosaID == id) > 0;
        }
    }
}