using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;

namespace FileManager.Providers
{
	public class FileManager
	{
		public event EventHandler<InformationEventArgs> OnOperationStarted;
		public event EventHandler<InformationEventArgs> OnOperationFinished;
		 
		public string CopyFile(string from, string to, bool overwrite)
		{
			raiseOperationStarted($"Copying {from} to {to}");
			File.Copy(from, to, overwrite);

			raiseOperationFinished($"Finished copying {from}");
			return to;
		}

		public void RemoveFile(string from)
		{
			throw new NotImplementedException();
		}

		public void CopyFiles(List<string> filesToCopy, string targetDir, bool overwrite)
		{
			filesToCopy.ForEach(f => CopyFile(f, Path.Combine(targetDir, f.Substring(f.LastIndexOf('\\') + 1)), overwrite));
		}

		public void CopyFiles(string from, string mask, string to, bool overwrite)
		{
			Stopwatch watch = Stopwatch.StartNew();

			List<string> files = Directory.GetFiles(from, mask).ToList();
			
			CopyFiles(files, to, overwrite);

			watch.Stop();
			Console.WriteLine(watch.Elapsed);
		}

		public void RemoveFiles(string from, string mask)
		{
			throw new NotImplementedException();
		}

		private void raiseOperationStarted(string message)
		{
			if (OnOperationStarted != null)
			{
				OnOperationStarted.Invoke(this, new InformationEventArgs() {Message = message});
			}
		}

		private void raiseOperationFinished(string message)
		{
			if (OnOperationFinished != null)
			{
				OnOperationFinished.Invoke(this, new InformationEventArgs() {Message = message});
			}
		}
	}

	public class InformationEventArgs : EventArgs
	{
		public string Message { get; set; }
	}
}