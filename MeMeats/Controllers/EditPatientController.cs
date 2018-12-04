using HCIProject.Models.QueryHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeMeats.Controllers
{
    public class EditPatientController : Controller
    {
        private QueryResultBuilder _builder = new QueryResultBuilder();
        // GET: EditPatient
        public ActionResult Index()
        {
            return View("EditPatient", "", _builder.GetNoResult());
        }
    }
}