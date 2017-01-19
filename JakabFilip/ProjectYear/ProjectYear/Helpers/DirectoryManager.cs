using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace ProjectYear.Helpers
{
	public static class DirectoryManager
	{
		/// <summary>
		/// Fills given Directory with directories of saturday and sunday of that year
		/// </summary>
		/// <param name="path">path + dir name</param>
		public static void FillDirectory(string path)
		{
			if (!ValidDirectory(path))
				return;

			var tmpDate = new DateTime(GetYearOfFinalDirectory(path), 1, 1);
			for (int i = 1; i <= 12; i++)
			{
				FillDirecotryWithDays(path, tmpDate, tmpDate.Year);
				tmpDate = tmpDate.AddMonths(1);
			}
		}

		public static void FillDirecotryWithDays(string path, DateTime date, int year)
		{
			for (int j = 1; j <= DateTime.DaysInMonth(year, date.Month); j++)
			{
				if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
					Directory.CreateDirectory(path + @"\" + DateTimeHelper.GetMonthName(date) + @"\" + date.Year + "----" + DateTimeHelper.GetMonthName(date) + "-" + date.Day);
				date = date.AddDays(1);
			}
		}

		public static bool ValidDirectory(string path)
		{
			int uselessVariable;
			var splitPath = path.Split('\\');
			var parentDirecotry = GetParentDirectory(path);

			if (!Directory.Exists(parentDirecotry))
				throw new UnauthorizedAccessException("Directory can be only created inside existing one");
			if (!int.TryParse(splitPath.ElementAt(splitPath.Length - 1), out uselessVariable))
				throw new ArgumentException("Name of given Directory doesnt corespond with valid syntax(int)");

			return true;
		}

		public static string GetParentDirectory(string path)
		{
			var splitPath = path.Split('\\');
			var tmp = "";

			for (int i = 0; i <= splitPath.Length - 2; i++)
			{
				tmp += (i == splitPath.Length - 2) ? splitPath[i] : splitPath[i] + @"\";
			}
			return tmp;
		}

		public static int GetYearOfFinalDirectory(string path)
		{
			var splitPath = path.Split('\\');
			int year;
			if (!int.TryParse(splitPath.ElementAt(splitPath.Length - 1), out year))
				throw new ArgumentException("Year must be number");
			return year;
		}
	}
}