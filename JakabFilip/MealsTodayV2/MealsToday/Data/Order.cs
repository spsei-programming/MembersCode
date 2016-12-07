using System;

namespace MealsToday.Data
{
	public class Order
	{
		public int OrderId { get; set; }
		public DateTime OrderDate { get; set; }
		public User User { get; set; }
	}
}