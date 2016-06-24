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
using NRPTmodel.Models;

namespace WebAPI3.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.OData.Builder;
    using System.Web.OData.Extensions;
    using NRPTmodel.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<t_stcd_state_cd>("t_stcd_state_cd");
    builder.EntitySet<t_rrcs_city_state_near_rrlc>("t_rrcs_city_state_near_rrlc"); 
    config.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class t_stcd_state_cdController : ODataController
    {
        private tempEDM db = new tempEDM();

        // GET: odata/t_stcd_state_cd
        [EnableQuery]
        public IQueryable<t_stcd_state_cd> Gett_stcd_state_cd()
        {
            return db.t_stcd_state_cd;
        }

        // GET: odata/t_stcd_state_cd(5)
        [EnableQuery]
        public SingleResult<t_stcd_state_cd> Gett_stcd_state_cd([FromODataUri] string key)
        {
            return SingleResult.Create(db.t_stcd_state_cd.Where(t_stcd_state_cd => t_stcd_state_cd.stcd_state_abbrv == key));
        }

        // PUT: odata/t_stcd_state_cd(5)
        public IHttpActionResult Put([FromODataUri] string key, Delta<t_stcd_state_cd> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            t_stcd_state_cd t_stcd_state_cd = db.t_stcd_state_cd.Find(key);
            if (t_stcd_state_cd == null)
            {
                return NotFound();
            }

            patch.Put(t_stcd_state_cd);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!t_stcd_state_cdExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(t_stcd_state_cd);
        }

        // POST: odata/t_stcd_state_cd
        public IHttpActionResult Post(t_stcd_state_cd t_stcd_state_cd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.t_stcd_state_cd.Add(t_stcd_state_cd);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (t_stcd_state_cdExists(t_stcd_state_cd.stcd_state_abbrv))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(t_stcd_state_cd);
        }

        // PATCH: odata/t_stcd_state_cd(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] string key, Delta<t_stcd_state_cd> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            t_stcd_state_cd t_stcd_state_cd = db.t_stcd_state_cd.Find(key);
            if (t_stcd_state_cd == null)
            {
                return NotFound();
            }

            patch.Patch(t_stcd_state_cd);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!t_stcd_state_cdExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(t_stcd_state_cd);
        }

        // DELETE: odata/t_stcd_state_cd(5)
        public IHttpActionResult Delete([FromODataUri] string key)
        {
            t_stcd_state_cd t_stcd_state_cd = db.t_stcd_state_cd.Find(key);
            if (t_stcd_state_cd == null)
            {
                return NotFound();
            }

            db.t_stcd_state_cd.Remove(t_stcd_state_cd);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/t_stcd_state_cd(5)/t_rrcs_city_state_near_rrlc
        [EnableQuery]
        public IQueryable<t_rrcs_city_state_near_rrlc> Gett_rrcs_city_state_near_rrlc([FromODataUri] string key)
        {
            return db.t_stcd_state_cd.Where(m => m.stcd_state_abbrv == key).SelectMany(m => m.t_rrcs_city_state_near_rrlc);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool t_stcd_state_cdExists(string key)
        {
            return db.t_stcd_state_cd.Count(e => e.stcd_state_abbrv == key) > 0;
        }
    }
}
