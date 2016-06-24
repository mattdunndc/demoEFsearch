using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.ModelBinding;
using System.Web.OData;
using System.Web.OData.Query;
using System.Web.OData.Routing;
using NRPTmodel;

namespace WebAPI3.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.OData.Builder;
    using System.Web.OData.Extensions;
    using NRPTmodel;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<t_prap_proj_scad>("t_prap_proj_scad");
    builder.EntitySet<t_scad_app_def>("t_scad_app_def"); 
    config.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class t_prap_proj_scadController : ODataController
    {
        private AppEDM db = new AppEDM();

        // GET: odata/t_prap_proj_scad
        [EnableQuery]
        public IQueryable<t_prap_proj_scad> Gett_prap_proj_scad()
        {
            return db.t_prap_proj_scad;
        }

        // GET: odata/t_prap_proj_scad(5)
        [EnableQuery]
        public SingleResult<t_prap_proj_scad> Gett_prap_proj_scad([FromODataUri] int key)
        {
            return SingleResult.Create(db.t_prap_proj_scad.Where(t_prap_proj_scad => t_prap_proj_scad.prap_proj_id == key));
        }

        // PUT: odata/t_prap_proj_scad(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<t_prap_proj_scad> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            t_prap_proj_scad t_prap_proj_scad = db.t_prap_proj_scad.Find(key);
            if (t_prap_proj_scad == null)
            {
                return NotFound();
            }

            patch.Put(t_prap_proj_scad);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!t_prap_proj_scadExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(t_prap_proj_scad);
        }

        // POST: odata/t_prap_proj_scad
        public IHttpActionResult Post(t_prap_proj_scad t_prap_proj_scad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.t_prap_proj_scad.Add(t_prap_proj_scad);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (t_prap_proj_scadExists(t_prap_proj_scad.prap_proj_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(t_prap_proj_scad);
        }

        // PATCH: odata/t_prap_proj_scad(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<t_prap_proj_scad> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            t_prap_proj_scad t_prap_proj_scad = db.t_prap_proj_scad.Find(key);
            if (t_prap_proj_scad == null)
            {
                return NotFound();
            }

            patch.Patch(t_prap_proj_scad);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!t_prap_proj_scadExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(t_prap_proj_scad);
        }

        // DELETE: odata/t_prap_proj_scad(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            t_prap_proj_scad t_prap_proj_scad = db.t_prap_proj_scad.Find(key);
            if (t_prap_proj_scad == null)
            {
                return NotFound();
            }

            db.t_prap_proj_scad.Remove(t_prap_proj_scad);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/t_prap_proj_scad(5)/t_scad_app_def
        [EnableQuery]
        public SingleResult<t_scad_app_def> Gett_scad_app_def([FromODataUri] int key)
        {
            return SingleResult.Create(db.t_prap_proj_scad.Where(m => m.prap_proj_id == key).Select(m => m.t_scad_app_def));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool t_prap_proj_scadExists(int key)
        {
            return db.t_prap_proj_scad.Count(e => e.prap_proj_id == key) > 0;
        }
    }
}
