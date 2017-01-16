using System;
using System.IO;
using FileManager.Data.Enums;

namespace FileManager.Loggers
{
	public class FileLogger : ILogger
	{
		private string logFilePath;

		public FileLogger(string filePath)
		{
			logFilePath = filePath;
		}

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
			string row = DateTime.Now.ToString("\r\n[yyyy-MM-dd HH:mm:ss.FFFF]");

			switch (level)
			{
				case LogLevels.Info:
					row += "[INFO]";
					break;
				case LogLevels.Success:
					row += "[SUCCESS]";
					break;
				case LogLevels.Warning:
					row += "[WARNING]";
					break;
				case LogLevels.Error:
					row += "[ERROR]";
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(level), level, null);
			}

			row += $"\t {message}";

			File.AppendAllText(logFilePath, row);
		}
	}
}