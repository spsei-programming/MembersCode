using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using MealsToday.Data;

namespace MealsToday.Providers
{
	public static class MealsProvider
	{
		public static List<Meal> GetDefaultMeals()
		{
			var xmlSerializer = new XmlSerializer(typeof(List<Meal>));

			using (Stream stream = File.OpenRead(@"Lists\DefaultMealList.xml"))
			{
				return xmlSerializer.Deserialize(stream) as List<Meal>;
			}
		}

		public static void AddMealToDailyMeals(Meal meal)
		{
			var xmlSerializer = new XmlSerializer(typeof(Meal));
			using (Stream readStream = File.OpenRead(@"Lists\MealList.xml"))
			{
				var existingList = xmlSerializer.Deserialize(readStream) as List<Meal>;
				existingList.Add(meal);
				using (Stream writeStream = File.OpenWrite(@"Lists\MealList.xml"))
				{
					xmlSerializer.Serialize(writeStream, existingList);
				}
			}
		}

		public static void RemoveMealFromDailyMeals(Meal meal)
		{
			var xmlSerializer = new XmlSerializer(typeof(Meal));
			using (Stream readStream = File.OpenRead(@"Lists\MealList.xml"))
			{
				var existingList = xmlSerializer.Deserialize(readStream) as List<Meal>;
				existingList.Remove(meal);
				using (Stream writeStream = File.OpenWrite(@"Lists\MealList.xml"))
				{
					xmlSerializer.Serialize(writeStream, existingList);
				}
			}
		}
	}
}
