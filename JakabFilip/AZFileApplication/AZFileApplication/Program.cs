using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AZFileApplication.Data;

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
			List<MyFileInfo> myFiles = new List<MyFileInfo>(10000);
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

			stopWatch.Restart();
			sumOfAllFilesLinq(fileInfoList, ".exe");
			stopWatch.Stop();
			Console.WriteLine("Time: {0}", stopWatch.Elapsed);

			stopWatch.Restart();
			printAllExeFiles(fileInfoList, ".exe");
			stopWatch.Stop();
			Console.WriteLine($"Time: {stopWatch.Elapsed}");

			stopWatch.Restart();
			myFiles = convertToMyFilesLinq(fileInfoList);
			stopWatch.Stop();
			Console.WriteLine($"Time: {stopWatch.Elapsed}");

			stopWatch.Restart();
			var x = myFiles[0].ToString();
			Console.WriteLine(x);
			stopWatch.Stop();
			Console.WriteLine($"Time: {stopWatch.Elapsed}");

			printAllFilesInDirsStartsWith(fileInfoList, "c");
		}

		private static long TotalSizeofFilesWithAttributes(List<FileInfo> files, FileAttributes atributes)
		{
			//long counter = 0;
			//files
			//	.Where(x => x.Attributes == FileAttributes.Hidden)
			//	.ToList()
			//	.ForEach(y =>
			//		{
			//			counter += y.Length;
			//		});
			//return counter;

			return files
				.Where(x => x.Attributes == atributes)
				.Sum(x => x.Length);
		}

		private FileInfo FirstFileWithGreaterSize(List<FileInfo> files, long size)
		{
			//return files.Find(x => x.Length > size);
			return files.FirstOrDefault(x => x.Length > size);
		}

		private static void printAllFilesInDirsStartsWith(List<FileInfo> files, string letter)
		{
			files
				.Where(file => file.Directory.Name.StartsWith(letter, StringComparison.InvariantCultureIgnoreCase))
				.OrderBy(x => x.Name)
				.ThenBy(x => x.Length)
				.Skip(10)
				.Take(10)
				.ToList()
				.ForEach(x => Console.WriteLine($"path: {x.FullName}, length: {x.Length.ToString("### ### ### ###")}"));
		}

		private static void printAllMyFilesByLenghtLinq(List<MyFileInfo> myFiles)
		{
			myFiles
				.Where(myFile => myFile.Lenght > 3000000)
				.ToList()
				.ForEach(Console.WriteLine);
		}

		private static void printAllExeMyFiles(List<MyFileInfo> files)
		{
			printAllMyFiles(files, ".exe");
		}

		private static void printAllMyFiles(List<MyFileInfo> files, string extension)
		{
			files.Select(myFile => myFile.Extension.Equals(extension, StringComparison.InvariantCultureIgnoreCase)).ToList().ForEach(Console.WriteLine);
		}

		private static List<MyFileInfo> convertToMyFilesLinq(List<FileInfo> files)
		{
			return files.Select(file =>
			{
				MyFileInfo myFile = new MyFileInfo
				{
					Name = file.Name,
					Created = file.CreationTime,
					Lenght = file.Length,
					Extension = file.Extension
				};
				return myFile;
			}).ToList();
		}

		private static List<MyFileInfo> convertToMyFilesPlain(List<FileInfo> files)
		{
			List<MyFileInfo> myFiles = new List<MyFileInfo>(files.Count);

			foreach (FileInfo file in files)
			{
				myFiles.Add(new MyFileInfo
				{
					Name = file.Name,
					Created = file.CreationTime,
					Lenght = file.Length,
					Extension = file.Extension
				});
			}

			return myFiles;
		}

		private static void printAllExeFiles(List<FileInfo> files, string extension)
		{
			printAllFiles(files, extension);
		}

		private static void printAllFiles(List<FileInfo> files, string extension)
		{
			files
				.Where(x => x.Extension.Equals(extension, StringComparison.InvariantCultureIgnoreCase))
				.ToList()
				.ForEach(file =>
				{
					Console.WriteLine($"File: {file.Name}, Lenght: {file.Length}");
				});
		}

		private static long SumOfAllExeFilesPlain(List<FileInfo> files)
		{
			long sum = 0;
			foreach (FileInfo fileInfo in files)
			{
				if (fileInfo.Extension.Equals(".exe", StringComparison.InvariantCultureIgnoreCase))
					sum += fileInfo.Length;
			}
			return sum;
		}

		private static long sumOfAllExeFilesLinq(List<FileInfo> files)
		{
			return sumOfAllFilesLinq(files, ".exe");
		}

		private static long sumOfAllFilesLinq(List<FileInfo> files, string extension)
		{
			//List<FileInfo> fileInfos = files.Where(file => file.Extension.Equals(".exe", StringComparison.InvariantCultureIgnoreCase)).ToList();
			//var sum = fileInfos.Sum(file => file.Length);

			return files
				.Where(x => x.Extension.Equals(extension, StringComparison.InvariantCultureIgnoreCase))
				.ToList()
				.Sum(x => x.Length);
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

			return countsByExt;
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
