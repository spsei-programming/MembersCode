using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealsToday.Data
{
	public class Meal
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public int Calories { get; set; }

		public List<byte> Alergends { get; private set; }

		public Meal()
		{
			Alergends = new List<byte>(5);
		}
	}
}
