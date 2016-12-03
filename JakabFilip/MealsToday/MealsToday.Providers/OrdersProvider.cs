using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using MealsToday.Data;
using MealsToday.Data.Classes;
using MealsToday.Data.Enums;

namespace MealsToday.Providers
{
	public class OrdersProvider
	{
		public static void OrderMeal(SubMenuClass subMenu)
		{
			var xmlSerializerMeal = new XmlSerializer(typeof(List<Meal>));
			var orderDate = DateTime.Today;

			List<Meal> listOfMeals;
			using (Stream stream = File.OpenRead(@"Lists\MealList.xml"))
			{
				listOfMeals = xmlSerializerMeal.Deserialize(stream) as List<Meal>;
			}
			if (listOfMeals == null)
			{
				UIProvider.DisplayAlert("Meal Order has failed\n" +
				                        "List of meals is empty");
				return;
			}
			var mealFound = listOfMeals.FirstOrDefault(x => x.Id == subMenu.MealId);

			if (mealFound == null)
			{
				UIProvider.DisplayAlert("Meal Order has failed.\n" +
				                        "Meal with this ID wasnt found");
				return;
			}
			var mealToOrder = new MealOrder
			{
				UserName = subMenu.UserNameForOrder,
				Id = subMenu.MealId,
				Date = orderDate,
				Name = mealFound.Name
			};

			var xmlSerializerOrder = new XmlSerializer(typeof(List<MealOrder>));
			var listOfMealOrders = new List<MealOrder>();

			switch (subMenu.TypeOfOrder)
			{
				case OrderType.Today:
					{
						try
						{
							using (Stream stream = File.OpenRead(@"Lists\OrdersList.xml"))
							{
								listOfMealOrders = xmlSerializerOrder.Deserialize(stream) as List<MealOrder>;
							}
						}
						catch (FileNotFoundException) { }
						if (listOfMealOrders == null)
							listOfMealOrders = new List<MealOrder>();
						listOfMealOrders.Add(mealToOrder);
						using (Stream stream = File.OpenWrite(@"Lists\OrdersList.xml"))
						{
							xmlSerializerOrder.Serialize(stream, listOfMealOrders);
						}
					}
					break;
				case OrderType.Tomorrow:
					{
						using (Stream stream = File.OpenRead(@"Lists\TomorrowOrdersList.xml"))
						{
							listOfMealOrders = xmlSerializerOrder.Deserialize(stream) as List<MealOrder>;
						}
						if (listOfMealOrders == null)
						{
							UIProvider.DisplayAlert("Meal Order has failed.");
							return;
						}
						listOfMealOrders.Add(mealToOrder);
						using (Stream stream = File.OpenWrite(@"Lists\TomorrowOrdersList"))
						{
							xmlSerializerOrder.Serialize(stream, listOfMealOrders);
						}
					}
					break;
			}
		}

		public static List<MealOrder> GetOrdersByDate(DateTime date)
		{
			var xmlSerializer = new XmlSerializer(typeof(List<MealOrder>));
			List<MealOrder> list;
			using (Stream stream = File.OpenRead(@"Lists\OrdersList.xml"))
			{
				list = xmlSerializer.Deserialize(stream) as List<MealOrder>;
			}
			return (list != null)? list.Where(x => x.Date.Month == date.Month && x.Date.Day == date.Day).OrderBy(x => x.Date).ToList() : new List<MealOrder>();
		}

		public static List<MealOrder> GetAllOrders(OrderType type)
		{
			var xmlSerializer = new XmlSerializer(typeof(List<MealOrder>));
			switch (type)
			{
				case OrderType.Today:
					using (Stream stream = File.OpenRead(@"Lists\OrdersList.xml"))
					{
						return xmlSerializer.Deserialize(stream) as List<MealOrder>;
					}
				case OrderType.Tomorrow:
					using (Stream stream = File.OpenRead(@"Lists\TomorrowOrdersList.xml"))
					{
						return xmlSerializer.Deserialize(stream) as List<MealOrder>;
					}
			}
			return new List<MealOrder>();
		}

		public static List<MealOrder> GetOrdersByUserName(string userName)
		{
			List<MealOrder> ordersList;
			var xmlSerializer = new XmlSerializer(typeof(List<MealOrder>));
			using (Stream stream = File.OpenRead(@"Lists\OrdersList.xml"))
			{
				ordersList = xmlSerializer.Deserialize(stream) as List<MealOrder>;
			}

			var sortedList = ordersList?.Where(x => x.UserName == userName).ToList() ?? new List<MealOrder>();

			return sortedList;
		}
	}
}
