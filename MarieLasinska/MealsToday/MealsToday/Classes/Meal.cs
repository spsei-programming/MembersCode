using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealsToday.Classes
{
	class Meal
	{
		public int MealId { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public int Calories { get; set; }

		public List<Allergen> Allergens = new List<Allergen>(5);
	}
}
