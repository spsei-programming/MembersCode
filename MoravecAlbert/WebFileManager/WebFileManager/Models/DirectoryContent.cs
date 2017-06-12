using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebFileManager.Models
{
	public class DirectoryContent
	{
		public List<RequestData> Files { get; set; }
		public List<RequestData> Directories { get; set; }

		public DirectoryContent()
		{
			Files = new List<RequestData>();
			Directories = new List<RequestData>();
		}
	}

	public class RequestData
	{
		public string Name { get; set; }
		public string Path { get; set; }

		public RequestData(string name, string path)
		{
			Name = name;
			Path = path;
		}
	}
}