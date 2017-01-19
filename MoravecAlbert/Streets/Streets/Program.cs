using System;
using System.Collections.Generic;
using Streets.Helpers;
using Streets.Models;
using Streets.Providers;

namespace Streets
{
	class Program
	{
		static void Main(string[] args)
		{
			StreetsProvider streetsProvider = new StreetsProvider();

			streetsProvider.Streets.Add(Street.CreateStreet("Puchmajerova", "Antonín Jaroslav Puchmajer (7. ledna 1769 Týn nad Vltavou[1] – 29. září 1820 Praha) byl český spisovatel, básník, překladatel a vlastenecký kněz."));
			streetsProvider.Streets.Add(Street.CreateStreet("Ahepjukova", "Radista Ivan Ahepjuk (je po něm pojmenována ostravská ulice Ahepjukova)"));
			streetsProvider.Streets.Add(Street.CreateStreet("Palackeho", "František Palacký (14. června 1798 Hodslavice[3] – 26. května 1876 Praha) byl český historik, politik, spisovatel a organizátor veřejného kulturního a vědeckého života v soudobé Praze."));

			DataHelper.Save(streetsProvider.Streets, "data.bin");
			streetsProvider.Streets = DataHelper.Load("data.bin");

			SearchRequest searchRequest = ConsoleHelper.SearchStreet();
			List<Street> resultStreets = streetsProvider.SearchStreet(searchRequest.SearchPattern);
			ConsoleHelper.ListStreets(resultStreets);
			DataHelper.Save(resultStreets, searchRequest.FileName);

			Console.ReadKey();
		}
	}
}

