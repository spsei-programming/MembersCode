using System;
using System.Collections.Generic;
using MealsToday.Data;

namespace MealsToday.Providers
{
	public class MealsProvider
	{
		public List<Meal> Meals;

		public MealsProvider()
		{
			Meals = new List<Meal> {new Meal(1, "Cerealie", 1500, "Lepek")};
		}

		public Meal GetMeal(int mealNumber)
		{
			foreach (Meal meal in Meals)
			{
				if (meal.Number == mealNumber)
				{
					return meal;
				}
			}

			throw new Exception("Meal not found");
		}
	}
}