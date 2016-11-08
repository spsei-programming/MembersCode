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
		public void DisplayMainMenu()
		{
			Console.ForegroundColor = ConsoleColor.Cyan;
			
			Console.WriteLine("1. Show Meals");
			Console.WriteLine("2. Place Order For Today");
			Console.WriteLine("3. Place Order For Tomorrow");
			Console.WriteLine("4. Show All Orders");
			Console.WriteLine("5. Show Statistics");
			
			Console.ResetColor();
		}
		
		public void DisplaySubMenu(Actions action)
		{
			/*
			switch (action)
			{
				case ShowMeals:
					{
						var mealsProvider = new MealsProvider();
						var listOfMeals = mealsProvider.GetDefaultMeals();
						ShowMeals(listOfMeals);
					}
					break;
				case PlaceOrderForToday:
					{
						var orderProvider = new OrdersProvider();
						var uiProvider = new UIProvider();
						
						var uiProvider.ReadSubMenuInput();
					}
					break;
			}
			*/
		}
				
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
		// validation of input
		NextTry:
			Console.Clear();
			Console.Write("submenu Action: ");

			var tmpInput = Console.ReadLine().ToLower();
			var commandInput = tmpInput.Split(' ');

			if ((commandInput.Length > 2 || commandInput.Length < 2) && commandInput[0] != "0" && commandInput[0] != "exit")
			{
				Console.WriteLine("Syntax isnt valid.");
				Console.WriteLine("Syntax: [command] [argument]");
				Console.WriteLine("Try again...");
				Console.ReadKey(false);
				goto NextTry;
			}

			var mealProvider = new MealsProvider();
			var orderProvider = new OrdersProvider();
			var mealList = mealProvider.GetDefaultMeals();

			switch (commandInput[0])
			{
				case "0":
					return SubMenuActions.BackToMainMenu;
				case "exit":
					return SubMenuActions.Exit;
			}

			switch (action)
			{
				case Actions.ShowMeals:
					{
						switch (commandInput[0])
						{
							case "detail":
								{
									var meal = mealList.FirstOrDefault(x => x.Id.ToString() == commandInput[1]);
									ShowDetailedMeal(meal);
									return SubMenuActions.JobsDone;
								}
								break;

							case "order":
								{
									var mealOrder = mealList.FirstOrDefault(x => x.Id.ToString() == commandInput[1]);

									if (mealOrder == null)
									{
										Console.WriteLine("meal id isnt valid.");
										goto NextTry;
									}

									Console.Write("Enter your name: ");
									var name = Console.ReadLine();
									orderProvider.OrderMeal(name, mealOrder);
									return SubMenuActions.JobsDone;
								}
								break;

							default:
								Console.WriteLine("Unknown command");
								Console.ReadKey(false);
								break;
						}
					}
					break;
				case Actions.PlaceOrderForToday:
					{
						// throw new NotImplementedException("place order for today's sub menu isnt done yet.");
						var mealOrder = mealList.FirstOrDefault(x => x.Id.ToString() == commandInput[1]);

						if (mealOrder == null)
						{
							Console.WriteLine("meal id isnt valid.");
							goto NextTry;
						}

						Console.Write("Enter your name: ");
						var name = Console.ReadLine();
						orderProvider.OrderMeal(name, mealOrder);
						return SubMenuActions.JobsDone;
					}
					break;

				case Actions.PlaceOrderForTomorrow:
					{
						//throw new NotImplementedException("place order for tommorow's sub menu isnt done yet.");
						var mealOrder = mealList.FirstOrDefault(x => x.Id.ToString() == commandInput[1]);

						if (mealOrder == null)
						{
							Console.WriteLine("meal id isnt valid.");
							goto NextTry;
						}

						Console.Write("Enter your name: ");
						var name = Console.ReadLine();
						orderProvider.OrderMeal(name, mealOrder);
						return SubMenuActions.JobsDone;
					}
					break;

				case Actions.ShowAllOrders:
					//throw new NotImplementedException("show all orders's sub menu isnt done yet");
					{

					}
					break;

jsut 				case Actions.ShowStatistics:
					throw new NotImplementedException("show statistics's sub menu isnt done yet.");
					break;
			}

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
