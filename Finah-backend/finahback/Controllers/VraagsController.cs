using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using finahback.Models;

namespace finahback.Controllers
{
    public class VraagsController : ApiController
    {
        private finahbackContext db = new finahbackContext();

        // GET: api/Vraags
        public IQueryable<Vraag> GetVraags()
        {
            return db.Vraags;
        }

        // GET: api/Vraags/5
        [ResponseType(typeof(Vraag))]
        public async Task<IHttpActionResult> GetVraag(int id)
        {
            Vraag vraag = await db.Vraags.FindAsync(id);
            if (vraag == null)
            {
                return NotFound();
            }

            return Ok(vraag);
        }

        // PUT: api/Vraags/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutVraag(int id, Vraag vraag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vraag.id)
            {
                return BadRequest();
            }

            db.Entry(vraag).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VraagExists(id))
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

        // POST: api/Vraags
        [ResponseType(typeof(Vraag))]
        public async Task<IHttpActionResult> PostVraag(Vraag vraag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Vraags.Add(vraag);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = vraag.id }, vraag);
        }

        // DELETE: api/Vraags/5
        [ResponseType(typeof(Vraag))]
        public async Task<IHttpActionResult> DeleteVraag(int id)
        {
            Vraag vraag = await db.Vraags.FindAsync(id);
            if (vraag == null)
            {
                return NotFound();
            }

            db.Vraags.Remove(vraag);
            await db.SaveChangesAsync();

            return Ok(vraag);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VraagExists(int id)
        {
            return db.Vraags.Count(e => e.id == id) > 0;
        }
    }
}