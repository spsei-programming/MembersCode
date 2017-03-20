using System;

namespace MVCForm.Models
{
	public class OrderModel
	{
		/// <summary>
		/// this property is represented by Clients Adress email adress
		/// </summary>
		public string Client { get; set; }

		/// <summary>
		/// Meal's ID
		/// </summary>
		public int MealId { get; set; }

		/// <summary>
		///  Date when user entered his order
		/// </summary>
		public DateTime DateFrom { get; set; }

		/// <summary>
		/// Date when meal should be ordered
		/// </summary>
		public DateTime DateTo { get; set; }
	}
}