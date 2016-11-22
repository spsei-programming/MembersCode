using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using MealsToday.Data;

namespace MealsToday.Providers
{
	public class OrdersProvider
	{
		public static void OrderMeal(string userName, int mealId)
		{
			var orderDate = new DateTime();
			var mealToOrder = new MealOrder
			{
				UserName = userName,
				Id = mealId,
				Date = orderDate
			};

			var xmlSerializer = new XmlSerializer(typeof(List<MealOrder>));
			List<MealOrder> listOfMealOrders;

			using (Stream stream = File.OpenRead(@"Lists\OrdersList.xml"))
			{
				listOfMealOrders = xmlSerializer.Deserialize(stream) as List<MealOrder>;
			}
			listOfMealOrders.Add(mealToOrder);
			using (Stream stream = File.OpenWrite(@"Lists\OrdersList"))
			{
				xmlSerializer.Serialize(stream, listOfMealOrders);
			}
		}

		public static List<MealOrder> GetOrdersByDate(DateTime date)
		{
			var xmlSerializer = new XmlSerializer(typeof(List<MealOrder>));
			var list = new List<MealOrder>();
			using (Stream stream = File.OpenRead(@"Lists\OrdersList.xml"))
			{
				list = xmlSerializer.Deserialize(stream) as List<MealOrder>;
			}
			return list.Where(x => x.Date.Month == date.Month && x.Date.Day == date.Day).OrderBy(x => x.Date).ToList();
		}

		public static List<MealOrder> GetOrdersByUserName(string userName)
		{
			List<MealOrder> ordersList;
			var xmlSerializer = new XmlSerializer(typeof(List<MealOrder>));
			using (Stream stream = File.OpenRead(@"Lists\OrdersList.xml"))
			{
				ordersList = xmlSerializer.Deserialize(stream) as List<MealOrder>;
			}

			var sortedList = ordersList.Where(x => x.UserName == userName).ToList();

			return sortedList;
		}
	}
}
