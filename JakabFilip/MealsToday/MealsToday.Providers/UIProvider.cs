using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MealsToday.Data;
using MealsToday.Data.Enums;
using MealsToday.Data.Classes;

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
		public SubMenuClass ReadSubMenuInput(Actions action)
		{
			var classToreturn = new SubMenuClass();

			switch (action)
			{
				case Actions.ShowMeals:
					{
						Console.Write("Enter Action: ");
						var args = Console.ReadLine().ToLower().Split(' ');

						switch (args[0])
						{
							case "detail":
								{
									int tmpValue;
									if (!int.TryParse(args[1], out tmpValue))
									{
										DisplaySyntaxHelp(action);
									}
									else
									{
										classToreturn.MealId = tmpValue;
										classToreturn.Action = SubMenuActions.ShowDetailedMeal;
									}
								}
								break;
							case "order":
								throw new NotImplementedException();
								break;
							case "help":
								{
									DisplaySyntaxHelp(action);
								}
								break;
							default:
								DisplaySyntaxHelp(action);
								break;
						}
					}
					break;
				case Actions.PlaceOrderForToday:
					throw new NotImplementedException();
					break;
				case Actions.PlaceOrderForTomorrow:
					throw new NotImplementedException();
					break;
				case Actions.ShowAllOrders:
					throw new NotImplementedException();
					break;
				case Actions.ShowStatistics:
					throw new NotImplementedException();
					break;
			}

			return classToreturn;
		}

		public void DisplaySyntaxHelp(Actions action)
		{
			switch (action)
			{
				case Actions.ShowMeals:
					Console.WriteLine("Valid Syntax: [command] [argument]\n" +
														"Commands: 'detail', 'order', 'help'\n" +
														"Argument: The Meal's ID");
					break;
				case Actions.PlaceOrderForToday:
					Console.WriteLine("Valid Syntax: [username] [argument]\n" +
														"Argument: Meal's ID");
					break;
				case Actions.PlaceOrderForTomorrow:
					Console.WriteLine("Valid Syntax: [username] [argument]\n" +
														"Argument: Meal's ID");
					break;
				case Actions.ShowAllOrders:
					Console.WriteLine("Valid Syntax: [command]\n" +
														"Commands: '0', 'exit'");
					break;
				case Actions.ShowStatistics:
					Console.WriteLine("Valid Syntax: [command]\n" +
														"Commands: '0', 'exit'");
					break;
			}
		}

		public void DisplayMainMenu()
		{
			Console.Clear();
			Console.WriteLine("1. Show Meals");
			Console.WriteLine("2. Order Meal For Today");
			Console.WriteLine("3. Order Meal For Tomorrow");
			Console.WriteLine("4. Show All Orders");
			Console.WriteLine("5. Show Statistics");
			Console.WriteLine("exit -> End Program");
		}

		public void DisplayAction(Actions action, List<MealOrder> ordersToday, List<MealOrder> ordersTomorrow)
		{
			var mealProvider = new MealsProvider();
			//var orderProvider = new OrdersProvider();

			switch (action)
			{
				case Actions.ShowMeals:
					ShowMeals(mealProvider.GetDefaultMeals());
					break;
				case Actions.PlaceOrderForToday:
					break;
				case Actions.PlaceOrderForTomorrow:
					break;
				case Actions.ShowAllOrders:
					ShowAllOrders(ordersToday, ordersTomorrow);
					break;
				case Actions.ShowStatistics:
					break;
			}
		}

		public void ShowMeals(List<Meal> mealsToDisplay)
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Blue;
			foreach (var meal in mealsToDisplay)
			{
				Console.WriteLine($"ID: {meal.Id} \tName: {meal.Name}");
			}
			Console.ResetColor();
		}

		public void ShowDetailedMeal(List<Meal> listOfMeals, int mealId)
		{
			if (mealId < 0)
			{
				Console.WriteLine("Error has Occured. meal ID is not valid.\n" +
													"Press any key to continue");
				Console.ReadKey(true);
				return;
			}

			var meal = listOfMeals.FirstOrDefault(x => x.Id == mealId);
			if (meal == null)
			{
				Console.WriteLine("no meal found with this ID({0})\n" +
													"Press any key to continue", mealId);
				Console.ReadKey(true);
				return;
			}

			Console.Clear();
			Console.WriteLine($"ID: {meal.Id} Name: {meal.Name}");
			Console.WriteLine("Alergens:");
			foreach (var alergen in meal.Alergends)
				Console.Write($" {alergen}");

			Console.WriteLine($"\nCalories: {meal.Calories}");

			Console.WriteLine("Press any key to continue");
			Console.ReadKey(true);
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
			foreach (var meal in sortedListTomorrow)
			{
				Console.WriteLine($"Username: {meal.UserName}\tmeal ID: {meal.Id}");
			}
			Console.ResetColor();
		}
	}
}
