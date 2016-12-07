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
	public class Program
	{
		public static void Main(string[] args)
		{
			Initialize();

			LogIn();

			Console.WriteLine("Current User: {0}", Context.CurrentUser);
		}

		public static void Initialize()
		{
			var users = CSVLoader.LoadUserData(CSVLoader.GetCSVPath(FileTypes.Users));
			Context.AllUsers = users;

			var allergens = CSVLoader.LoadAllergenData(CSVLoader.GetCSVPath(FileTypes.Allergens));
			Context.Allergens = allergens;

			var meals = CSVLoader.LoadMealData(CSVLoader.GetCSVPath(FileTypes.Meals));
			Context.Meals = meals;

			foreach (KeyValuePair<int, Allergen> mapOfAllergen in Context.MapOfAllergens)
			{
				Console.WriteLine($"Allergen with key {mapOfAllergen.Key} is {mapOfAllergen.Value.Name}");
			}
		}

		public static void LogIn()
		{
			Console.Write("Username: ");
			var username = Console.ReadLine();
			Console.Write("Password: ");
			var password = Console.ReadLine();

			foreach (var user in Context.AllUsers)
			{
				if (!user.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase) || user.Password != password) continue;
				Console.WriteLine("Ur now logged in.");
				Context.CurrentUser = user;
				return;
			}

			throw new UnauthorizedAccessException();
		}
	}
}
