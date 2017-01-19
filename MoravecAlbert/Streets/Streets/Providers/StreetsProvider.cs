using System.Collections.Generic;
using Streets.Models;

namespace Streets.Providers
{
	public class StreetsProvider
	{
		public List<Street> Streets { get; set; }

		public StreetsProvider()
		{
			Streets = new List<Street>(10);
		}

		public List<Street> SearchStreet(string compare)
		{
			List<Street> result = new List<Street>(10);

			foreach (Street street in Streets)
			{
				if (street.Name.ToLower().Contains(compare.ToLower()))
					result.Add(street);
			}

			return result;
		}
	}
}