using System.Collections.Generic;
using MVCForm.Models.Enums;

namespace MVCForm.Models
{
	public class MealModel
	{
		public string Name { get; set; }

		public int Id { get; set; }

		public int Calories { get; set; }

		public List<Allergens> Allergens { get; set; } = new List<Allergens>();

		public MealType Type { get; set; }
	}
}