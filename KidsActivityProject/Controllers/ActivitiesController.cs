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
using KidsActivityProject.DAL;
using KidsActivityProject.Models;

namespace KidsActivityProject.Controllers
{
    [RoutePrefix("activities")]
    public class ActivitiesController : ApiController
    {
        private ActivityContext db = new ActivityContext();

        // GET: api/Activities
        [Route("all")]
        public IHttpActionResult GetAllActivities()
        {
            return Ok(db.Activities.ToList());
        }

        // GET: api/Activities/5
        [ResponseType(typeof(Activity))]
        public async Task<IHttpActionResult> GetActivity(int id)
        {
            Activity activity = await db.Activities.FindAsync(id);
            if (activity == null)
            {
                return NotFound();
            }

            return Ok(activity);
        }

        // PUT: api/Activities/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutActivity(int id, Activity activity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != activity.ActivityID)
            {
                return BadRequest();
            }

            db.Entry(activity).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityExists(id))
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

        // POST: api/Activities
        [ResponseType(typeof(Activity))]
        public async Task<IHttpActionResult> PostActivity(Activity activity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Activities.Add(activity);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = activity.ActivityID }, activity);
        }

        // DELETE: api/Activities/5
        [ResponseType(typeof(Activity))]
        public async Task<IHttpActionResult> DeleteActivity(int id)
        {
            Activity activity = await db.Activities.FindAsync(id);
            if (activity == null)
            {
                return NotFound();
            }

            db.Activities.Remove(activity);
            await db.SaveChangesAsync();

            return Ok(activity);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ActivityExists(int id)
        {
            return db.Activities.Count(e => e.ActivityID == id) > 0;
        }
    }
}