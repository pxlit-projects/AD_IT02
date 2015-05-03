﻿using System;
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
    public class CategoriesController : ApiController
    {
        private finahbackContext db = new finahbackContext();

        // GET: api/Categories
        public IQueryable<Categorie> GetCategories()
        {
            return db.Categories;
        }

        // GET: api/Categories/5
        [ResponseType(typeof(Categorie))]
        public async Task<IHttpActionResult> GetPersoon(int id)
        {
            IQueryable<Categorie> categorie = db.Categories.Where(i => i.id == id);

            if (categorie == null)
            {
                return NotFound();
            }

            return Ok(categorie);
        }

        // PUT: api/Categories/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCategorie(int id, Categorie categorie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categorie.id)
            {
                return BadRequest();
            }

            db.Entry(categorie).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategorieExists(id))
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

        // POST: api/Categories
        [ResponseType(typeof(Categorie))]
        public async Task<IHttpActionResult> PostCategorie(Categorie categorie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Categories.Add(categorie);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = categorie.id }, categorie);
        }

        // DELETE: api/Categories/5
        [ResponseType(typeof(Categorie))]
        public async Task<IHttpActionResult> DeleteCategorie(int id)
        {
            Categorie categorie = await db.Categories.FindAsync(id);
            if (categorie == null)
            {
                return NotFound();
            }

            db.Categories.Remove(categorie);
            await db.SaveChangesAsync();

            return Ok(categorie);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategorieExists(int id)
        {
            return db.Categories.Count(e => e.id == id) > 0;
        }
    }
}