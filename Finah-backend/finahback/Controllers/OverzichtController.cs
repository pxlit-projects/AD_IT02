using finahback.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace finahback.Controllers
{
    public class OverzichtController : ApiController
    {
        private finahbackContext db = new finahbackContext();

        // GET: api/OVerzichts
        public IQueryable<Overzicht> GetOverzicht()
        {
            return db.Overzichts;

        }

        // GET: api/Overzichts/5
        [ResponseType(typeof(Overzicht))]
        public async Task<IHttpActionResult> GetOverzicht(int id)
        {
            IQueryable<Overzicht> overzicht = db.Overzichts.Where(i => i.Id == id);

            if (overzicht == null)
            {
                return NotFound();
            }

            return Ok(overzicht);
        }

        // PUT: api/Overzichts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOverzicht(int id, Overzicht overzicht)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != overzicht.Id)
            {
                return BadRequest();
            }

            db.Entry(overzicht).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OverzichtExists(id))
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

        // POST: api/Overzichts
        [ResponseType(typeof(Overzicht))]
        public async Task<IHttpActionResult> PostOverzicht(Overzicht overzicht)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Overzichts.Add(overzicht);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = overzicht.Id }, overzicht);
        }

        // DELETE: api/Overzichts/5
        [ResponseType(typeof(Overzicht))]
        public async Task<IHttpActionResult> DeleteOverzicht(int id)
        {
            Overzicht overzicht = await db.Overzichts.FindAsync(id);
            if (overzicht == null)
            {
                return NotFound();
            }

            db.Overzichts.Remove(overzicht);
            await db.SaveChangesAsync();

            return Ok(overzicht);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OverzichtExists(int id)
        {
            return db.Overzichts.Count(e => e.Id == id) > 0;
        }
    }
}