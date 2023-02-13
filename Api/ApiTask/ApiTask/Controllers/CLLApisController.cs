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
using ApiTask.Models;

namespace ApiTask.Controllers
{
    public class CLLApisController : ApiController
    {
        private MvcEntities db = new MvcEntities();

        // GET: api/CLLApis
        public IQueryable<CLLApi> GetCLLApis()
        {
            return db.CLLApis;
        }

        // GET: api/CLLApis/5
        [ResponseType(typeof(CLLApi))]
        public IHttpActionResult GetCLLApi(int id)
        {
            CLLApi cLLApi = db.CLLApis.Find(id);
            if (cLLApi == null)
            {
                return NotFound();
            }

            return Ok(cLLApi);
        }

        // PUT: api/CLLApis/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCLLApi(int id, CLLApi cLLApi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cLLApi.IdCLL)
            {
                return BadRequest();
            }

            db.Entry(cLLApi).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CLLApiExists(id))
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

        // POST: api/CLLApis
        [ResponseType(typeof(CLLApi))]
        public IHttpActionResult PostCLLApi(CLLApi cLLApi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CLLApis.Add(cLLApi);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CLLApiExists(cLLApi.IdCLL))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cLLApi.IdCLL }, cLLApi);
        }

        // DELETE: api/CLLApis/5
        [ResponseType(typeof(CLLApi))]
        public IHttpActionResult DeleteCLLApi(int id)
        {
            CLLApi cLLApi = db.CLLApis.Find(id);
            if (cLLApi == null)
            {
                return NotFound();
            }

            db.CLLApis.Remove(cLLApi);
            db.SaveChanges();

            return Ok(cLLApi);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CLLApiExists(int id)
        {
            return db.CLLApis.Count(e => e.IdCLL == id) > 0;
        }
    }
}