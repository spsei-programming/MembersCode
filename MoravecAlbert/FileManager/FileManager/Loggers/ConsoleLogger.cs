using System;
using FileManager.Data.Enums;

namespace FileManager.Loggers
{
	public class ConsoleLogger : ILogger
	{
		public void LogInfo(string message)
		{
			LogMessage(message, LogLevels.Info);
		}

		public void LogSuccess(string message)
		{
			LogMessage(message, LogLevels.Success);
		}

		public void LogWarning(string message)
		{
			LogMessage(message, LogLevels.Warning);
		}

		public void LogError(string message)
		{
			LogMessage(message, LogLevels.Error);
		}

		public void LogMessage(string message, LogLevels level)
		{
			switch (level)
			{
				case LogLevels.Info:
					Console.ForegroundColor = ConsoleColor.Gray;
					break;
				case LogLevels.Success:
					Console.ForegroundColor = ConsoleColor.Green;
					break;
				case LogLevels.Warning:
					Console.ForegroundColor = ConsoleColor.Yellow;
					break;
				case LogLevels.Error:
					Console.ForegroundColor = ConsoleColor.Red;
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(level), level, null);
			}

			Console.WriteLine(message);
			Console.ResetColor();
		}
	}
}