using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using NRPTmodel;

namespace WebAPI3.Controllers
{
    public class t_userController : ApiController
    {
        private nrptEDM db = new nrptEDM();

        /////////////////////////////
        //// need custom route here
        // GET: api/t_dept_smart/5
        [Route("~/api/users")]
        [ResponseType(typeof(t_userDTOmin))]
        public IHttpActionResult Get()
        {
            StringBuilder sb = new System.Text.StringBuilder();
            //  Create and execute raw SQL query.
            //string query = @"Select TOP dbo.fn_user_get_name(user_id) as 'fullName' from t_user";
            //string query = @"Select TOP 100 user_id from t_user";    
            string query = @"SELECT user_id,dbo.fn_user_get_name(user_id) as 'fullName'	FROM t_user 
                             where user_wkas_in = 'Y' AND user_actv_in = 'Y' ";
            var oclause = " order by lower(dbo.fn_user_get_name(user_id))";
            sb.Append(query).Append(oclause);

            var results = db.Database.SqlQuery<t_userDTOmin>(sb.ToString()).ToList();

            if (results == null)
            {
                return NotFound();
            }
            return Ok((results));

            //}

        }
        ////////////////////////////////////
        // GET: api/t_user
        public IQueryable<t_user> Gett_user()
        {
            return db.t_user;
        }

        // GET: api/t_user/5
        [ResponseType(typeof(t_user))]
        public IHttpActionResult Gett_user(string id)
        {
            t_user t_user = db.t_user.Find(id);
            if (t_user == null)
            {
                return NotFound();
            }

            return Ok(t_user);
        }

        // PUT: api/t_user/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putt_user(string id, t_user t_user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != t_user.user_id)
            {
                return BadRequest();
            }

            db.Entry(t_user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!t_userExists(id))
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

        // POST: api/t_user
        [ResponseType(typeof(t_user))]
        public IHttpActionResult Postt_user(t_user t_user)
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

            return CreatedAtRoute("DefaultApi", new { id = t_user.user_id }, t_user);
        }

        // DELETE: api/t_user/5
        [ResponseType(typeof(t_user))]
        public IHttpActionResult Deletet_user(string id)
        {
            t_user t_user = db.t_user.Find(id);
            if (t_user == null)
            {
                return NotFound();
            }

            db.t_user.Remove(t_user);
            db.SaveChanges();

            return Ok(t_user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool t_userExists(string id)
        {
            return db.t_user.Count(e => e.user_id == id) > 0;
        }
    }
}