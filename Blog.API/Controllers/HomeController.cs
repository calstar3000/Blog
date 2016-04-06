using System.Web.Mvc;

namespace Blog.API.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Title = "There will be bugs";

			return View();
		}

		public ActionResult New()
		{
			ViewBag.Title = "There will be bugs";

			return View();
		}

		public ActionResult Register()
		{
			ViewBag.Title = "There will be bugs";

			return View();
		}
	}
}
