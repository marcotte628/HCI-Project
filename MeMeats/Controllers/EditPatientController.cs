using HCIProject.Models.DataRetriever;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HCIProject.Controllers
{
    public class EditPatientController : Controller
    {
        private DataRetriever _builder = new DataRetriever();
        // GET: EditPatient
        public ActionResult Index()
        {
            return View("EditPatient", "", "");
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

        [HttpGet]
        public ActionResult UpdateData()
        {
            // param value
            string pid = Request.QueryString["pid"];
            string dob = Request.QueryString["dob"];
            string height = Request.QueryString["height"];
            string weight = Request.QueryString["weight"];
            string note = Request.QueryString["note"];
            string name = Request.QueryString["name"];

            //call query DB
            string content = _builder.UpdatePatient(pid, name, dob, height, weight, note);
            return Content(content);
        }
    }
}