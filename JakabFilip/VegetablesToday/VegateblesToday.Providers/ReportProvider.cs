using System;
using System.Collections.Generic;
using System.Linq;
using VegetablesToday.Data.Base;

namespace VegateblesToday.Providers
{
	public class ReportProvider
	{
		public decimal CalculateTotalStockPriceOfAllVegetables(List<ProductOfNature> vegetableStock)
		{
			return vegetableStock.Sum(x => x.TotalPrice);
		}

		public decimal CalculateTotalStockPriceOfAllFruits(List<ProductOfNature> fruitStock)
		{
			return fruitStock.Sum(x => x.TotalPrice);
		}

		public List<ProductOfNature> GetAllItemsAfterBestBefore(List<ProductOfNature> stock)
		{
			return stock.Where(x => x.BestBefore < DateTime.Now).ToList();
		}
	}
}