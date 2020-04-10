using OdeFood.Web.Models;
using System.Configuration;
using System.Web.Mvc;

namespace OdeFood.Web.Controllers
{
    public class GreetingController : Controller
    {
        // GET: Greeting
        public ActionResult Index()
        {
            var model = new GreetingViewModel();
            model.Message = ConfigurationManager.AppSettings["message"];
            return View(model);
        }

        public ActionResult NewLook()
        {
            return View();
        }
    }
}