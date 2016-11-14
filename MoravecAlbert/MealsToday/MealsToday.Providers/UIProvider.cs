using System;
using MealsToday.Data;
using MealsToday.Providers.Enums;

namespace MealsToday.Providers
{
	public class UIProvider
	{
		public static void ShowMainMenu()
		{
			Console.WriteLine("1) Show meals\n" +
												"2) Place order for today\n" +
												"3) Place order for tomorrow\n" +
												"4) Show all orders\n" +
												"5) Show statistics\n");
		}

		public static Actions GetMainMenuAction()
		{
			string input = Console.ReadLine();
			switch (input)
			{
				case "1":
					return Actions.ShowMeals;

				case "2":
					return Actions.OrderToday;

				case "3":
					return Actions.OrderTomorrow;

				case "4":
					return Actions.ShowAllOrders;

				case "5":
					return Actions.ShowStatistics;
				default:
					ShowMainMenu();
					GetMainMenuAction();
					break;
			}

			throw new ArgumentOutOfRangeException();
		}

		public void ShowMeals(MealsProvider mealsProvider)
		{
			Console.WriteLine("Meals");
			Console.WriteLine("|{0,-10}|{1,-20}|", "Number", "Name");
			Console.WriteLine("|----------|--------------------|");

			foreach (var meal in mealsProvider.Meals)
			{
				Console.WriteLine("|{0,-10}|{1,-20}|", meal.Number, meal.Name);
			}
		}

		public void ShowMealDetails(Meal meal)
		{
			Console.WriteLine("{0, 15}{1, 30}", "Number", meal.Number);
			Console.WriteLine("{0, 15}{1, 30}", "Name", meal.Name);
			Console.WriteLine("{0, 15}{1, 30}", "Calories", meal.Calories);
			Console.WriteLine("{0, 15}{1, 30}", "Number", meal.Alergens);
		}
	}
}