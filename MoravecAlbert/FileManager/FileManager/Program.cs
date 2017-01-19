using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManager.Loggers;
using FileManager.Providers;

namespace FileManager
{
	class Program
	{
		static ILogger logger = new FileLogger(@"C:\temp\log.txt");

		static void Main(string[] args)
		{
			Providers.FileManager manager = new Providers.FileManager();

			manager.OnOperationStarted += Manager_OnOperationStarted;
			manager.OnOperationFinished += Manager_OnOperationFinished; ;

			manager.CopyFiles(@"C:\Windows\System32\", "*.png", @"C:\temp", true);
		}

		private static void Manager_OnOperationFinished(object sender, InformationEventArgs e)
		{
			logger.LogSuccess(e.Message);
		}

		private static void Manager_OnOperationStarted(object sender, InformationEventArgs e)
		{
			logger.LogInfo(e.Message);
		}
	}
}
