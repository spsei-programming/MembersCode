using System.Security.Policy;
using System.Web.Mvc;

namespace MVCForm.Controllers
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