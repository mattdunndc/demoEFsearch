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
using NRPTmodel.Models;

namespace WebAPI3.Controllers
{
    public class t_rrfa_rrqs_funct_area_refController : ApiController
    {
        private tempEDM db = new tempEDM();
        //
        //// custom route here
        /// http://localhost:55580/api/vvlu/rrqs_work_days_type_cd
        /// http://localhost:55580/api/vvlu/rrdp_district_cd SupervisoryOfficesBR GetAllDistricts()
        [Route("~/api/functionalarea/{nrpt_in}")]
        [ResponseType(typeof(t_rrfa_rrqs_funct_area_refDTO))]
        public IHttpActionResult Get(string nrpt_in)
        {
            IEnumerable<t_rrfa_rrqs_funct_area_refDTO> results = db.t_rrfa_rrqs_funct_area_ref.Where(x => (x.rrfa_nrpt_in == nrpt_in))
                                                        .OrderBy(x => x.rrfa_function_area_tx)
                                                        .Select(z => new t_rrfa_rrqs_funct_area_refDTO()
                                                        {
                                                            rrfa_cd = z.rrfa_cd,
                                                            rrfa_function_area_tx = z.rrfa_function_area_tx
                                                        });

            if (results == null)
            {
                return NotFound();
            }

            return Ok(results);
        }
        //
        // GET: api/t_rrfa_rrqs_funct_area_ref
        public IQueryable<t_rrfa_rrqs_funct_area_ref> Gett_rrfa_rrqs_funct_area_ref()
        {
            return db.t_rrfa_rrqs_funct_area_ref;
        }

        // GET: api/t_rrfa_rrqs_funct_area_ref/5
        [ResponseType(typeof(t_rrfa_rrqs_funct_area_ref))]
        public IHttpActionResult Gett_rrfa_rrqs_funct_area_ref(string id)
        {
            t_rrfa_rrqs_funct_area_ref t_rrfa_rrqs_funct_area_ref = db.t_rrfa_rrqs_funct_area_ref.Find(id);
            if (t_rrfa_rrqs_funct_area_ref == null)
            {
                return NotFound();
            }

            return Ok(t_rrfa_rrqs_funct_area_ref);
        }

        // PUT: api/t_rrfa_rrqs_funct_area_ref/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putt_rrfa_rrqs_funct_area_ref(string id, t_rrfa_rrqs_funct_area_ref t_rrfa_rrqs_funct_area_ref)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != t_rrfa_rrqs_funct_area_ref.rrfa_cd)
            {
                return BadRequest();
            }

            db.Entry(t_rrfa_rrqs_funct_area_ref).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!t_rrfa_rrqs_funct_area_refExists(id))
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

        // POST: api/t_rrfa_rrqs_funct_area_ref
        [ResponseType(typeof(t_rrfa_rrqs_funct_area_ref))]
        public IHttpActionResult Postt_rrfa_rrqs_funct_area_ref(t_rrfa_rrqs_funct_area_ref t_rrfa_rrqs_funct_area_ref)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.t_rrfa_rrqs_funct_area_ref.Add(t_rrfa_rrqs_funct_area_ref);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (t_rrfa_rrqs_funct_area_refExists(t_rrfa_rrqs_funct_area_ref.rrfa_cd))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = t_rrfa_rrqs_funct_area_ref.rrfa_cd }, t_rrfa_rrqs_funct_area_ref);
        }

        // DELETE: api/t_rrfa_rrqs_funct_area_ref/5
        [ResponseType(typeof(t_rrfa_rrqs_funct_area_ref))]
        public IHttpActionResult Deletet_rrfa_rrqs_funct_area_ref(string id)
        {
            t_rrfa_rrqs_funct_area_ref t_rrfa_rrqs_funct_area_ref = db.t_rrfa_rrqs_funct_area_ref.Find(id);
            if (t_rrfa_rrqs_funct_area_ref == null)
            {
                return NotFound();
            }

            db.t_rrfa_rrqs_funct_area_ref.Remove(t_rrfa_rrqs_funct_area_ref);
            db.SaveChanges();

            return Ok(t_rrfa_rrqs_funct_area_ref);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool t_rrfa_rrqs_funct_area_refExists(string id)
        {
            return db.t_rrfa_rrqs_funct_area_ref.Count(e => e.rrfa_cd == id) > 0;
        }
    }
}