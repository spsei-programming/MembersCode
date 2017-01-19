using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSDaysOfYear.Helpers
{
	static class SaSuDaysOfYear
	{
		//PUBLIC
		public static void CreateYearDirectory(int year)
		{
			Directory.CreateDirectory($@"C:\Users\Marie\SSDaysOfYear\{year}");
			CreateMonthsDirectory(year);
			CreateSaSuDaysDirectory(year);
		}
		//PRIVATE
		private static void CreateMonthsDirectory(int year)
		{
			for (int i = 1; i <= 12; i++)
			{
				Directory.CreateDirectory($@"C:\Users\Marie\SSDaysOfYear\{year}\{CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i)}");
			}
		}

		private static void CreateSaSuDaysDirectory(int year)
		{
			for (int month = 1; month <= 12; month++)
			{
				for (int day = 1; day <= DateTime.DaysInMonth(year, month); day++)
				{
					DateTime date = new DateTime(year, month, day);
					if ((date.DayOfWeek == DayOfWeek.Saturday)||(date.DayOfWeek == DayOfWeek.Sunday))
					{
						Directory.CreateDirectory($@"C:\Users\Marie\SSDaysOfYear\{year}\{CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month)}\{year}----{CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month)}-{day}");
					}
				}
			}
		}
	}
}
