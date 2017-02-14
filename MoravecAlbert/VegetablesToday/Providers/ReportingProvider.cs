using System;
using System.Collections.Generic;
using System.Linq;
using Data.Base;
using Data.Enums;

namespace Providers
{
	public class ReportingProvider
	{
		public List<ProductOfNature> stock;

		public ReportingProvider(List<ProductOfNature> stock)
		{
			this.stock = stock;
		}

		public decimal CalculateTotalStockPriceOfAllVegetables()
		{
			return CalculateTotalStockPriceOfAllKind(Kinds.Vegetable);
		}

		public decimal CalculateTotalStockPriceOfAllFruits()
		{
			return CalculateTotalStockPriceOfAllKind(Kinds.Fruit);
		}

		public decimal CalculateTotalStockPriceOfAllKind(Kinds kind)
		{
			return stock.Where(x => x.Kind == kind).Sum(x => x.TotalPrice);
		}

		public void DisplayAllItemsAfterBestBefore()
		{
			stock.Where(x => x.BestBefore < DateTime.Now).ToList().ForEach(x =>
			{
				Console.WriteLine(); //TODO So tired...
			});
		}
	}
}