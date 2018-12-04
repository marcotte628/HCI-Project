using HCIProject.Models.QueryHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeMeats.Controllers
{
    public class AddPatientController : Controller
    {
        private QueryResultBuilder _builder = new QueryResultBuilder();
        // GET: AddPatient
        public ActionResult Index()
        {
            return View("AddPatient", "", _builder.GetNoResult());
        }
    }
}