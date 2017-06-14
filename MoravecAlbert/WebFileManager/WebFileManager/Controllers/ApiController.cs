using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Mvc;
using WebFileManager.Models;

namespace WebFileManager.Controllers
{
	public class FilesController : ApiController
	{
		public DirectoryContent Get(string path = "")
		{
			if (Path.IsPathRooted(path))
			{
				return null;
			}

			var applicationPath = HostingEnvironment.ApplicationPhysicalPath;
			var combinedPath = Path.Combine(applicationPath, path);

			var responseModel = new DirectoryContent();

			var directoryInfo = new DirectoryInfo(combinedPath);
			List<FileInfo> files = directoryInfo.GetFiles().ToList();
			List<DirectoryInfo> directories = directoryInfo.GetDirectories().ToList();

			responseModel.Files.AddRange(files.Select(file => new RequestData(file.Name, file.FullName)).ToList());
			responseModel.Directories.AddRange(directories.Select(directory => new RequestData(directory.Name, directory.FullName)).ToList());

			return responseModel;
		}

		public bool Delete(string path)
		{
			bool result = true;

			if (path == null)
			{
				return false;
			}

			if (System.IO.File.Exists(path))
			{
				var file = new FileInfo(path);
				file.Delete();
			} else if (Directory.Exists(path))
			{
				var dir = new DirectoryInfo(path);
				dir.Delete(true);
			}
			else
			{
				result = false;
			}

			return result;
		}
	}
}