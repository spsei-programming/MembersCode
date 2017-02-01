using System.Web.Mvc;

namespace MVCForms.Controllers
{
	public class BookingController : Controller
	{
		public ActionResult Table()
		{
			return View();
		}

		[HttpPost]
		public ActionResult SaveTable()
		{
			return View();
		}
	}
}