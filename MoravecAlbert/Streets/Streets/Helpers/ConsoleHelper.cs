using System;
using System.Collections.Generic;
using Streets.Models;
using Streets.Providers;

namespace Streets.Helpers
{
	public static class ConsoleHelper
	{
		public static SearchRequest SearchStreet()
		{
			SearchRequest searchRequest = new SearchRequest();
			Console.Write("Search for: ");
			searchRequest.SearchPattern = Console.ReadLine();

			Console.Write("Save to: ");
			searchRequest.FileName = Console.ReadLine();

			return searchRequest;
		}

		public static void ListStreets(List<Street> streets)
		{
			int pageCount;

			Console.Write("Page count: ");
			if (int.TryParse(Console.ReadLine(), out pageCount))
			{
				int pass = 0;
				foreach (Street street in streets)
				{
					pass++;
					Console.WriteLine($"Name: {street.Name}\nDescription: {street.Description}\n");

					if (pass % pageCount == 0)
						Console.ReadKey();
				}
			}
		}
	}
}