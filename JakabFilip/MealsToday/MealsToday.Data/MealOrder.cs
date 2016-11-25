using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealsToday.Data
{
	[Serializable]
	public class MealOrder : Meal
	{
		private static int _idOrder;

		public string UserName { get; set; }
		public DateTime Date { get; set; }

		public void CreateOrder()
		{
			Id = ++_idOrder;
		}
	}
}
