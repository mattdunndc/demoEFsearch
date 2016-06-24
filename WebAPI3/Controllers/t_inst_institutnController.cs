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
    builder.EntitySet<t_inst_institutn>("t_inst_institutn");
    builder.EntitySet<t_rrac_activity>("t_rrac_activity"); 
    builder.EntitySet<t_rrqs_resource_request>("t_rrqs_resource_request"); 
    config.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class t_inst_institutnController : ODataController
    {
        private nrptEDM db = new nrptEDM();

        // GET: odata/t_inst_institutn
        [EnableQuery]
        public IQueryable<t_inst_institutn> Gett_inst_institutn()
        {
            return db.t_inst_institutn;
        }

        // GET: odata/t_inst_institutn(5)
        [EnableQuery]
        public SingleResult<t_inst_institutn> Gett_inst_institutn([FromODataUri] int key)
        {
            return SingleResult.Create(db.t_inst_institutn.Where(t_inst_institutn => t_inst_institutn.inst_id == key));
        }

        // PUT: odata/t_inst_institutn(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<t_inst_institutn> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            t_inst_institutn t_inst_institutn = db.t_inst_institutn.Find(key);
            if (t_inst_institutn == null)
            {
                return NotFound();
            }

            patch.Put(t_inst_institutn);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!t_inst_institutnExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(t_inst_institutn);
        }

        // POST: odata/t_inst_institutn
        public IHttpActionResult Post(t_inst_institutn t_inst_institutn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.t_inst_institutn.Add(t_inst_institutn);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (t_inst_institutnExists(t_inst_institutn.inst_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(t_inst_institutn);
        }

        // PATCH: odata/t_inst_institutn(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<t_inst_institutn> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            t_inst_institutn t_inst_institutn = db.t_inst_institutn.Find(key);
            if (t_inst_institutn == null)
            {
                return NotFound();
            }

            patch.Patch(t_inst_institutn);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!t_inst_institutnExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(t_inst_institutn);
        }

        // DELETE: odata/t_inst_institutn(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            t_inst_institutn t_inst_institutn = db.t_inst_institutn.Find(key);
            if (t_inst_institutn == null)
            {
                return NotFound();
            }

            db.t_inst_institutn.Remove(t_inst_institutn);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/t_inst_institutn(5)/t_rrac_activity
        [EnableQuery]
        public IQueryable<t_rrac_activity> Gett_rrac_activity([FromODataUri] int key)
        {
            return db.t_inst_institutn.Where(m => m.inst_id == key).SelectMany(m => m.t_rrac_activity);
        }

        // GET: odata/t_inst_institutn(5)/t_rrqs_resource_request
        [EnableQuery]
        public IQueryable<t_rrqs_resource_request> Gett_rrqs_resource_request([FromODataUri] int key)
        {
            return db.t_inst_institutn.Where(m => m.inst_id == key).SelectMany(m => m.t_rrqs_resource_request);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool t_inst_institutnExists(int key)
        {
            return db.t_inst_institutn.Count(e => e.inst_id == key) > 0;
        }
    }
}
