using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
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
					return UserRoles.ReportingAdministrator;

				default:
					throw new ArgumentOutOfRangeException();
			}
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
					user.Roles.Add(mapUserRole(dataParts[i].Trim('"')));
				}
			}

			return user;
		}

		private static Allergen parseAllergenRow(string row)
		{
			Allergen allergen = new Allergen();

			string[] dataParts = row.Split(';');

			allergen.AllergenId = Convert.ToInt32(dataParts[0]);
			allergen.Name = dataParts[1].Trim('"').Trim();
			Console.WriteLine(allergen.Name);

			return allergen;
		}

		private static Meal parseMealRow(string row)
		{
			var meal = new Meal();

			string[] dataPart = row.Split(';');


			return new Meal();
		}

		public static List<User> LoadUserData(string filePath)
		{
			if (!File.Exists(filePath))
			{
				throw new FileNotFoundException("File not found", filePath);
			}

			string[] allLines = File.ReadAllLines(filePath);
			List<User> users = new List<User>(allLines.Length-1);

			for (int i = 1; i < allLines.Length; i++)
			{
				users.Add(parseUserRow(allLines[i]));
			}

			return users;
		}

		public static List<Allergen> LoadAllergenData(string filePath)
		{
			if (!File.Exists(filePath))
				throw new FileNotFoundException("File not found", filePath);

			string[] allLines = File.ReadAllLines(filePath);
			List<Allergen> allergens = new List<Allergen>(allLines.Length-1);

			for (int i = 1; i < allLines.Length; i++)
			{
				allergens.Add(parseAllergenRow(allLines[i]));
			}

			return allergens;
		}

		public static List<Meal> LoadMealData(string filePath)
		{
			if (!File.Exists(filePath))
				throw new FileNotFoundException("File not found", filePath);

			string[] allLines = File.ReadAllLines(filePath);
			List<Meal> meals = new List<Meal>(allLines.Length - 1);

			for (int i = 1; i < allLines.Length; i++)
			{
				var meal = parseMealRow(allLines[i]);
				meals.Add(meal);
			}

			return meals;
		}

		public static string GetCSVPath(FileTypes fileType)
		{
			var baseDirectory = ConfigurationManager.AppSettings["CSVFilesFolder"];

			switch (fileType)
			{
				case FileTypes.Users:
					return Path.Combine(baseDirectory, "Users.csv");
				case FileTypes.Meals:
					return Path.Combine(baseDirectory, "Meals.csv");
				case FileTypes.Allergens:
					return Path.Combine(baseDirectory, "Allergens.csv");
				case FileTypes.Orders:
					return Path.Combine(baseDirectory, "Orders.csv");
				default:
					throw new ArgumentOutOfRangeException(nameof(fileType), fileType, null);
			}
		}
	}

}