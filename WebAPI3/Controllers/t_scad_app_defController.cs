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
    builder.EntitySet<t_scad_app_def>("t_scad_app_def");
    builder.EntitySet<t_prap_proj_scad>("t_prap_proj_scad"); 
    config.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class t_scad_app_defController : ODataController
    {
        private AppEDM db = new AppEDM();

        // GET: odata/t_scad_app_def
        [EnableQuery]
        public IQueryable<t_scad_app_def> Gett_scad_app_def()
        {
            return db.t_scad_app_def;
        }

        // GET: odata/t_scad_app_def(5)
        [EnableQuery]
        public SingleResult<t_scad_app_def> Gett_scad_app_def([FromODataUri] int key)
        {
            return SingleResult.Create(db.t_scad_app_def.Where(t_scad_app_def => t_scad_app_def.scad_id == key));
        }

        // PUT: odata/t_scad_app_def(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<t_scad_app_def> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            t_scad_app_def t_scad_app_def = db.t_scad_app_def.Find(key);
            if (t_scad_app_def == null)
            {
                return NotFound();
            }

            patch.Put(t_scad_app_def);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!t_scad_app_defExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(t_scad_app_def);
        }

        // POST: odata/t_scad_app_def
        public IHttpActionResult Post(t_scad_app_def t_scad_app_def)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.t_scad_app_def.Add(t_scad_app_def);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (t_scad_app_defExists(t_scad_app_def.scad_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(t_scad_app_def);
        }

        // PATCH: odata/t_scad_app_def(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<t_scad_app_def> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            t_scad_app_def t_scad_app_def = db.t_scad_app_def.Find(key);
            if (t_scad_app_def == null)
            {
                return NotFound();
            }

            patch.Patch(t_scad_app_def);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!t_scad_app_defExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(t_scad_app_def);
        }

        // DELETE: odata/t_scad_app_def(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            t_scad_app_def t_scad_app_def = db.t_scad_app_def.Find(key);
            if (t_scad_app_def == null)
            {
                return NotFound();
            }

            db.t_scad_app_def.Remove(t_scad_app_def);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/t_scad_app_def(5)/t_prap_proj_scad
        [EnableQuery]
        public IQueryable<t_prap_proj_scad> Gett_prap_proj_scad([FromODataUri] int key)
        {
            return db.t_scad_app_def.Where(m => m.scad_id == key).SelectMany(m => m.t_prap_proj_scad);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool t_scad_app_defExists(int key)
        {
            return db.t_scad_app_def.Count(e => e.scad_id == key) > 0;
        }
    }
}
