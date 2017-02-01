using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCForms.Models;
using MVCForms.Models.Enums;

namespace MVCForms.Controllers
{
	public class HomeController : Controller
	{
		public List<OrderViewModel> Orders
		{
			get
			{
				if (Session["Orders"] == null)
				{
					Session["Orders"] = new List<OrderViewModel>(20);
				}

				return (List<OrderViewModel>) Session["Orders"];
			}
		}

		public ActionResult Index()
		{
			var session = Session;

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

		public ActionResult SaveOrder(string firstName, string lastName, string meal,
				string userType, string date)
		{
			var model = createOrderModel(firstName, lastName, meal, userType, date);
			
			Orders.Add(model);

			return View();
		}

		private OrderViewModel createOrderModel(string firstName, string lastName, string meal,
			string userType, string date)
		{
			OrderViewModel model = new OrderViewModel();

			model.FirstName = firstName;
			model.LastName = lastName;

			switch (userType.ToLower())
			{
				case "student":
					{
						model.UserType = UserTypes.Student;
						break;
					}
				case "teacher":
					{
						model.UserType = UserTypes.Teacher;
						break;
					}
				case "external":
					{
						model.UserType = UserTypes.External;
						break;
					}
			}

			model.MealId = Convert.ToInt32(meal);

			model.Date = DateTime.ParseExact(date, "dd.MM.yyyy", new DateTimeFormatInfo() { FirstDayOfWeek = DayOfWeek.Thursday });


			return model;
		}
	}
}