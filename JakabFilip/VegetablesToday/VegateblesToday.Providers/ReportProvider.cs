using System.Collections.Generic;
using System.Linq;
using VegetablesToday.Data.Base;

namespace VegateblesToday.Providers
{
	public class ReportProvider
	{

		public decimal TotalPriceOfAllVegetables(List<ProductOfNature> vegetablesStock)
		{
			return vegetablesStock.Sum(x => x.TotalPrice);
		}
	}
}