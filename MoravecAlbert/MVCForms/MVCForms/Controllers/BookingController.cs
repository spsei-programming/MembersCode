using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCForms.Models.Booking;

namespace MVCForms.Controllers
{
	public class BookingController : Controller
	{
		public List<BookTableVM> Bookings
		{
			get
			{
				if (Session["Bookings"] == null)
				{
					Session["Bookings"] = new List<BookTableVM>(10);
				}

				return (List<BookTableVM>) Session["Bookings"];
			}
		}

		// GET: Booking
		public ActionResult Table()
		{
			return View();
		}

		[HttpPost]
		public ActionResult SaveTable(BookTableVM model)
		{
			Bookings.Add(model);
			return RedirectToAction("Table");
		}
	}
}