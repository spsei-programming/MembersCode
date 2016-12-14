using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZFileApplication
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var stopWatch = new Stopwatch();
			List<string> subDirs = new List<string>(10000);
			List<string> fileList = new List<string>(50000);
			List<FileInfo> fileInfoList = new List<FileInfo>(50000);
			List<int> azFileCount = new List<int>(26);
			Dictionary<char, List<FileInfo>> azDict = new Dictionary<char, List<FileInfo>>();

			stopWatch.Start();
			// getting The list of Sub directories ...
			GetAllSubDirs(@"C:\Program Files", subDirs);
			stopWatch.Stop();
			Console.WriteLine($"Time: {stopWatch.Elapsed}");

			// getting The List of Files from all directories -> subDirs
			stopWatch.Restart();
			GetAllFiles(subDirs, fileList);
			stopWatch.Stop();
			Console.WriteLine($"Time: {stopWatch.Elapsed}");

			Console.WriteLine($"Folders: {subDirs.Count}");
			Console.WriteLine($"Files: {fileList.Count}");

			stopWatch.Restart();
			GetFileInfos(fileList, fileInfoList);
			stopWatch.Stop();
			Console.WriteLine($"Time: {stopWatch.Elapsed}");

			stopWatch.Restart();
			azDict = InitAZDict();
			SortAZDIct(fileInfoList, azDict);
			stopWatch.Stop();
			Console.WriteLine($"Time: {stopWatch.Elapsed}");

			stopWatch.Restart();
			azFileCount = sortFileInfoList(fileInfoList);
			stopWatch.Stop();
			Console.WriteLine($"Time: {stopWatch.Elapsed}");
		}

		private static Dictionary<string, List<FileInfo>> analyzeByExtension(List<FileInfo> files)
		{
			Dictionary<string, List<FileInfo>> countsByExt = new Dictionary<string, List<FileInfo>>();

			foreach (var file in files)
			{
				if (!countsByExt.ContainsKey(file.Extension))
					countsByExt.Add(file.Extension, new List<FileInfo>(1000));

				countsByExt[file.Extension].Add(file);
			}
		}

		private static List<int> sortFileInfoList(List<FileInfo> filesInfos)
		{
			List<int> fileCount = new List<int>(26);

			for (int i = 0; i < 25; i++)
			{
				fileCount.Add(0);
			}

			for (int i = 0; i < 25; i++)
			{
				foreach (FileInfo file in filesInfos)
				{
					if (file.Name[0] == (char)(i + 'A'))
					{
						fileCount[i]++;
					}
				}
			}
			return fileCount;
		}

		private static void SortAZDIct(List<FileInfo> allFiles, Dictionary<char, List<FileInfo>> azDict)
		{
			foreach (FileInfo file in allFiles)
			{
				char key = file.Name.ToUpper()[0];

				if (azDict.ContainsKey(key))
					azDict[key].Add(file);
				else
				{
					azDict.Add(key, new List<FileInfo>(1000));
					azDict[key].Add(file);
				}
			}
		}

		private static Dictionary<char, List<FileInfo>> InitAZDict()
		{
			var azDict = new Dictionary<char, List<FileInfo>>();
			for (int i = 'A'; i <= 'Z'; i++)
			{
				azDict.Add((char)i, new List<FileInfo>(5000));
			}
			return azDict;
		}

		private static void GetFileInfos(List<string> fileList, List<FileInfo> files)
		{
			foreach (string filePath in fileList)
			{
				files.Add(new FileInfo(filePath));
			}
		}

		private static void GetAllFiles(List<string> subDirs, List<string> filesList)
		{
			foreach (string subDir in subDirs)
			{
				try
				{
					var files = Directory.GetFiles(subDir);
					filesList.AddRange(files);
				}
				catch (Exception)
				{
					Console.WriteLine("Error");
				}
			}
		}

		private static void GetAllSubDirs(string path, List<string> subDirs)
		{
			try
			{
				var directories = Directory.GetDirectories(path);

				if (directories.Length == 0) return;

				foreach (string dir in directories)
				{
					subDirs.Add(dir);
					GetAllSubDirs(dir, subDirs);
				}
			}
			catch (Exception)
			{
				Console.WriteLine("Unauthorized access");
			}
		}
	}
}
