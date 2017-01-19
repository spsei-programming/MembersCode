using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectYear.Helpers;

namespace ProjectYear
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Create parent Directory inside root: ");
			Directory.CreateDirectory(Console.ReadLine());
			Console.WriteLine("Enter path for DateTime directory: (int(year)) at the end of path ... \nExample: C:\\Users\\asd\\...\\root\\parentDirectory\\2000");
			DirectoryManager.FillDirectory(Console.ReadLine());
		}
	}
}
