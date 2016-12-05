using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directories
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Zadejte rok: ");

			int year;
			if (!int.TryParse(Console.ReadLine(), out year))
			{
				throw new ArgumentException("Neplatna hodnota!");
			}

			Console.Write("Zadejte cestu: ");
			string path = Console.ReadLine();

			if (!Directory.Exists(path))
			{
				throw new DirectoryNotFoundException("Slozka nenalezena!");
			}

			Helpers.DirectoryStructure.Create(new DateTime(year, 1, 1),  new DirectoryInfo(path));
		}
	}
}
