using HCIProject.Models.DataRetriever;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HCIProject.Controllers
{
    public class ComparePatientController : Controller
    {
        private DataRetriever _builder = new DataRetriever();
        // GET: ComparePatient
        public ActionResult Index()
        {
            return View("ComparePatient", "", "");
        }
    }
}