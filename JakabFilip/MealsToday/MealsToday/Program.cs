using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MealsToday.Data;
using MealsToday.Data.Classes;
using MealsToday.Data.Enums;
using MealsToday.Helpers;
using MealsToday.Providers;

namespace MealsToday
{
	public class Program
	{
		public static void Main(string[] args)
		{
			//					--- File Names ---
			// Lists\MealList.xml - custom list of Meals
			// Lists\DefaultMealList.xml - list of Default Meals
			// Lists\OrdersList.xml - list of orders
			//Lists\TomorrowOrdersList - list of orders for tomorrow

			if (!Directory.Exists(@"Lists")) Directory.CreateDirectory(@"Lists");

			FileHelper.FillDefaultMealFile();
			FileHelper.FillMealList();

			do
			{
				Actions mainInput;

				Console.Clear();
				UIProvider.DisplayMainMenu();

				do
				{
					mainInput = UIProvider.ReadMainInput();
				} while (mainInput == Actions.NullAction);

				if (mainInput == Actions.Exit) break;

				UIProvider.DisplayAction(mainInput);

				var subMenuInput = UIProvider.ReadSubMenuInput(mainInput);

				if (subMenuInput.Action == SubMenuActions.Exit) break;

				UIProvider.DisplaySubeMenuAction(subMenuInput);
			} while (true);

			Console.WriteLine("See ya next time\n" +
			                  "Press any key to continue");

			Console.ReadKey(true);
		}
	}
}
