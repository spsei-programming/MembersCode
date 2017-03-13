using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MealsToday.MVC.Providers;

namespace MVCForm.Controllers
{
	public class AllergensController : Controller
	{
		// GET: Allergens
		public ActionResult Index()
		{
			DatabaseProvider provider = new DatabaseProvider();
		    provider.GetAllergens();
            //provider.CreateAllergen($"{DateTime.Now}", (byte) DateTime.Now.Second);

            return View();
		}
	}
}