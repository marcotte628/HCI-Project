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
            return View("EditPatient", "", _builder.GetNoResult());
        }
    }
}