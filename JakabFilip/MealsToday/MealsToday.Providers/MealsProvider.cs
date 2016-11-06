using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MealsToday.Data;

namespace MealsToday.Providers
{
	public class MealsProvider
	{
		public List<Meal> GetDefaultMeals()
		{
			var mealList = new List<Meal>
			{
				new Meal
				{
					Id = 0,
					Name = "Knedlo vepro zelo",
					Calories = 6523,
					Alergends = {1, 7, 8}
				},
				new Meal
				{
					Id = 1,
					Name = "Kureci vyvar",
					Calories = 3500,
					Alergends = {4, 5, 8}
				},
				new Meal
				{
					Id = 2,
					Name = "Palacinky na sladko",
					Calories = 5125,
					Alergends = {7, 8, 9}
				},
				new Meal
				{
					Id = 3,
					Name = "Kureci rizek s brambory",
					Calories = 4750,
					Alergends = {1, 6, 9}
				}
			};

			return mealList;
		}
	}
}
