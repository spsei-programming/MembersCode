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
			var classToReturn = new SubMenuClass();

			switch (action)
			{
				case Actions.ShowMeals:
					{
						Console.Write("Enter Action: ");
						var readLine = Console.ReadLine();
						if (readLine != null)
						{
							var args = readLine.ToLower().Split(' ');

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
										classToReturn.MealId = tmpValue;
										classToReturn.Action = SubMenuActions.ShowDetailedMeal;
									}
								}
									break;
								case "order":
								{
									int tmpValue;
									if (!int.TryParse(args[1], out tmpValue))
									{
										DisplayAlert("Meal id isnt valid");
										DisplaySyntaxHelp(action);
									}
									classToReturn.Action = SubMenuActions.OrderMealToday;
									classToReturn.UserNameForOrder = args[2];
									classToReturn.MealId = tmpValue;
								}
									break;
								case "help":
								{
									DisplaySyntaxHelp(action);
								}
									break;
								case "exit":
								{
									classToReturn.Action = SubMenuActions.Exit;
								}
									break;
								case "0":
								{
									classToReturn.Action = SubMenuActions.NullAction;
								}
									break;
								default:
									DisplaySyntaxHelp(action);
									break;
							}
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
									classToReturn.Action = SubMenuActions.NullAction;
								}
								break;
							case "exit":
								{
									classToReturn.Action = SubMenuActions.Exit;
									return classToReturn;
								}
							case "0":
								{
									classToReturn.Action = SubMenuActions.NullAction;
									return classToReturn;
								}
							default:
								DisplaySyntaxHelp(action);
								break;
						}

						int mealId;
						if (int.TryParse(args[1], out mealId))
						{
							DisplayAlert("Entered argument(meal id) isnt number");
							DisplaySyntaxHelp(action);
						}

						classToReturn.UserNameForOrder = args[0];
						classToReturn.MealId = mealId;
						classToReturn.TypeOfOrder = OrderType.Today;
					}
					break;
				case Actions.PlaceOrderForTomorrow:
					{
						Console.Write("Enter args: ");
						var args = Console.ReadLine().ToLower().Split(' ');

						switch (args[0])
						{
							case "help":
								{
									DisplaySyntaxHelp(action);
									classToReturn.Action = SubMenuActions.NullAction;
								}
								break;
							case "exit":
								{
									classToReturn.Action = SubMenuActions.Exit;
									return classToReturn;
								}
							case "0":
								{
									classToReturn.Action = SubMenuActions.NullAction;
								}
								break;
							default:
								DisplaySyntaxHelp(action);
								break;
						}

						int mealId;
						if (!int.TryParse(args[1], out mealId))
						{
							DisplayAlert("Entered argument(meal id) isnt number");
							DisplaySyntaxHelp(action);
						}

						classToReturn.UserNameForOrder = args[0];
						classToReturn.MealId = mealId;
						classToReturn.TypeOfOrder = OrderType.Tomorrow;
					}
					break;
				case Actions.ShowAllOrders:
					{
						Console.Write("Enter Action: ");
						var args = Console.ReadLine().ToLower().Split(' ');
						switch (args[0])
						{
							case "0":
								break;
							case "bydate":
								{
									classToReturn.Action = SubMenuActions.ShowAllOrdersByDate;
									int tmpValueDay, tmpValueMonth;
									if (!int.TryParse(args[1], out tmpValueDay) && !int.TryParse(args[2], out tmpValueMonth))
									{
										DisplayAlert("2rd and 3rd argument must be number (day, month)");
										classToReturn.Action = SubMenuActions.NullAction;
										return classToReturn;
									}
									if (!int.TryParse(args[2], out tmpValueMonth))
										classToReturn.Date = new DateTime(DateTime.Today.Year, tmpValueMonth, tmpValueDay);
								}
								break;
							case "byname":
								classToReturn.Action = SubMenuActions.ShowAllOrdersByUserName;
								classToReturn.UserNameForOrder = args[1];
								break;
							case "exit":
								classToReturn.Action = SubMenuActions.Exit;
								break;
							case "help":
								DisplaySyntaxHelp(action);
								break;
							default:
								DisplaySyntaxHelp(action);
								break;
						}
					}
					break;
				case Actions.ShowStatistics:
					throw new NotImplementedException();
			}
			return classToReturn;
		}

		public static void DisplaySyntaxHelp(Actions action)
		{
			switch (action)
			{
				case Actions.ShowMeals:
					Console.WriteLine("Valid Syntax: [Command] [Argument]\n" +
														"Commands: 'detail', 'order', 'help'\n" +
														"Argument: The Meal's ID\n" +
														"Note: in case of ordering, there is another(3rd) [Argument] meaning username");
					break;
				case Actions.PlaceOrderForToday:
					Console.WriteLine("Valid Syntax: [username] [argument]\n" +
														"Argument: Meal's ID\n" +
					                  "Note: username cannot be '0' or 'exit'\n" +
					                  "'0' to back to main menu\n" +
					                  "'exit' to exit the program");
					break;
				case Actions.PlaceOrderForTomorrow:
					Console.WriteLine("Valid Syntax: [username] [argument]\n" +
														"Argument: Meal's ID\n" +
														"Note: username cannot be '0' or 'exit'\n" +
														"'0' to back to main menu\n" +
														"'exit' to exit the program");
					break;
				case Actions.ShowAllOrders:
					Console.WriteLine("Valid Syntax: [command]\n" +
														"Commands: 'byDate', byName'', '0', 'exit'\n" +
														"Note: In case of byDate or byName u must enter argument\n" +
														"Argument: \n" +
														" for byDate: 'month' 'day'\n" +
														" for byName: name");
					break;
				case Actions.ShowStatistics:
					Console.WriteLine("Valid Syntax: [command]\n" +
														"Commands: '0', 'exit'");
					break;
			}
			Console.ReadKey(true);
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
				case Actions.ShowAllOrders:
					ShowAllOrders(OrderType.Today);
					break;
				case Actions.ShowStatistics:
					break;
			}
		}

		public static void ExecuteSubMenuAction(SubMenuClass subMenu)
		{
			switch (subMenu.Action)
			{
				case SubMenuActions.ShowDetailedMeal:
					ShowDetailedMeal(subMenu.MealId);
					break;
				case SubMenuActions.OrderMealToday:
					OrdersProvider.OrderMeal(subMenu);
					break;
				case SubMenuActions.OrderMealTomorrow:
					OrdersProvider.OrderMeal(subMenu);
					break;
				case SubMenuActions.ShowAllOrders:
					ShowAllOrders(subMenu.TypeOfOrder);
					break;
				case SubMenuActions.ShowAllOrdersByDate:
					ShowOrdersByDate(subMenu);
					break;
				case SubMenuActions.ShowAllOrdersByUserName:
					ShowOrdersByUsername(subMenu);
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
				DisplayAlert("Error has Occured. meal ID is not valid");
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
				DisplayAlert(e.Message);
			}

			if (meal == null)
			{
				DisplayAlert("Meal not found.");
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

		public static void ShowOrdersByUsername(SubMenuClass subMenu)
		{
			Console.WriteLine("All orders of user: {0}", subMenu.UserNameForOrder);
			foreach (var mealOrder in OrdersProvider.GetOrdersByUserName(subMenu.UserNameForOrder))
			{
				Console.WriteLine($"ID: {mealOrder.Id}\tMeal Name: {mealOrder.Name}");

				Console.WriteLine("Press any key to continue");
				Console.ReadKey(true);
			}
		}

		public static void ShowOrdersByDate(SubMenuClass subMenu)
		{
			var ordersList = OrdersProvider.GetOrdersByDate(subMenu.Date);
			Console.WriteLine($"Orders found by date: {subMenu.Date.Day}.{subMenu.Date.Month}.{subMenu.Date.Year}");
			foreach (var mealOrder in ordersList)
			{
				Console.WriteLine($"Meal ID: {mealOrder.Id}\tMeal: {mealOrder.Name}\tUserName: {mealOrder.UserName}");
			}

			Console.WriteLine("Press any key to continue");
			Console.ReadKey(true);
		}

		public static void ShowAllOrders(OrderType type)
		{
			switch (type)
			{
				case OrderType.Today:
					{
						var orderedMeals = OrdersProvider.GetAllOrders(OrderType.Today);

						if (orderedMeals == null)
						{
							DisplayAlert("There are no ordered Meals for Today");
							Console.ReadKey(true);
							return;
						}
						Console.ForegroundColor = ConsoleColor.Blue;

						Console.WriteLine("Already ordered meals:");
						var sortedListToday = orderedMeals.OrderBy(x => x.Date);
						foreach (var order in sortedListToday)
						{
							Console.WriteLine($"username: {order.UserName}\tmeal ID: {order.Id}\tdate: {order.Date.Day}.{order.Date.Month}.{order.Date.Year}");
						}
					}
					break;
				case OrderType.Tomorrow:
					{
						var orderedMealsTomorrow = OrdersProvider.GetAllOrders(OrderType.Tomorrow);

						if (orderedMealsTomorrow == null)
						{
							DisplayAlert("There are no ordered Meals for Tomorrow");
							return;
						}

						Console.ForegroundColor = ConsoleColor.White;

						Console.WriteLine("Meals ordered for tomorrow:");
						var sortedListTomorrow = orderedMealsTomorrow.OrderBy(x => x.Date);
						foreach (var meal in sortedListTomorrow)
						{
							Console.WriteLine($"Username: {meal.UserName}\tmeal ID: {meal.Id}");
						}
					}
					break;
			}

			Console.ResetColor();
		}

		public static void DisplayAlert(string msg)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(msg + "\nPress any key to continue");
			Console.ReadKey(true);
			Console.ResetColor();
		}
	}
}
