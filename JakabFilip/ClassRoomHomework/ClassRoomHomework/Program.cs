using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRoomHomework
{
	class Program
	{
		public static int teachers;
		public static List<ProgramClasses.ClassRoom> classRooms = new List<ProgramClasses.ClassRoom>(10);

		static void Main(string[] args)
		{
			teachers = 0;

			classRooms.Add(new ProgramClasses.ClassRoom("I1C", 1, "Jmeno_Ucitel", 25));
			classRooms.Add(new ProgramClasses.ClassRoom("I2C", 2, "Jmeno_Ucitel", 27));
			classRooms.Add(new ProgramClasses.ClassRoom("I3C", 3, "Jmeno_Ucitel", 27));
			classRooms.Add(new ProgramClasses.ClassRoom("I4C", 4, "Jmeno_Ucitel", 27));
			classRooms.Add(new ProgramClasses.ClassRoom("I5C", 5, "Jmeno_Ucitel", 27));

			Console.ReadKey();
		}
	}
}
