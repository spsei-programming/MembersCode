using System.Collections.Generic;
using MealsToday.Data;

namespace MealsToday.Helpers
{
	public static class Context
	{
		public static User CurrentUser { get; set; }
		public static List<User> AllUsers { get; set; }

		public static List<Meal> Meals { get; set; }
		public static List<Allergen> Allergens { get; set; }

		public static Dictionary<int, Allergen> MapOfAllergens
		{
			get
			{
				Dictionary<int, Allergen> map = new Dictionary<int, Allergen>(Allergens.Count);
				foreach (Allergen allergen in Allergens)
				{
					map.Add(allergen.AllergenId, allergen);
				}
				return map;
			}
		}
	}
}