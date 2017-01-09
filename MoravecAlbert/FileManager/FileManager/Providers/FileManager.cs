using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace FileManager.Providers
{
	public class FileManager
	{
		public void CopyFile(string from, string to, bool overwrite)
		{
			File.Copy(from, to, overwrite);
		}

		public void RemoveFile(string from)
		{
			throw new NotImplementedException();
		}

		public void CopyFiles(List<string> filesToCopy, string targetDir, bool overwrite)
		{
			filesToCopy.ForEach(f => CopyFile(f, Path.Combine(targetDir, /*f.Substring(f.LastIndexOf('\\') + 1))*/, overwrite));
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
	}
}