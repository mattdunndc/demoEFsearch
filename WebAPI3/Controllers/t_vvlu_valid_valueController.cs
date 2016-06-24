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
using NRPTmodel;

namespace WebAPI3.Controllers
{
    public class t_vvlu_valid_valueController : ApiController
    {
        private vvluEDM db = new vvluEDM();
        
        //// need custom route here
        /// http://localhost:55580/api/vvlu/rrqs_work_days_type_cd
        /// http://localhost:55580/api/vvlu/rrdp_district_cd SupervisoryOfficesBR GetAllDistricts()
        [Route("~/api/vvlu/{col_nm}")]
        [ResponseType(typeof(t_vvlu_valid_valueDTO))]
        public IHttpActionResult Get(string col_nm)
        {
            DateTime now = DateTime.Now;
            IEnumerable<t_vvlu_valid_valueDTO> results = db.t_vvlu_valid_value.Where(x => (x.vvlu_col_nm == col_nm
                                                        && (now >= x.vvlu_eff_dt || x.vvlu_eff_dt == null)
                                                        && (now < x.vvlu_exp_dt || x.vvlu_exp_dt == null)
                                                        ))
                                                        .OrderBy(x => x.vvlu_disp_seq_nr)
                                                        .Select(z => new t_vvlu_valid_valueDTO()
                                                        {
                                                            vvlu_char_vlu_cd = z.vvlu_char_vlu_cd,
                                                            vvlu_desc_tx = z.vvlu_desc_tx
                                                        });

            if (results == null)
            {
                return NotFound();
            }

            return Ok(results);
        }
        
        // GET: api/t_vvlu_valid_value
        public IQueryable<t_vvlu_valid_value> Gett_vvlu_valid_value()
        {
            return db.t_vvlu_valid_value;
        }

        // GET: api/t_vvlu_valid_value/5
        [ResponseType(typeof(t_vvlu_valid_value))]
        public IHttpActionResult Gett_vvlu_valid_value(int id)
        {
            t_vvlu_valid_value t_vvlu_valid_value = db.t_vvlu_valid_value.Find(id);
            if (t_vvlu_valid_value == null)
            {
                return NotFound();
            }

            return Ok(t_vvlu_valid_value);
        }

        // PUT: api/t_vvlu_valid_value/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putt_vvlu_valid_value(int id, t_vvlu_valid_value t_vvlu_valid_value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != t_vvlu_valid_value.vvlu_id)
            {
                return BadRequest();
            }

            db.Entry(t_vvlu_valid_value).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!t_vvlu_valid_valueExists(id))
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

        // POST: api/t_vvlu_valid_value
        [ResponseType(typeof(t_vvlu_valid_value))]
        public IHttpActionResult Postt_vvlu_valid_value(t_vvlu_valid_value t_vvlu_valid_value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.t_vvlu_valid_value.Add(t_vvlu_valid_value);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (t_vvlu_valid_valueExists(t_vvlu_valid_value.vvlu_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = t_vvlu_valid_value.vvlu_id }, t_vvlu_valid_value);
        }

        // DELETE: api/t_vvlu_valid_value/5
        [ResponseType(typeof(t_vvlu_valid_value))]
        public IHttpActionResult Deletet_vvlu_valid_value(int id)
        {
            t_vvlu_valid_value t_vvlu_valid_value = db.t_vvlu_valid_value.Find(id);
            if (t_vvlu_valid_value == null)
            {
                return NotFound();
            }

            db.t_vvlu_valid_value.Remove(t_vvlu_valid_value);
            db.SaveChanges();

            return Ok(t_vvlu_valid_value);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool t_vvlu_valid_valueExists(int id)
        {
            return db.t_vvlu_valid_value.Count(e => e.vvlu_id == id) > 0;
        }
    }
}