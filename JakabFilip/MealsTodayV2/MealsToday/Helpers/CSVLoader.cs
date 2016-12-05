using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using MealsToday.Data;
using MealsToday.Enums;

namespace MealsToday.Helpers
{
	public static class CSVLoader
	{
		private static UserRoles mapUserRole(string role)
		{
			switch (role.ToLower())
			{
				case "poweruser":
				case "user":
					return UserRoles.User;
				case "mealsadministrator":
					return UserRoles.MealsAdministrator;
				case "ordersadministrator":
					return UserRoles.OrdersAdministrator;
				case "reportingadmin":
				case "reportingadministrator":
					return UserRoles.ReportingAdministrator;
			}
			throw new ArgumentOutOfRangeException();
		}

		private static User parseUserRow(string row)
		{
			var user = new User();

			string[] dataParts = row.Split(';');

			user.UserId = Convert.ToInt32(dataParts[0]);
			user.Username = dataParts[1];
			user.FirstName = dataParts[2];
			user.LastName = dataParts[3];
			user.Password = dataParts[4];

			if (dataParts.Length == 6)
			{
				user.Roles.Add(mapUserRole(dataParts[5]));
			}
			else
			{
				for (int i = 5; i < dataParts.Length; i++)
				{
					user.Roles.Add(mapUserRole(dataParts[i].Trim(';')));
				}
			}

			return user;
		}

		private static Allergen parseAllergenRow(string row)
		{
			Allergen allergen = new Allergen();

			string[] pom = row.Split(';');
			allergen.AllergenId = Convert.ToInt32(pom[0]);
			allergen.Name = pom[1];
			return allergen;
		}

		private static Meal parseMealRow(string row)
		{
			Meal meal = new Meal();

			string[] pom = row.Split(';');
			meal.MealId = Convert.ToInt32(pom[0]);
			meal.Name = pom[1];
			meal.Description = pom[2];
			meal.Calories = Convert.ToInt32(pom[3]);

			return meal;
		}

		public static List<User> LoadUserData(string filePath)
		{
			if (!File.Exists(filePath))
			{
				throw new FileNotFoundException("File not found", filePath);
			}

			var listUsers = new List<User>();

			string[] allLines = File.ReadAllLines(filePath);

			for (int i = 1; i < allLines.Length; i++)
			{
				var user = parseUserRow(allLines[i]);
				listUsers.Add(user);
			}

			return listUsers;
		}

		public static List<Allergen> LoadAllergenData(string filePath)
		{

			List<Allergen> allergens = new List<Allergen>(20);
			if (!File.Exists(filePath))
			{
				throw new FileNotFoundException("File not found");
			}
			var allLines = File.ReadAllLines(filePath);
			for (int i = 1; i < allLines.Length; i++)
			{
				allergens.Add(parseAllergenRow(allLines[i]));
			}
			return allergens;
		}

		public static List<Meal> LoadMealData(string filePath)
		{
			List<Meal> meals = new List<Meal>(20);
			if (!File.Exists(filePath))
			{
				throw new FileNotFoundException("File not found");
			}
			var allLines = File.ReadAllLines(filePath);
			for (int i = 1; i < allLines.Length; i++)
			{
				meals.Add(parseMealRow(allLines[i]));
			}
			return meals;
		}

		public static string GetCSVPath(FileTypes fileType)
		{
			var baseDirectory = ConfigurationManager.AppSettings["CSVFilesFolder"];

			switch (fileType)
			{
				case FileTypes.Meals:
					return Path.Combine(baseDirectory, "Meals.csv");
				case FileTypes.Users:
					return Path.Combine(baseDirectory, "Users.csv");
				case FileTypes.Orders:
					return Path.Combine(baseDirectory, "Orders.csv");
				case FileTypes.Allergens:
					return Path.Combine(baseDirectory, "Allergens.csv");
				default:
					throw new ArgumentOutOfRangeException(nameof(fileType), fileType, null);
			}
		}
	}

}