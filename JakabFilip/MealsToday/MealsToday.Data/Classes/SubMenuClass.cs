using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MealsToday.Data.Enums;

namespace MealsToday.Data.Classes
{
	public class SubMenuClass
	{
		public string UserNameForOrder { get; set; }
		public int MealId { get; set; }
		public SubMenuActions Action { get; set; }

		public SubMenuClass()
		{
			UserNameForOrder = "";
			MealId = -1;
			Action = SubMenuActions.NullAction;
		}
	}
}
