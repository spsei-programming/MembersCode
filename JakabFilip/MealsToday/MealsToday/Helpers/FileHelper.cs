using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Xml.Serialization;
using MealsToday.Data;
using MealsToday.Providers;

namespace MealsToday.Helpers
{
	public static class FileHelper
	{
		public static void FillDefaultMealFile()
		{
			var xmlSerializer = new XmlSerializer(typeof(List<Meal>));
			var listOfMeals = new List<Meal>
			{
				new Meal
				{
					Alergends = {1, 2, 3},
					Calories = 2500,
					//Id = 1,
					Name = "Knedlo vepro zelo"
				},
				new Meal
				{
					Alergends = {4, 5, 6},
					Calories = 3000,
					//Id = 2,
					Name = "Palacinky na sladko"
				},
				new Meal
				{
					Alergends = {7, 8, 9},
					Calories = 4230,
					//Id = 3,
					Name = "Kureci vyvar"
				}
			};
			listOfMeals.ForEach(x => x.CreateMeal());
			try
			{
				using (Stream stream = File.OpenWrite(@"Lists\DefaultMealList.xml"))
				{
					xmlSerializer.Serialize(stream, listOfMeals);
				}
			}
			catch (DirectoryNotFoundException e)
			{
				Console.WriteLine("Target Directory not found.\n{0}", e.Message);
			}
		}

		public static void FillMealList()
		{
			var xmlSerializer = new XmlSerializer(typeof(List<Meal>));
			var listOfMeals = new List<Meal>();
			using (Stream stream = File.OpenRead(@"Lists\DefaultMealList.xml"))
			{
				listOfMeals = xmlSerializer.Deserialize(stream) as List<Meal>;
			}
			using (Stream stream = File.OpenWrite(@"Lists\MealList.xml"))
			{
				xmlSerializer.Serialize(stream, listOfMeals);
			}
		}
	}
}