using HCIProject.Models.DataRetriever;
using System.Web.Mvc;

namespace HCIProject.Controllers
{
    public class HomeController : Controller
    {
        private DataRetriever dataretreiver = new DataRetriever();
        public ActionResult Index()
        {
            return View("Index", "", dataretreiver.GetNoResult()); 
        }

        [HttpGet]
        public ActionResult GetData()
        {

            // param value
            string uid = Request.QueryString["uid"];

            // get all data from the Data folder
            // strip out all data that does not have the given uid
            // organize into json object 
            // send to front

            //call query DB
            string content = dataretreiver.GetAllPatientData();
            content = dataretreiver.GetNoResult();
            return Content(content);
        }

    }
}