using System.Security.Cryptography.X509Certificates;

namespace FileManager.Loggers
{
	public interface ILogger
	{
		void LogInfo(string message);
		void LogSuccess(string message);
		void LogWarning(string message);
		void LogError(string message);
	}
}