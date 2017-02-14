using System.Collections.Generic;
using System.Linq;
using Data.Base;

namespace Providers
{
	public class StockProvider
	{
		public List<ProductOfNature> Stock { get; }

		public StockProvider()
		{
			Stock = new List<ProductOfNature>(50);
		}

		public void AddToStock(ProductOfNature item)
		{
			Stock.Add(item);
		}

		public void RemoveFromStock(string item, decimal amount)											// <---- this code is shit, plz no hate
		{
			var sorted = Stock.Where(x => x.Name == item).OrderBy(x => x.BestBefore);
			if (!sorted.Any() || Stock.Sum(x => x.Amount) < amount) return;
			
			do
			{
				if (amount >= sorted.First().Amount)
				{
					amount -= sorted.First().Amount;
					sorted.ToList().Remove(sorted.First());
				}
				else
				{
					sorted.First().Amount -= amount;
					amount = 0;
				}
			} while (amount != 0);
		}
	}
}