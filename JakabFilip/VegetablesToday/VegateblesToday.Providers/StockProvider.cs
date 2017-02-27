using System;
using System.Collections.Generic;
using System.Linq;
using VegetablesToday.Data.Base;
using VegetablesToday.Data.Enums;

namespace VegateblesToday.Providers
{
	public class StockProvider
	{
		public List<ProductOfNature> Stock { get; set; } = new List<ProductOfNature>();

		private List<ProductOfNature> LoadData(string path)
		{
			throw new NotImplementedException();
		}

		private void SaveStock(string path)
		{
			throw new NotImplementedException();
		}

		public void OrderStock()
		{
			Stock =  Stock.OrderByDescending(x => x.BestBefore).ToList();
		}

		public List<ProductOfNature> SortStock(Kind kind)
		{
			return Stock.Where(x => x.Kind == kind).ToList();
		}

		public void AddToStock(ProductOfNature item)
		{
			Stock.Add(item);
		}

		public void RemoveFromStock(ProductOfNature item)
		{
			OrderStock();
			Stock.Remove(item);
		}
	}
}