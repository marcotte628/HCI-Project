using HCIProject.Models.DataRetriever;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HCIProject.Controllers
{
    public class LoginController : Controller
    {
        private DataRetriever _builder = new DataRetriever();
        // GET: Login
        public ActionResult Index()
        {
            return View("Login", "", "");
        }

        [HttpGet]
        public ActionResult Login(string username, string password)
        {
            //parameters
            string[] parameters = { "@username", "@password" };
            // param value
            string un = Request.QueryString["usr"];
            string pw = Request.QueryString["pw"];
            string[] values = { un, pw };
            //call query DB
            string content = _builder.GetQueryResult("FindAccountByUsernamePassword", parameters, values);
            return Content(content);
        }
    }
}