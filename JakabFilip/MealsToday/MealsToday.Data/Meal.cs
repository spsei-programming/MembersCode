using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealsToday.Data
{
	[Serializable]
	public class Meal
	{
		private static int _id;
		public int Id { get; set; }
		public string Name { get; set; }
		public int Calories { get; set; }
		public List<byte> Alergends { get; private set; }

		public Meal()
		{
			Alergends = new List<byte>(5);
		}

		public void CreateMeal()
		{
			Id = ++_id;
		}
	}
}
