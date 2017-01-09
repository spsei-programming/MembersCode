using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManager.Providers;

namespace FileManager
{
	class Program
	{
		static void Main(string[] args)
		{
			Providers.FileManager manager = new Providers.FileManager();

			manager.CopyFiles(@"C:\Windows\System32\", "*.png", @"C:\temp", true);
		}
	}
}
