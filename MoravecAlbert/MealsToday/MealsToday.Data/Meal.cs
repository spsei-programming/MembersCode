using System.Collections.Generic;

namespace MealsToday.Data
{
	public class Meal
	{
		public int Number { get; set; }
		public string Name { get; set; }
		public int Calories { get; set; }
		public string Alergens { get; set; }

		public Meal(int number, string name, int calories, string alergens)
		{
			Number = number;
			Name = name;
			Calories = calories;
			Alergens = alergens;
		}
	}
}