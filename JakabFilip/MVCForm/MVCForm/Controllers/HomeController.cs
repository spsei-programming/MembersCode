using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCForm.Models;
using MVCForm.Models.Enums;

namespace MVCForm.Controllers
{
	public class HomeController : Controller
	{
		public List<OrderModel> Orders
		{
			get
			{
				if (Session["Orders"] == null)
				{
					Session["Orders"] = new List<OrderModel>(20);
				}
				return (List<OrderModel>)Session["Orders"];
			}
		}

		public List<AccountModel> Accounts
		{
			get
			{
				if (Session["Accounts"] == null)
				{
					Session["Accounts"] = new List<AccountModel>();
				}
				return (List<AccountModel>)Session["Accounts"];
			}
		}

		public AccountModel CurrentUser
		{
			get
			{
				if (Session["CurrentUser"] == null)
				{
					Session["CurrentUser"] = new AccountModel();
				}
				return (AccountModel)Session["CurrentUser"];
			}
			set
			{
				if (Accounts.Contains(value))
				{
					Session["CurrentUser"] = value;
				}
				else
				{
					throw new UnauthorizedAccessException("User Not Found");
				}
			}
		}

		public List<MealModel> Meals
		{
			get
			{
				if (Session["Meals"] == null)
				{
					Session["Meals"] = new List<MealModel>();
				}
				return (List<MealModel>)Session["Meals"];
			}
		}

		public ActionResult Index()
		{
			Accounts.Add(new AccountModel
			{
				Birthday = new DateTime(),
				Email = "admin@admin.ad",
				Password = "admin",
				UserType = UserTypes.Externist
			});

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

		public ActionResult Forms()
		{
			return View();
		}

		public ActionResult Tables()
		{
			return View();
		}

		[HttpGet]
		public ActionResult CreateMeal(string mealName, int calories, MealType mealType, string[] allergens)
		{
			var meal = new MealModel
			{
				Name = mealName,
				Calories = calories,
				Id = Meals.Count,
				Type = mealType
			};
			foreach (string allergen in allergens)
			{
				switch (allergen.ToLower())
				{
					case "allergen1":
						meal.Allergens.Add(Allergens.Allergen1);
						break;
					case "allergen2":
						meal.Allergens.Add(Allergens.Allergen2);
						break;
					case "allergen3":
						meal.Allergens.Add(Allergens.Allergen3);
						break;
					case "allergen4":
						meal.Allergens.Add(Allergens.Allergen4);
						break;
					case "allergen5":
						meal.Allergens.Add(Allergens.Allergen5);
						break;
				}
			}

			Meals.Add(meal);

			return View();
		}

		[HttpGet]
		public ActionResult SaveOrder(int meal, DateTime dateTo)
		{
			var order = CreateOrderModel(meal, DateTime.Now, dateTo);

			Orders.Add(order);

			return View();
		}

		[HttpGet]
		public ActionResult Register(string email, string password, string userType, DateTime birthday)
		{
			if (Accounts.Any(account => account.Email == email))
			{
				ViewData["RegisterMsg"] = "Email is already Taken";
				return View();
			}
			var registerAccount = new AccountModel
			{
				Birthday = birthday,
				Email = email,
				Password = password
			};

			switch (userType.ToLower())
			{
				case "student":
					registerAccount.UserType = UserTypes.Student;
					break;
				case "teacher":
					registerAccount.UserType = UserTypes.Teacher;
					break;
				case "externist":
					registerAccount.UserType = UserTypes.Externist;
					break;
			}

			Accounts.Add(registerAccount);

			ViewData["RegisterMsg"] = "Registration Successful";
			return View();
		}

		[HttpGet]
		public ActionResult Login(string email, string password)
		{
			foreach (AccountModel account in Accounts)
			{
				if (email != account.Email || password != account.Password) continue;
				CurrentUser = account;
				ViewData["LoginMsg"] = "Login successful";
				return View();
			}
			ViewData["LoginMsg"] = "Email or password is incorrect";
			return View();
		}

		private OrderModel CreateOrderModel(int meal, DateTime dateFrom, DateTime dateTo /*string date*/)
		{
			OrderModel order = new OrderModel
			{
				Client = ((AccountModel)Session["CurrentUser"]).Email,
				MealId = meal,
				DateFrom = dateFrom,
				DateTo = dateTo
			};

			return order;
		}
	}
}