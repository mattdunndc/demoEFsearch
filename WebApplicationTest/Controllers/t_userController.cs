using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using WebApplicationTest;

namespace WebApplicationTest.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using WebApplicationTest;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<t_user>("t_user");
    builder.EntitySet<t_dept_smart>("t_dept_smart"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class t_userController : ODataController
    {
        private sisdbEntities2 db = new sisdbEntities2();

        // GET: odata/t_user
        [EnableQuery]
        public IQueryable<t_user> Gett_user()
        {
            return db.t_user;
        }

        // GET: odata/t_user(5)
        [EnableQuery]
        public SingleResult<t_user> Gett_user([FromODataUri] string key)
        {
            return SingleResult.Create(db.t_user.Where(t_user => t_user.user_id == key));
        }

        // PUT: odata/t_user(5)
        public IHttpActionResult Put([FromODataUri] string key, Delta<t_user> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            t_user t_user = db.t_user.Find(key);
            if (t_user == null)
            {
                return NotFound();
            }

            patch.Put(t_user);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!t_userExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(t_user);
        }

        // POST: odata/t_user
        public IHttpActionResult Post(t_user t_user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.t_user.Add(t_user);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (t_userExists(t_user.user_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(t_user);
        }

        // PATCH: odata/t_user(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] string key, Delta<t_user> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            t_user t_user = db.t_user.Find(key);
            if (t_user == null)
            {
                return NotFound();
            }

            patch.Patch(t_user);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!t_userExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(t_user);
        }

        // DELETE: odata/t_user(5)
        public IHttpActionResult Delete([FromODataUri] string key)
        {
            t_user t_user = db.t_user.Find(key);
            if (t_user == null)
            {
                return NotFound();
            }

            db.t_user.Remove(t_user);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/t_user(5)/t_dept_smart
        [EnableQuery]
        public SingleResult<t_dept_smart> Gett_dept_smart([FromODataUri] string key)
        {
            return SingleResult.Create(db.t_user.Where(m => m.user_id == key).Select(m => m.t_dept_smart));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool t_userExists(string key)
        {
            return db.t_user.Count(e => e.user_id == key) > 0;
        }
    }
}
