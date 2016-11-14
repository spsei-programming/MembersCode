using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MealsToday.Data;
using MealsToday.Data.Classes;
using MealsToday.Data.Enums;
using MealsToday.Providers;

namespace MealsToday
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var uiProvider = new UIProvider();
			var mealsProvider = new MealsProvider();

			var listOfOrdersToday = new List<MealOrder>();
			var listOfOrdersTomorrow = new List<MealOrder>();

			Actions mainInput = Actions.NullAction;

			do
			{
				try
				{
					uiProvider.DisplayMainMenu();

					do
					{
						mainInput = uiProvider.ReadMainInput();
					} while (mainInput == Actions.NullAction);

					if (mainInput == Actions.Exit)
						break;

					uiProvider.DisplayAction(mainInput, listOfOrdersToday, listOfOrdersTomorrow);

					SubMenuClass subMenuInput;
					do
					{
						subMenuInput = uiProvider.ReadSubMenuInput(mainInput);
					} while (subMenuInput.Action == SubMenuActions.NullAction);

					switch (mainInput)
					{
						case Actions.ShowMeals:
							switch (subMenuInput.Action)
							{
								case SubMenuActions.ShowDetailedMeal:
									uiProvider.ShowDetailedMeal(mealsProvider.GetDefaultMeals(), subMenuInput.MealId);
									break;
								case SubMenuActions.OrderMeal:
									break;
								case SubMenuActions.Exit:
									mainInput = Actions.Exit;
									break;
								case SubMenuActions.BackToMainMenu:
									break;
							}
							break;
						case Actions.Exit:
							break;
						default:
							Console.WriteLine("Error in entering main input.\n" +
																"Press any key to continue");
							Console.ReadKey(false);
							break;
					}
				}
				catch (NotImplementedException)
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("This part isnt done yet\n" +
					                  "Press any key to continue");
					Console.ReadKey(true);
					Console.ResetColor();
				}
			} while (mainInput != Actions.Exit);

			Console.WriteLine("Program is about to be terminated\n" +
												"Press any key to Continue");

			Console.ReadKey(true);
		}
	}
}
