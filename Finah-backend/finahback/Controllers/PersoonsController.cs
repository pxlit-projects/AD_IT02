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
    public class PersoonsController : ApiController
    {
        private finahbackContext db = new finahbackContext();

        // GET: api/Persoons
        public IQueryable<Persoon> GetPersoons()
        {
            return db.Persoons;

        }

        // GET: api/Persoons/5
        [ResponseType(typeof(Persoon))]
        public async Task<IHttpActionResult> GetPersoon(String gebruikersnaam, String wachtwoord)
        {
            IQueryable<Persoon> persoon = db.Persoons.Where(i => i.gebruikersnaam == gebruikersnaam && i.wachtwoord == wachtwoord);
            
            if (persoon == null)
            {
                return NotFound();
            }

            return Ok(persoon);
        }

        // GET: api/Patients/5
        [ResponseType(typeof(Persoon))]
        public async Task<IHttpActionResult> GetPersoon(int id)
        {
            IQueryable<Persoon> persoon = db.Persoons.Where(i => i.Id == id);

            if (persoon == null)
            {
                return NotFound();
            }

            return Ok(persoon);
        }

        // PUT: api/Persoons/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPersoon(int id, Persoon persoon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != persoon.Id)
            {
                return BadRequest();
            }

            db.Entry(persoon).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersoonExists(id))
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

        // POST: api/Persoons
        [ResponseType(typeof(Persoon))]
        public async Task<IHttpActionResult> PostPersoon(Persoon persoon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Persoons.Add(persoon);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = persoon.Id }, persoon);
        }

        // DELETE: api/Persoons/5
        [ResponseType(typeof(Persoon))]
        public async Task<IHttpActionResult> DeletePersoon(int id)
        {
            Persoon persoon = await db.Persoons.FindAsync(id);
            if (persoon == null)
            {
                return NotFound();
            }

            db.Persoons.Remove(persoon);
            await db.SaveChangesAsync();

            return Ok(persoon);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersoonExists(int id)
        {
            return db.Persoons.Count(e => e.Id == id) > 0;
        }
    }
}