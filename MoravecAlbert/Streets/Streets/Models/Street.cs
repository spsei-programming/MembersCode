using System;
using System.Collections.Generic;

namespace Streets.Models
{
	[Serializable]
	public class Street
	{
		private static int lastId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public List<StreetDescription> Descriptions { get; private set; } = new List<StreetDescription>(5);
		public int Id { get; private set; }

		private Street()
		{
			Id = ++lastId;
		}

		public static Street CreateStreet(string name, string description)
		{
			Street street = new Street();
			street.Name = name;
			street.Description = description;

			return street;
		}
	}
}