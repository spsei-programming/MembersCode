﻿using System;
using System.Globalization;

namespace ProjectYear.Helpers
{
	public static class DateTimeHelper
	{
		public static string GetMonthName(DateTime date)
		{
			return date.ToString("MMMM");
		}
	}
}