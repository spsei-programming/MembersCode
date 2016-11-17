using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using MealsToday.Data;
using MealsToday.Data.Enums;
using MealsToday.Data.Classes;

namespace MealsToday.Providers
{
	public static class UIProvider
	{
		public static Actions ReadMainInput()
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
		public static SubMenuClass ReadSubMenuInput(Actions action)
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
							case "exit":
								{
									classToreturn.Action = SubMenuActions.Exit;
								}
								break;
							default:
								DisplaySyntaxHelp(action);
								break;
						}
					}
					break;
				case Actions.PlaceOrderForToday:
					{
						Console.Write("Enter args: ");
						var args = Console.ReadLine().ToLower().Split(' ');

						switch (args[0])
						{
							case "help":
								{
									DisplaySyntaxHelp(action);
									classToreturn.Action = SubMenuActions.NullAction;
								}
								break;
							case "exit":
								{
									classToreturn.Action = SubMenuActions.Exit;
									return classToreturn;
								}
						}

						int mealId;
						if (int.TryParse(args[1], out mealId))
						{
							Console.WriteLine("Entered argument(meal id) isnt number\nIt must be a nubmer");
							DisplaySyntaxHelp(action);
						}

						OrdersProvider.OrderMeal(args[0], mealId);
					}
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
			Console.ReadKey(true);
			return classToreturn;
		}

		public static void DisplaySyntaxHelp(Actions action)
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

		public static void DisplayMainMenu()
		{
			Console.Clear();
			Console.WriteLine("1. Show Meals");
			Console.WriteLine("2. Order Meal For Today");
			Console.WriteLine("3. Order Meal For Tomorrow");
			Console.WriteLine("4. Show All Orders");
			Console.WriteLine("5. Show Statistics");
			Console.WriteLine("exit -> End Program");
		}

		public static void DisplayAction(Actions action)
		{
			switch (action)
			{
				case Actions.ShowMeals:
					ShowMeals(MealsProvider.GetDefaultMeals());
					break;
				case Actions.PlaceOrderForToday:
					break;
				case Actions.PlaceOrderForTomorrow:
					break;
				case Actions.ShowAllOrders:
					ShowAllOrders();
					break;
				case Actions.ShowStatistics:
					break;
			}
		}

		public static void DisplaySubeMenuAction(SubMenuClass subMenu)
		{
			switch (subMenu.Action)
			{
				case SubMenuActions.ShowDetailedMeal:
					ShowDetailedMeal(subMenu.MealId);
					break;
				case SubMenuActions.OrderMeal:
					break;
			}
		}

		public static void ShowMeals(List<Meal> mealsToDisplay)
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Blue;
			foreach (var meal in mealsToDisplay)
			{
				Console.WriteLine($"ID: {meal.Id} \tName: {meal.Name}");
			}
			Console.ResetColor();
		}

		public static void ShowDetailedMeal(int mealId)
		{
			if (mealId < 0)
			{
				Console.WriteLine("Error has Occured. meal ID is not valid.\n" +
													"Press any key to continue");
				Console.ReadKey(true);
				return;
			}

			Meal meal = null;
			try
			{
				var xmlSerializer = new XmlSerializer(typeof(List<Meal>));
				using (Stream stream = File.OpenRead(@"Lists\MealList.xml"))
				{
					var list = xmlSerializer.Deserialize(stream) as List<Meal>;
					meal = list.FirstOrDefault(x => x.Id == mealId);
				}
			}
			catch (DirectoryNotFoundException e)
			{
				Console.WriteLine("Directory not found. \n {0}", e.Message);
			}

			if (meal == null)
			{
				Console.WriteLine("Meal not found.");
				Console.ReadKey(true);
				return;
			}

			Console.Clear();
			Console.WriteLine($"ID: {meal.Id}\n" +
												$"Name: {meal.Name}");
			Console.WriteLine("Alergens:");
			foreach (var alergen in meal.Alergends)
				Console.Write($" {alergen}");

			Console.WriteLine($"\nCalories: {meal.Calories}");

			Console.WriteLine("Press any key to continue");
			Console.ReadKey(true);
		}

		public static void ShowAllOrders()
		{
			var xmlSerializer = new XmlSerializer(typeof(MealOrder));

			List<MealOrder> orderedMeals;
			List<MealOrder> orderedMealsTomorrow;

			using (Stream stream = File.OpenRead(@"Lists\OrdersList.xml"))
			{
				orderedMeals = xmlSerializer.Deserialize(stream) as List<MealOrder>;
			}
			using (Stream stream = File.OpenRead(@"Lists\TomorrowOrdersList.xml"))
			{
				orderedMealsTomorrow = xmlSerializer.Deserialize(stream) as List<MealOrder>;
			}

			if (orderedMeals == null)
			{
				Console.WriteLine("There are no ordered Meals");
				return;
			}

			if (orderedMealsTomorrow == null)
			{
				Console.WriteLine("There are no ordered Meals for Tomorrow");
			}

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
