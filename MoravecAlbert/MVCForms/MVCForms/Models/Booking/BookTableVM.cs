using System;

namespace MVCForms.Models.Booking
{
	public class BookTableVM
	{
		public string Name { get; set; }

		public DateTime Date { get; set; }

		public byte AmmountOfPeople { get; set; }
	}
}