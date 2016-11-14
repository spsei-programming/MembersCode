using System;
using System.Collections.Generic;
using MealsToday.Data;

namespace MealsToday.Providers
{
	public class OrdersProvider
	{
		public List<Order> Orders { get; set; }

		public OrdersProvider()
		{
			Orders = new List<Order>();
			//Orders.Add(new Order("Albert", 2, DateTime.Today));
			//Orders.Add(new Order("Albert", 1, DateTime.Today.AddDays(1)));
		}

		public void PlaceOrder(string name, Meal meal, DateTime date)
		{
			Order order = new Order(name, meal, date);
			Orders.Add(order);
		}

		public List<Order> GetOrdersByDate(DateTime date)
		{
			List<Order> result = new List<Order>();

			foreach (Order order in Orders)
			{
				if (date.Subtract(order.Date).Days == 0)
					result.Add(order);
			}

			return result;
		}

		public List<Order> GetOrdersForToday()
		{
			return GetOrdersByDate(DateTime.Today);
		}

		public List<Order> GetOrdersForTomorrow()
		{
			return GetOrdersByDate(DateTime.Today.AddDays(1));
		}
	}
}
