using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MealsToday.Data;

namespace MealsToday.Providers
{
	public class OrdersProvider
	{
		/// <summary>
		/// Sets a new Meal Order
		/// </summary>
		/// <param name="username">custommers name</param>
		/// <param name="meal">Ordered Meal</param>
		/// <returns>returns a MealOrder Object</returns>
		public MealOrder OrderMeal(string username, Meal meal)
		{
			var orderDate = new DateTime();
			var mealToOrder = new MealOrder()
			{
				UserName = username,
				Id = meal.Id,
				Date = orderDate
			};

			return mealToOrder;
		}
	}
}
