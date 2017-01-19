using System.Collections.Generic;

namespace MealsToday.Data
{
	public class Meal
	{
		public int MealId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

		public short Calories { get; set; }

		public List<Allergen> Allergens { get; set; } = new List<Allergen>();
	}
}