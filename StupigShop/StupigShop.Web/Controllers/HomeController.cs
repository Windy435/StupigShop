using System.Web.Mvc;

namespace StupigShop.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

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

        [ChildActionOnly]
        public ActionResult Footer()
        {
            return PartialView("Footer");
        }

        [ChildActionOnly]
        public ActionResult Header()
        {
            return PartialView("Header");
        }

        [ChildActionOnly]
        public ActionResult Category()
        {
            return PartialView("Category");
        }
    }
}