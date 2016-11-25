using System;

namespace MealsToday.Data
{
	public class Order
	{
		public string CustomerName { get; set; }
		public Meal Meal { get; set; }
		public DateTime Date { get; set; }

		public Order(string name, Meal meal, DateTime date)
		{
			CustomerName = name;
			Meal = meal;
			Date = date;
		}
	}
}
