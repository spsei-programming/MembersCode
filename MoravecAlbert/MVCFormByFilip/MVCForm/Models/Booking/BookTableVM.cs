using System;

namespace MVCForm.Models.Booking
{
	public class BookTableVM
	{
		public string Name { get; set; }
		public DateTime Date { get; set; }
		public byte AmountOfPeople { get; set; }
	}
}