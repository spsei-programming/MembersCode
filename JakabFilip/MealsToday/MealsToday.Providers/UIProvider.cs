using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MealsToday.Data;
using MealsToday.Data.Enums;

namespace MealsToday.Providers
{
	public class UIProvider
	{
		/// <summary>
		/// Reads the input from main menu layer
		/// </summary>
		/// <returns>returns a value of Actions enum</returns>
		public Actions ReadMainInput()
		{
			Console.Clear();
			Console.Write("Action(number): ");
			var input = Console.ReadLine().ToLower();

			switch (input)
			{
				case "1":
					return Actions.ShowMeals;

				case "2":
					return Actions.PlaceOrderForToday;

				case "3":
					return Actions.PlaceOrderForTomorrow;

				case "4":
					return Actions.ShowAllOrders;

				case "5":
					return Actions.ShowStatistics;

				case "exit":
					return Actions.Exit;

				default:
					return Actions.NullAction;
			}
		}

		/// <summary>
		/// Reads the submenu input; also handles commands and arguments
		/// </summary>
		/// <param name="action">Actual submenu layer</param>
		public SubMenuActions ReadSubMenuInput(Actions action)
		{
			return SubMenuActions.NullAction;
		}

		public void ShowMeals(List<Meal> mealsToDisplay)
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Blue;
			foreach (var meal in mealsToDisplay)
			{
				Console.WriteLine($"ID: {meal.Id} \t\tName: {meal.Name}");
			}

			Console.ReadKey(false);
		}

		public void ShowDetailedMeal(Meal meal)
		{
			if (meal == null) return;

			Console.Clear();
			Console.WriteLine($"ID: {meal.Id} Name: {meal.Name}");
			Console.WriteLine("Alergens:");
			foreach (var alergen in meal.Alergends)
				Console.Write($" {alergen}");

			Console.WriteLine($"Calories: {meal.Calories}");

			Console.ReadKey(false);
		}

		public void ShowAllOrders(List<MealOrder> orderedMeals, List<MealOrder> orderedMealsTomorrow)
		{
			Console.ForegroundColor = ConsoleColor.Blue;

			Console.WriteLine("Already ordered meals:");
			var sortedListToday = orderedMeals.OrderBy(x => x.Date);
			foreach (var meal in sortedListToday)
			{
				Console.WriteLine($"username: {meal.Name}\tmeal ID: {meal.Id}");
			}

			Console.ForegroundColor = ConsoleColor.White;

			Console.WriteLine("Meals ordered for tomorrow:");
			var sortedListTomorrow = orderedMealsTomorrow.OrderBy(x => x.Date);
			foreach (var meal in orderedMealsTomorrow)
			{
				Console.WriteLine($"Username: {meal.UserName}\tmeal ID: {meal.Id}");
			}
			Console.ResetColor();
		}
	}
}
