using System;
using System.Collections.Generic;

namespace ClassroomHomework
{
	public static class Helper
	{
		public static bool CheckClassname(string classname)
		{
			if (classname.Length == 3 && (classname[0] == 'I' || classname[0] == 'E') &&
			    (classname[1] >= '1' && classname[1] <= '4') && (classname[2] >= 'A' && classname[2] <= 'D')) return true;

			throw new FormatException("Classname is not in valid format. Please enter valid name.");
		}
	}
}