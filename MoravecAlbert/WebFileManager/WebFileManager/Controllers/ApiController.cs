using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using WebFileManager.Models;

namespace WebFileManager.Controllers
{
	public class ApiController : Controller
	{
		public ActionResult Get(string path = "")
		{
			if (Path.IsPathRooted(path))
			{
				return Content("[]", "application/json");
			}

			var applicationPath = HostingEnvironment.ApplicationPhysicalPath;
			var combinedPath = Path.Combine(applicationPath, path);

			var responseModel = new DirectoryContent();

			var directoryInfo = new DirectoryInfo(combinedPath);
			List<FileInfo> files = directoryInfo.GetFiles().ToList();
			List<DirectoryInfo> directories = directoryInfo.GetDirectories().ToList();

			responseModel.Files.AddRange(files.Select(file => new RequestData(file.Name, file.FullName)).ToList());
			responseModel.Directories.AddRange(directories.Select(directory => new RequestData(directory.Name, directory.FullName)).ToList());

			var response = Newtonsoft.Json.JsonConvert.SerializeObject(responseModel);
			//TODO folders

			return Content(response, "application/json");
		}

		public ActionResult Delete(string path)
		{
			bool result = true;

			if (path == null)
			{
				return Content(Newtonsoft.Json.JsonConvert.SerializeObject(new { result = false }), "application/json");
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

			return Content(Newtonsoft.Json.JsonConvert.SerializeObject(new { result }), "application/json");
		}
	}
}