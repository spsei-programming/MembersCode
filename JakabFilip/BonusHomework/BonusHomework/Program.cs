using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonusHomework
{
	class Program
	{
		public static Templates.Menu menu = new Templates.Menu();
		public static List<Templates.ClassRoom> classRooms = new List<Templates.ClassRoom>();

		static void Main(string[] args)
		{
			do
			{
				menu.Show();
				menu.GetInput();
				menu.DoAction();

				Console.ResetColor();
			} while (menu.menuInput != "0");
		}
	}
}
