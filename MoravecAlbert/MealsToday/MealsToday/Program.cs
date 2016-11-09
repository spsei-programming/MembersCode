using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MealsToday.Data;
using MealsToday.Providers;
using MealsToday.Providers.Enums;

namespace MealsToday
{
	class Program
	{

		static void Main(string[] args)
		{
			UIProvider uiProvider = new UIProvider();
			MealsProvider mealsProvider = new MealsProvider();
			OrdersProvider ordersProvider = new OrdersProvider();

			UIProvider.ShowMainMenu();
			switch (UIProvider.GetMainMenuAction())
			{
				case Actions.ShowMeals:
					uiProvider.ShowMeals(mealsProvider);
					break;
				case Actions.ShowMealDetails:
					break;
				case Actions.OrderToday:
					List<Order> todayList = ordersProvider.GetOrdersForToday();
					break;
				case Actions.OrderTomorrow:
					break;
				case Actions.ShowAllOrders:
					break;
				case Actions.ShowStatistics:
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}
