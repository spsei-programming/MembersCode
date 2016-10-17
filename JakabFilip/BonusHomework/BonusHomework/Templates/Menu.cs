using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonusHomework.Templates
{
	public class Menu
	{
		public string menuInput;

		public void Show()
		{
			Console.WriteLine("Base Menu: ");

			Console.WriteLine("1. Create ClassRoom");
			Console.WriteLine("2. Create student");
			Console.WriteLine("3. Create Teacher");
			Console.WriteLine("4. Remove ClassRoom");
			Console.WriteLine("5. Remove Student");
			Console.WriteLine("6. List all classes");
			Console.WriteLine("7. Display detailed info of one class");
			Console.WriteLine("8. Display Teachers and their Subjects");
			Console.WriteLine("9. Clear Board");
			Console.WriteLine("0. Exit Program\n");
		}

		public void GetInput()
		{
			try
			{
				menuInput = Console.ReadLine();
			}
			catch (System.IO.IOException)
			{
				Console.WriteLine("wrong input.");
				menuInput = "-1";
			}
		}

		public void DoAction()
		{
			switch (menuInput)
			{
				case "1":
					CreateClassRoom();
					break;
				case "2":
					CreateStudent();
					break;
				case "3":
					CreateTeacher();
					break;
				case "4":
					break;
				case "5":
					break;
				case "6":
					DisplayAllClasses();
					break;
				case "7":
					DisplayClassInfo();
					break;
				case "8":
					break;
				case "9":
					Console.Clear();
					break;
				case "-1":
					break;
				default:
					break;
			}
		}

		public void CreateClassRoom()
		{
			string className;

			Console.WriteLine("Enter class's name:");
			className = Console.ReadLine();

			Program.classRooms.Add(new ClassRoom(className));
			Console.WriteLine("Class has been sucessfuly added");
		}

		public void CreateStudent()
		{
			string id;
			string age;
			string name;
			string className;

			ClassRoom classFound;

			if (Program.classRooms.Count() > 0)
			{
				Console.WriteLine("Enter Class name, where student should be put:");
				className = Console.ReadLine();

				Console.WriteLine("Enter student's name:");
				name = Console.ReadLine();

				Console.WriteLine("Enter student's id:");
				id = Console.ReadLine();

				Console.WriteLine("Enter student's age:");
				age = Console.ReadLine();
			}
			else
			{
				Console.WriteLine("There is no class, where student can be added.");
				return;
			}

			try
			{
				classFound = Program.classRooms.FirstOrDefault(x => x.name == className);

				classFound.students.Add(new Student(Int32.Parse(id), name, Int32.Parse(age), Person.Gender.Male, Subject.Programming));
				Console.WriteLine($"student { name } has been sucessfuly added to class { className }.");
			}
			catch (Exception e)
			{
				Console.WriteLine("Error: {0}.", e.ToString());
			}
		}

		public void CreateTeacher()
		{
			string id;
			string age;
			string name;

			string className;

			ClassRoom classFound;
			try
			{
				Console.WriteLine("Enter class name, a Teacher should be created in:");
				className = Console.ReadLine();

				Console.WriteLine("Enter Teacher's id: ");
				id = Console.ReadLine();

				Console.WriteLine("Enter Teacher's name: ");

				name = Console.ReadLine();

				Console.WriteLine("Enter Teacher's age: ");
				age = Console.ReadLine();

				classFound = Program.classRooms.First(x => x.name == className);

				classFound.teacher = new Teacher(Int32.Parse(id), name, Int32.Parse(age), Subject.Math);
			}
			catch (Exception e)
			{
				Console.WriteLine("Error has appeared. {0}", e.ToString());
			}
		}

		public void DisplayAllClasses()
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("List of all classes: ");

			Console.ForegroundColor = ConsoleColor.Blue;
			foreach (ClassRoom classRoom in Program.classRooms)
			{
				Console.WriteLine($"  class-name: { classRoom.name }\tclass-amount of students: { classRoom.students.Count().ToString() } ");
			}

			Console.ResetColor();
		}

		public void DisplayClassInfo()
		{
			string className;
			ClassRoom classFound;

			Console.WriteLine("Enter ClassRomm's name to be displayed:");
			className = Console.ReadLine();

			try
			{
				classFound = Program.classRooms.First(x => x.name == className);

				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine($"Teacher: { classFound.teacher.name } with subject { classFound.teacher.subject }");

				Console.ForegroundColor = ConsoleColor.Blue;
				foreach (Student student in classFound.students)
				{
					Console.WriteLine($"  student-id: { student.id },\tstudent-name: { student.name },\tstudent-age: { student.age }");
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("Error: {0}", e.ToString());
			}

			Console.ResetColor();
		}
	}
}
