using System;

namespace AZFileApplication.Data
{
	public class MyFileInfo
	{
		public string Name { get; set; }
		public long Lenght { get; set; }
		public DateTime Created { get; set; }
		public string Extension { get; set; }

		public override string ToString()
		{
			return $"File: {Name}, Lenght: {Lenght}";
		}
	}
}