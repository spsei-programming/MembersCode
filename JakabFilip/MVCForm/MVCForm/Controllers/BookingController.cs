using System.Collections.Generic;
using System.Security.Policy;
using System.Web.Mvc;
using MVCForm.Models.Booking;

namespace MVCForm.Controllers
{
	public class BookingController : Controller
	{
		private List<BookTableVM> Bookings
		{
			get
			{
				if (Session["Booking"] == null)
				{
					Session["Bookings"] = new List<BookTableVM>();
				}
				return (List<BookTableVM>) Session["Booking"];
			}
		}

		public ActionResult Table()
		{
			return View(Bookings);
		}

		[HttpPost]
		public ActionResult SaveTable(BookTableVM model)
		{
			Bookings.Add(model);

			return RedirectToAction("Table");
		}
	}
}