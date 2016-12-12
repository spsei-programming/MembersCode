using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MealsToday.Data;
using MealsToday.Enums;
using MealsToday.Helpers;

namespace MealsToday
{
	class Program
	{
		static void Main(string[] args)
		{
			Initialize();
			LogIn(Context.AllUsers);

			Context.AllUsers.ForEach(x=>Console.WriteLine(x.FullName));
		}

		public static void Initialize()
		{
			Context.AllUsers = CSVLoader.LoadUserData(CSVLoader.GetCSVPath(FileTypes.Users));
			Context.Meals = CSVLoader.LoadMealData(CSVLoader.GetCSVPath(FileTypes.Meals));
			Context.Allergens = CSVLoader.LoadAllergenData(CSVLoader.GetCSVPath(FileTypes.Allergens));
		}

		public static void LogIn(List<User> users)
		{
			Console.Write("Username: ");
			var username = Console.ReadLine();
			Console.Write("Password: ");
			var password = Console.ReadLine();

			bool userFound = false;
			foreach (var user in users)
			{
				if (username.Equals(user.Username) && password.Equals(user.Password))
				{
					Context.CurrentUser = user;
					userFound = true;
					break;
				}
			}

			if (!userFound)
			{
				throw new UnauthorizedAccessException("Wrong username or password");
			}
		}
	}
}
