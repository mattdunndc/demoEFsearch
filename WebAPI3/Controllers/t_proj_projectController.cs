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
    builder.EntitySet<t_proj_project>("t_proj_project");
    builder.EntitySet<t_prdp_proj_dept>("t_prdp_proj_dept"); 
    builder.EntitySet<t_prin_proj_inst>("t_prin_proj_inst"); 
    config.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    //[ODataRoutePrefix("project")]
    public class t_proj_projectController : ODataController
    {
        private projEDM db = new projEDM();

        ////////////
        ////
        [HttpGet]
        [ODataRoute("GetNextId")]
        public IHttpActionResult GetNextId()
        {
            int nextId = db.t_proj_project.OrderByDescending(i => i.proj_id).FirstOrDefault().proj_id;
            nextId = nextId + 1;
            return Ok(nextId);
        }
        ///
        // GET: odata/t_proj_project
        [EnableQuery]
        public IQueryable<t_proj_project> Gett_proj_project()
        {
            return db.t_proj_project;
        }

        // GET: odata/t_proj_project(5)
        [EnableQuery]
        public SingleResult<t_proj_project> Gett_proj_project([FromODataUri] int key)
        {
            return SingleResult.Create(db.t_proj_project.Where(t_proj_project => t_proj_project.proj_id == key));
        }

        // PUT: odata/t_proj_project(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<t_proj_project> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            t_proj_project t_proj_project = db.t_proj_project.Find(key);
            if (t_proj_project == null)
            {
                return NotFound();
            }

            patch.Put(t_proj_project);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!t_proj_projectExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(t_proj_project);
        }

        // POST: odata/t_proj_project
        public IHttpActionResult Post(t_proj_project t_proj_project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.t_proj_project.Add(t_proj_project);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (t_proj_projectExists(t_proj_project.proj_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(t_proj_project);
        }

        // PATCH: odata/t_proj_project(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<t_proj_project> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            t_proj_project t_proj_project = db.t_proj_project.Find(key);
            if (t_proj_project == null)
            {
                return NotFound();
            }

            patch.Patch(t_proj_project);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!t_proj_projectExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(t_proj_project);
        }

        // DELETE: odata/t_proj_project(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            t_proj_project t_proj_project = db.t_proj_project.Find(key);
            if (t_proj_project == null)
            {
                return NotFound();
            }

            db.t_proj_project.Remove(t_proj_project);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/t_proj_project(5)/t_prdp_proj_dept
        [EnableQuery]
        public IQueryable<t_prdp_proj_dept> Gett_prdp_proj_dept([FromODataUri] int key)
        {
            return db.t_proj_project.Where(m => m.proj_id == key).SelectMany(m => m.t_prdp_proj_dept);
        }

        // GET: odata/t_proj_project(5)/t_prin_proj_inst
        [EnableQuery]
        public IQueryable<t_prin_proj_inst> Gett_prin_proj_inst([FromODataUri] int key)
        {
            return db.t_proj_project.Where(m => m.proj_id == key).SelectMany(m => m.t_prin_proj_inst);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool t_proj_projectExists(int key)
        {
            return db.t_proj_project.Count(e => e.proj_id == key) > 0;
        }
    }
}
