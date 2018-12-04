using HCIProject.Models.QueryHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeMeats.Controllers
{
    public class PatientInfoController : Controller
    {
        private QueryResultBuilder _builder = new QueryResultBuilder();
        // GET: PatientInfo
        public ActionResult Index()
        {
            return View("PatientInfo", "", _builder.GetNoResult());
        }
    }
}