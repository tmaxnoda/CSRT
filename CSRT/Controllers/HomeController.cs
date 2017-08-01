using System.Web.Mvc;

namespace CSRT.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        //[Route("home/selectroles")]
        public ActionResult SelectRoles() => View();

        public ActionResult LandingPage()
        {
            return View("land");
        }
        [Authorize(Roles = "Security")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}