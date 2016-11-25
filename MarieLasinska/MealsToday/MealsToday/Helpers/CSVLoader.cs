using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using MealsToday.Classes;
using System.IO;

namespace MealsToday.Helpers
{
	static class CSVLoader
	{
		//----------PRIVATE----------
		//ParseUserRow
		private static User ParseUserRow (string row)
		{
			User user = new User();
			
			string[] pom = row.Split(';');
			user.UserId = Convert.ToInt32(pom[0]);
			user.Username=pom[1];
			user.FirstName = pom[2];
			user.LastName = pom[3];

			return user;
		}
		//ParseMealRow
	 private static Meal ParseMealRow(string row)
		{
			Meal meal = new Meal();

			string[] pom = row.Split(';');
			meal.MealId = Convert.ToInt32(pom[0]);
			meal.Name = pom[1];
			meal.Description = pom[2];
			meal.Calories = Convert.ToInt32(pom[3]);

			return meal;
		}
		//ParseAllergenRow
	 private static Allergen ParseAllergenRow(string row)
		{
			Allergen allergen = new Allergen();

			string[] pom = row.Split(';');
			allergen.AlergenId = Convert.ToInt32(pom[0]);
			allergen.Name = pom[1];
			return allergen;
		}
		//----------PUBLIC----------
		//LoadUserData
	 public static List<User> LoadUserData(string path)
	 {
		 List<User> users = new List<User>(50);
		 if (!File.Exists(path))
		 {
			 throw new FileNotFoundException("File not found");
		 }
		 var allLines = File.ReadAllLines(path);
		 for (int i = 1; i < allLines.Length; i++)
		 {
			 users.Add(ParseUserRow(allLines[i]));
		 }
		 return users;
	 }
		//LoadMealData
	 public static List<Meal> LoadMealData(string path)
		{
			List<Meal> meals = new List<Meal>(20);
			if (!File.Exists(path))
			{
				throw new FileNotFoundException("File not found");
			}
			var allLines = File.ReadAllLines(path);
			for (int i = 1; i < allLines.Length; i++)
			{
				meals.Add(ParseMealRow(allLines[i]));
			}
			return meals;
		}
		//LoadAllergerData
	 public static List<Allergen> LoadAllergenData(string path)
		{
			List<Allergen> allergens = new List<Allergen>(20);
			if (!File.Exists(path))
			{
				throw new FileNotFoundException("File not found");
			}
			var allLines = File.ReadAllLines(path);
			for (int i = 1; i < allLines.Length; i++)
			{
				allergens.Add(ParseAllergenRow(allLines[i]));
			}
			return allergens;
		}
	}
}
