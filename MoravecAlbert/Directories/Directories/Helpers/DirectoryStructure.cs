using System;
using System.IO;

namespace Directories.Helpers
{
	public static class DirectoryStructure
	{
		public static void Create(DateTime date, DirectoryInfo directory)
		{
			int year = date.Year;
			while (date.Year == year)
			{
				int month = date.Month;
				DirectoryInfo monthDirectory = directory.CreateSubdirectory(date.ToString("MMMM"));
				
				while (date.Month == month)
				{
					if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
						monthDirectory.CreateSubdirectory(date.ToString("yyyy----MMMM-dd"));

					date = date.AddDays(1);
				}
			}
		}
	}
}