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
	}
}