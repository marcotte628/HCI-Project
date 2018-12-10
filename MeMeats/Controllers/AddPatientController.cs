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
            return View("AddPatient", "", _builder.GetNoResult());
        }
    }
}