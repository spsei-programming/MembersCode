﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirStats
{
	class Program
	{
		static void Main(string[] args)
		{
			Stopwatch stopwatch = Stopwatch.StartNew();

			var dirs = getSubdirs(@"C:\Program Files\", new List<string>(3000));
			var files = getFilesList(dirs);

			Console.WriteLine($"Folders: {dirs.Count}");
			Console.WriteLine($"Files: {files.Count}");


			stopwatch.Stop();
			Console.WriteLine($"Elapsed time: {stopwatch.Elapsed}");

			stopwatch.Restart();
			var fileInfo = getFiles(files);

			stopwatch.Stop();
			Console.WriteLine($"Elapsed time: {stopwatch.Elapsed}");

			stopwatch.Restart();
			var dict = getByFirstLetter(fileInfo);

			stopwatch.Stop();
			Console.WriteLine($"Elapsed time: {stopwatch.Elapsed}");

			Console.ReadKey();
		}

		private static List<string> getSubdirs(string directory, List<string> subdirsList)
		{
			try
			{
				List<string> directories = Directory.GetDirectories(directory).ToList();

				if (directories.Count == 0) return subdirsList;

				foreach (var dir in directories)
				{
					subdirsList.Add(dir);
					getSubdirs(dir, subdirsList);
				}

				return subdirsList;
			}
			catch (UnauthorizedAccessException e)
			{
				Console.WriteLine(e.Message);
				return subdirsList;
			}
			catch (Exception)
			{
				return subdirsList;
			}
		}

		private static List<string> getFilesList(List<string> dirs)
		{
			List<string> files = new List<string>(30000);

			try
			{
				foreach (var dir in dirs)
				{
					files.AddRange(Directory.GetFiles(dir));
				}

				return files;
			}
			catch (UnauthorizedAccessException e)
			{
				Console.WriteLine(e.Message);
				return files;
			}
			catch (Exception)
			{
				return files;
			}
		}

		private static List<FileInfo> getFiles(List<string> files)
		{
			List<FileInfo> fileInfo = new List<FileInfo>(30000); 

			foreach (var file in files)
			{
				fileInfo.Add(new FileInfo(file));
			}

			return fileInfo;
		}

		private static Dictionary<char, List<FileInfo>> getByFirstLetter(List<FileInfo> files)
		{
			Dictionary<char, List<FileInfo>> fileDict = new Dictionary<char, List<FileInfo>>(26);

			for (char i = 'A'; i <= 'Z'; i++)
			{
				List<FileInfo> fileList = new List<FileInfo>(1000);

				foreach (var fileInfo in files)
				{
					if (fileInfo.Name.ToUpper()[0] == i) fileList.Add(fileInfo);
				}

				fileDict.Add(i, fileList);
			}

			return fileDict;
		}
	}
}
