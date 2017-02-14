using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Providers;

namespace VegetablesToday
{
	class Program
	{
		static void Main(string[] args)
		{
			StockProvider stockProvider = new StockProvider();
			ReportingProvider reportingProvider = new ReportingProvider(stockProvider.Stock);

			stockProvider.AddToStock(new Orange()
			{
				Amount = 20,
				BestBefore = new DateTime(2017, 02, 16),
				PurchaseDate = DateTime.Now,
				PurchasePricePerUnit = 120
			});

			stockProvider.AddToStock(new Onion()
			{
				Amount = 8,
				BestBefore = new DateTime(2017, 02, 12),
				PurchaseDate = DateTime.Now,
				PurchasePricePerUnit = 15
			});

			Console.WriteLine($"Total vegetable price: {reportingProvider.CalculateTotalStockPriceOfAllVegetables()}");
			Console.WriteLine($"Total fruit price: {reportingProvider.CalculateTotalStockPriceOfAllFruits()}");
			stockProvider.RemoveFromStock("Orange", 2);
			Console.WriteLine($"Total fruit price: {reportingProvider.CalculateTotalStockPriceOfAllFruits()}");
			reportingProvider.DisplayAllItemsAfterBestBefore();

			Console.ReadKey();
		}
	}
}
