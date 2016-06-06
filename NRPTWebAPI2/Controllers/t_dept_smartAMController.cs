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
using System.Web.Http.OData;
using AutoMapper;
using NRPTmodel;

namespace NRPTWebAPI2.Controllers
{
    public class t_dept_smartControllerAM : ApiController
    {
        public t_dept_smartControllerAM(IMapper mapper)
        {
            _mapper = mapper;
        }

        private nrptEDM db = new nrptEDM();

        private IMapper _mapper;

        //orig api
        //// GET: api/t_dept_smart
        //public IQueryable<t_dept_smart> Gett_dept_smart()
        //{
        //    return db.t_dept_smart;
        //}
        [EnableQuery]
        public IEnumerable<t_dept_smartDTO> Gett_dept_smart()
        {
            // with automapper injected
            var depts = db.t_dept_smart
                          .Where(x => x.dept_eff_stat_cd == "A")
                          .OrderByDescending(x => x.dept_budg_cd);
            return _mapper.Map<IEnumerable<t_dept_smartDTO>>(depts);
        }


        // GET: api/t_dept_smart/5
        [ResponseType(typeof(t_dept_smart))]
        public IHttpActionResult Gett_dept_smart(string id)
        {
            t_dept_smart t_dept_smart = db.t_dept_smart.Find(id);
            if (t_dept_smart == null)
            {
                return NotFound();
            }

            return Ok(t_dept_smart);
        }

        // PUT: api/t_dept_smart/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putt_dept_smart(string id, t_dept_smart t_dept_smart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != t_dept_smart.dept_id)
            {
                return BadRequest();
            }

            db.Entry(t_dept_smart).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!t_dept_smartExists(id))
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

        // POST: api/t_dept_smart
        [ResponseType(typeof(t_dept_smart))]
        public IHttpActionResult Postt_dept_smart(t_dept_smart t_dept_smart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.t_dept_smart.Add(t_dept_smart);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (t_dept_smartExists(t_dept_smart.dept_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = t_dept_smart.dept_id }, t_dept_smart);
        }

        // DELETE: api/t_dept_smart/5
        [ResponseType(typeof(t_dept_smart))]
        public IHttpActionResult Deletet_dept_smart(string id)
        {
            t_dept_smart t_dept_smart = db.t_dept_smart.Find(id);
            if (t_dept_smart == null)
            {
                return NotFound();
            }

            db.t_dept_smart.Remove(t_dept_smart);
            db.SaveChanges();

            return Ok(t_dept_smart);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool t_dept_smartExists(string id)
        {
            return db.t_dept_smart.Count(e => e.dept_id == id) > 0;
        }
    }
}