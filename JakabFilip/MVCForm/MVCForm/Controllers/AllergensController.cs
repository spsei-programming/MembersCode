using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCForms.Providers;

namespace MVCForm.Controllers
{
	public class AllergensController : Controller
	{
		// GET: Allergens
		public ActionResult Index()
		{
			DataBaseProvider provider = new DataBaseProvider();

			provider.CreateAllergen($"{DateTime.Now}", (byte)DateTime.Now.Second);

			return View();
		}
	}
}