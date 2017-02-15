using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegateblesToday.Providers;
using VegetablesToday.Data;
using VegetablesToday.Data.Base;
using VegetablesToday.Data.DataTypes;

namespace VegetablesToday
{
	public class Program
	{
		public static void Main(string[] args)
		{
			StockProvider stockProvider = new StockProvider();
			ReportProvider reportProvider = new ReportProvider();
			IOProvider ioProvider = new IOProvider();

			List<Apple> apples = new List<Apple>
			{
				new Apple()
				{
					Amount = 5,
					BestBefore = DateTime.Now,
					PurchasePricePerUnit = 15
				},
				new Apple()
				{
					Amount = 5,
					BestBefore = DateTime.Now,
					PurchasePricePerUnit = 15
				},
				new Apple()
				{
					Amount = 5,
					BestBefore = DateTime.Now,
					PurchasePricePerUnit = 15
				},
				new Apple()
				{
					Amount = 5,
					BestBefore = DateTime.Now,
					PurchasePricePerUnit = 15
				},
				new Apple()
				{
					Amount = 5,
					BestBefore = DateTime.Now,
					PurchasePricePerUnit = 15
				}
			};

			List<Orange> oranges = new List<Orange>
			{
				new Orange()
				{
					Amount = 5,
					BestBefore = DateTime.Now,
					PurchasePricePerUnit = 15
				},
				new Orange()
				{
					Amount = 5,
					BestBefore = DateTime.Now,
					PurchasePricePerUnit = 15
				},
				new Orange()
				{
					Amount = 5,
					BestBefore = DateTime.Now,
					PurchasePricePerUnit = 15
				},
				new Orange()
				{
					Amount = 5,
					BestBefore = DateTime.Now,
					PurchasePricePerUnit = 15
				},
				new Orange()
				{
					Amount = 5,
					BestBefore = DateTime.Now,
					PurchasePricePerUnit = 15
				}
			};

			List<Pineapple> pineapples = new List<Pineapple>
			{
				new Pineapple(),
				new Pineapple(),
				new Pineapple(),
				new Pineapple(),
				new Pineapple()
			};

			var allStocks = new List<ProductOfNature>();
			allStocks.AddRange(apples);
			allStocks.AddRange(oranges);
			allStocks.AddRange(pineapples);

			ioProvider.SaveAllDataToJSON(allStocks, @"C:\Users\student\Documents\tmp\tmpFile.json");

			Console.ReadKey();
		}
	}
}
