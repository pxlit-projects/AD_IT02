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
    public class vragensController : ApiController
    {
        private finahbackContext db = new finahbackContext();

        // GET: api/vragens
        public IQueryable<vragen> Getvragens()
        {
            return db.vragens;
        }

        // GET: api/vragens/5
        [ResponseType(typeof(vragen))]
        public async Task<IHttpActionResult> GetVragen(int id)
        {
            vragen vraag = await db.vragens.FindAsync(id);
            if (vraag == null)
            {
                return NotFound();
            }

            return Ok(vraag);
        }

        // PUT: api/vragens/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putvragen(int id, vragen vragen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vragen.id)
            {
                return BadRequest();
            }

            db.Entry(vragen).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!vragenExists(id))
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

        // POST: api/vragens
        [ResponseType(typeof(vragen))]
        public async Task<IHttpActionResult> Postvragen(vragen vragen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.vragens.Add(vragen);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = vragen.id }, vragen);
        }

        // DELETE: api/vragens/5
        [ResponseType(typeof(vragen))]
        public async Task<IHttpActionResult> Deletevragen(int id)
        {
            vragen vragen = await db.vragens.FindAsync(id);
            if (vragen == null)
            {
                return NotFound();
            }

            db.vragens.Remove(vragen);
            await db.SaveChangesAsync();

            return Ok(vragen);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool vragenExists(int id)
        {
            return db.vragens.Count(e => e.id == id) > 0;
        }
    }
}