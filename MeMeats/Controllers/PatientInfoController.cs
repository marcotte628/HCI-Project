using HCIProject.Models.DataRetriever;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HCIProject.Controllers
{
    public class PatientInfoController : Controller
    {
        private DataRetriever _builder = new DataRetriever();
        // GET: PatientInfo
        public ActionResult Index()
        {
            return View("PatientInfo", "", "");
        }

        [HttpGet]
        public ActionResult GetData()
        {

            // param value
            string pid = Request.QueryString["pid"];

            //call query DB
            string content = _builder.GetPatientData(pid);
            return Content(content);
        }
    }

}