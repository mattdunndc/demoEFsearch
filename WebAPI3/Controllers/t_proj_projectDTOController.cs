using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;
using NRPTmodel;

namespace WebAPI3.Controllers
{
    public class t_proj_projectDTOController : ApiController
    {
        private projEDM db = new projEDM();//

        /// <summary>
        //  Project aggregeate
        /// </summary>
        // GET: api/projects
        [Route("~/api/projects")]
        [ResponseType(typeof(t_proj_projectDTO))]
        public IHttpActionResult Get()
        {
            StringBuilder sb = new System.Text.StringBuilder();
            //  Create and execute raw SQL query.
            //string query = @"Select TOP dbo.fn_user_get_name(user_id) as 'fullName' from t_user";
            //string query = @"Select TOP 100 user_id from t_user";    
            string query = @"SELECT proj_id,
                            pobj_project_type_cd,
                            dbo.fn_vvlu_get_desc('pobj_project_type_cd',pobj_project_type_cd,null) AS Project_Type_Desc,
                            proj_project_nm, 
                            proj_project_desc_tx,
                            proj_contact_user_id,
                            dbo.fn_user_get_name(proj_contact_user_id) AS Contact,
                            proj_active_in,
                            proj_start_dt,
                            proj_end_dt,
                            proj_active_in,
                            COUNT(DISTINCT B.prap_scad_id) as Apps,
                            COUNT(DISTINCT D.prin_inst_id) as Institutions,
                            COUNT(DISTINCT F.prdp_dept_id) as Depts
                            FROM t_proj_project A
                            LEFT JOIN t_prap_proj_scad B ON A.proj_id = B.prap_proj_id
                            LEFT JOIN t_prin_proj_inst D ON A.proj_id = D.prin_proj_id
                            LEFT JOIN t_prdp_proj_dept F ON A.proj_id = F.prdp_proj_id";
            var gclause = @" GROUP BY proj_id, pobj_project_type_cd, proj_project_nm, proj_project_desc_tx,proj_contact_user_id,dbo.fn_user_get_name(proj_contact_user_id),
                           proj_active_in,proj_start_dt,proj_end_dt,proj_active_in";
            var oclause = @" ORDER BY proj_id";
            
            sb.Append(query).Append(gclause).Append(oclause);

            var results = db.Database.SqlQuery<t_proj_projectDTO>(sb.ToString()).ToList();

            if (results == null)
            {
                return NotFound();
            }
            return Ok((results));

            //}

        }
        ////////////////////////////////////
        /// <summary>
        //  Project aggregeate
        /// </summary>
        // GET: api/projects
        [Route("~/api/projectBanks/{proj_id?}")]
        [ResponseType(typeof(t_prin_proj_instDTO))]
        public IHttpActionResult GetProjBanks(int proj_id=0)
        {
            StringBuilder sb = new System.Text.StringBuilder();
            //  Create and execute raw SQL query.
            string query = @"SELECT A.prin_proj_id,A.prin_inst_id,B.inst_short_name,B.inst_occ_asgnd_id FROM t_prin_proj_inst A JOIN t_inst_institutn B ON prin_inst_id = B.inst_id ";
            var wclause = (proj_id == 0) ? "" : string.Format("WHERE A.prin_proj_id = {0} ", proj_id);
            
            sb.Append(query).Append(wclause);

            var results = db.Database.SqlQuery<t_prin_proj_instDTO>(sb.ToString()).ToList();

            if (results == null)
            {
                return NotFound();
            }
            return Ok((results));

            //}

        }

        /// <summary>
        //  Project aggregeate
        /// </summary>
        // GET: http://localhost:55580/api/projectApps/
        [Route("~/api/projectApps/{proj_id?}")]
        [ResponseType(typeof(t_prap_proj_scadDTO))]
        public IHttpActionResult GetProjApps(int proj_id = 0)
        {
            StringBuilder sb = new System.Text.StringBuilder();
            //  Create and execute raw SQL query.
            string query = @"SELECT A.prap_proj_id,A.prap_scad_id,B.scad_app_nm FROM t_prap_proj_scad A JOIN t_scad_app_def B ON A.prap_scad_id = B.scad_id ";
            var wclause = (proj_id == 0) ? "" : string.Format("WHERE A.prap_proj_id = {0} ", proj_id);

            sb.Append(query).Append(wclause);

            var results = db.Database.SqlQuery<t_prap_proj_scadDTO>(sb.ToString()).ToList();

            if (results == null)
            {
                return NotFound();
            }
            return Ok((results));

            //}

        }

        /// <summary>
        //  Project aggregeate
        /// </summary>
        // GET: http://localhost:55580/api/projectApps/
        [Route("~/api/projectDepts/{proj_id?}")]
        [ResponseType(typeof(t_prdp_proj_deptDTO))]
        public IHttpActionResult GetProjDepts(int proj_id = 0)
        {
            StringBuilder sb = new System.Text.StringBuilder();
            //  Create and execute raw SQL query.
            string query = @"SELECT A.prdp_proj_id,A.prdp_dept_id,B.dept_abrv_nm,B.dept_budg_cd FROM t_prdp_proj_dept A JOIN t_dept_smart B ON A.prdp_dept_id = B.dept_id ";
            var wclause = (proj_id == 0) ? "" : string.Format("WHERE A.prdp_proj_id = {0} ", proj_id);

            sb.Append(query).Append(wclause);

            var results = db.Database.SqlQuery<t_prdp_proj_deptDTO>(sb.ToString()).ToList();

            if (results == null)
            {
                return NotFound();
            }
            return Ok((results));

            //}

        }
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
