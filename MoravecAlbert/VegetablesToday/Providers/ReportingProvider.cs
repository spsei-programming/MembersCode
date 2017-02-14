using System.Collections.Generic;
using Data.Base;

namespace Providers
{
	public class ReportingProvider
	{
		public List<ProductOfNature> Type { get; set; }

		public ReportingProvider()
		{
			Type = new List<ProductOfNature>(50);
		}

		public void AddToStock(ProductOfNature item)
		{
			Type.Add(item);
		}

		public void RemoveFromStock(int amount)
		{
			
		}
	}
}