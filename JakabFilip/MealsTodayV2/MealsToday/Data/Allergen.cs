namespace MealsToday.Data
{
	public class Allergen
	{
		public int AllergenId { get; set; }
		public string Name { get; set; }

		public Allergen(int allergenId, string name)
		{
			AllergenId = allergenId;
			Name = name;
		}
	}
}