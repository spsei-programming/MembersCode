using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSDaysOfYear.Helpers;

namespace SSDaysOfYear
{
	class Program
	{
		static void Main(string[] args)
		{
			int rok;
			Console.WriteLine("Zadej rok\n");
			rok = Convert.ToInt32(Console.ReadLine());
			SaSuDaysOfYear.CreateYearDirectory(rok);
		}
	}
}
