using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealsToday.Data
{
	public class MealOrder : Meal
	{
		public string UserName { get; set; }
		public DateTime Date { get; set; }
	}
}
