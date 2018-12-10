using HCIProject.Models.DataRetriever;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeMeats.Controllers
{
    public class PatientInfoController : Controller
    {
        private DataRetriever _builder = new DataRetriever();
        // GET: PatientInfo
        public ActionResult Index()
        {
            return View("PatientInfo", "", _builder.GetNoResult());
        }
    }
}