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
using KidsActivityProject.DAL;
using KidsActivityProject.Models;

namespace KidsActivityProject.Controllers
{
    public class KidsController : ApiController
    {
        private ActivityContext db = new ActivityContext();

        // GET: api/Kids
        public IQueryable<Kid> GetKids()
        {
            return db.Kids;
        }

        // GET: api/Kids/5
        [ResponseType(typeof(Kid))]
        public async Task<IHttpActionResult> GetKid(int id)
        {
            Kid kid = await db.Kids.FindAsync(id);
            if (kid == null)
            {
                return NotFound();
            }

            return Ok(kid);
        }

        // PUT: api/Kids/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutKid(int id, Kid kid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kid.KidID)
            {
                return BadRequest();
            }

            db.Entry(kid).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KidExists(id))
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

        // POST: api/Kids
        [ResponseType(typeof(Kid))]
        public async Task<IHttpActionResult> PostKid(Kid kid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Kids.Add(kid);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = kid.KidID }, kid);
        }

        // DELETE: api/Kids/5
        [ResponseType(typeof(Kid))]
        public async Task<IHttpActionResult> DeleteKid(int id)
        {
            Kid kid = await db.Kids.FindAsync(id);
            if (kid == null)
            {
                return NotFound();
            }

            db.Kids.Remove(kid);
            await db.SaveChangesAsync();

            return Ok(kid);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KidExists(int id)
        {
            return db.Kids.Count(e => e.KidID == id) > 0;
        }
    }
}