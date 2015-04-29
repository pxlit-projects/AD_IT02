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
    public class FunctiesController : ApiController
    {
        private finahbackContext db = new finahbackContext();

        // GET: api/Functies
        public IQueryable<Functie> GetFuncties()
        {
            return db.Functies;
        }

        // GET: api/Functies/5
        [ResponseType(typeof(Functie))]
        public async Task<IHttpActionResult> GetFunctie(int id)
        {
            Functie functie = await db.Functies.FindAsync(id);
            if (functie == null)
            {
                return NotFound();
            }

            return Ok(functie);
        }

        // PUT: api/Functies/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFunctie(int id, Functie functie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != functie.id)
            {
                return BadRequest();
            }

            db.Entry(functie).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FunctieExists(id))
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

        // POST: api/Functies
        [ResponseType(typeof(Functie))]
        public async Task<IHttpActionResult> PostFunctie(Functie functie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Functies.Add(functie);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = functie.id }, functie);
        }

        // DELETE: api/Functies/5
        [ResponseType(typeof(Functie))]
        public async Task<IHttpActionResult> DeleteFunctie(int id)
        {
            Functie functie = await db.Functies.FindAsync(id);
            if (functie == null)
            {
                return NotFound();
            }

            db.Functies.Remove(functie);
            await db.SaveChangesAsync();

            return Ok(functie);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FunctieExists(int id)
        {
            return db.Functies.Count(e => e.id == id) > 0;
        }
    }
}