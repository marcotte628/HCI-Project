using HCIProject.Models.DataRetriever;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HCIProject.Controllers
{
    public class AddPatientController : Controller
    {
        private DataRetriever _builder = new DataRetriever();
        // GET: AddPatient
        public ActionResult Index()
        {
            return View("AddPatient", "", "");
        }

        [HttpGet]
        public ActionResult CreateData()
        {
            // param value
            string dob = Request.QueryString["dob"];
            string height = Request.QueryString["height"];
            string weight = Request.QueryString["weight"];
            string note = Request.QueryString["note"];
            string name = Request.QueryString["name"];

            //call query DB
            string content = _builder.CreatePatient(name, dob, height, weight, note);
            return Content(content);
        }
    }
}