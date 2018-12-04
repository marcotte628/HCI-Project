using HCIProject.Models.QueryHandler;
using System.Web.Mvc;

namespace HCIProject.Controllers
{
    public class HomeController : Controller
    {
        private QueryResultBuilder _builder = new QueryResultBuilder();
        public ActionResult Index()
        {
            return View("Index", "", _builder.GetNoResult()); 
        }

        [HttpGet]
        public ActionResult GetData(string type)
        {
            //parameters
            string[] parameters = { "@cut" };
            // param value
            string cut = Request.QueryString["info"];
            string[] values = { cut };
            //call query DB
            string content = _builder.GetQueryResult("GetData", parameters, values);
            return Content(content);
        }

    }
}