using HCIProject.Models.QueryHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeMeats.Controllers
{
    public class ComparePatientController : Controller
    {
        private QueryResultBuilder _builder = new QueryResultBuilder();
        // GET: ComparePatient
        public ActionResult Index()
        {
            return View("ComparePatient", "", _builder.GetNoResult());
        }
    }
}