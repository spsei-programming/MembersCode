using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BonusHomework.Templates;

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
				do
				{
					menu.Show();
					if (menu.GetInput())
						break;

					Console.WriteLine("Press any key to continue ...");
					Console.ReadKey();
				} while (true);

				if (menu.DoAction() == 1) break;

				Console.ResetColor();

				Console.WriteLine("press any key to continue ...");
				Console.ReadKey();

				Console.Clear();
			} while (true);

			Console.ReadKey();
			// ReSharper disable once FunctionNeverReturns
		}

		public static void GenerateTestDatas()
		{
			for (var i = 0; i < 10; i++)
			{
				classRooms.Add(new ClassRoom("TEST_CLASS." + i, MemberTypes.A, Orientations.Informatics, 1));
			}

			foreach (var classRoom in classRooms)
			{
				for (int i = 0; i < 30; i++)
				{
					classRoom.students.Add(new Student(i, "TEST_STUDENT." + i, 15, Person.Gender.Male, Subject.Programming));
				}
				classRoom.teacher = new Teacher(01, "TEST_TEACHER.XX", 30, Subject.Programming);
			}

			Console.WriteLine("All needed datas has been set for testing ...");
		}

		public static void UndefineTestingDatas()
		{
			List<Templates.ClassRoom> classesToDelete = new List<ClassRoom>();
			try
			{
				for (int i = 0; i < 10; i++)
				{
					var classToDelete = classRooms.First(x => x.name == "TEST_CLASS." + i.ToString());
					classesToDelete.Add(classToDelete);
				}

				for (int i = classesToDelete.Count - 1; i >= 0; i--)
				{
					classesToDelete.RemoveAt(i); // TODO finish it
				}

				Console.WriteLine(classesToDelete.Any()
					? "There are still some testing datas ...\nproblem occured ..."
					: "All testing datas has been deleted ...");
			}
			catch (ArgumentNullException e)
			{
				Console.WriteLine("nebyla nalezena zadna testovaci trida ... \n {0}", e.Message.ToString());
			}
			catch (ArgumentOutOfRangeException e)
			{
				Console.WriteLine("There is one big error ... \n{0}", e.Message);
			}
			catch (InvalidOperationException)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("There is no testing datas to be deleted ...");
				Console.ResetColor();
			}
		}
	}
}