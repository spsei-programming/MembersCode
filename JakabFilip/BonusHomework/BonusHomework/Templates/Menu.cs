using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace BonusHomework.Templates
{
	public class Menu
	{
		private string _menuInput;

		public void Show()
		{
			Console.Clear();
			Console.WriteLine("Base Menu: ");

			Console.WriteLine("1. Create ClassRoom");
			Console.WriteLine("2. Create student");
			Console.WriteLine("3. Create Teacher");
			Console.WriteLine("4. Remove ClassRoom");
			Console.WriteLine("5. Remove Student");
			Console.WriteLine("6. List all classes");
			Console.WriteLine("7. Display detailed info of one class");
			Console.WriteLine("8. Display Teachers and their Subjects");
			Console.WriteLine("9. Print Hello world :)");
			Console.WriteLine("10. Create testing datas");
			Console.WriteLine("11. Delete testing datas");
			Console.WriteLine("0. Exit Program");
		}

		// -----------------------------------------------------------------------------------------------------------------------------------
		public bool GetInput()
		{
			//try
			//{
			//	_menuInput = Console.ReadLine();
			//}
			//catch (System.IO.IOException)
			//{
			//	Console.WriteLine("wrong input.");
			//	_menuInput = "-1";
			//}

			Console.Write("/> ");

			try
			{
				_menuInput = Console.ReadLine();

				if (Convert.ToInt16(_menuInput) < 0 || Convert.ToInt16(_menuInput) > 11)
					throw new ArgumentOutOfRangeException($"valid numbers: (0-11)");
			}
			catch (ArgumentOutOfRangeException e)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("ERROR: {0}", e.Message);
				Console.ResetColor();

				return false;
			}
			catch (FormatException e)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Oh i will tell u again: enter only valid numbers ... -.-\n {0}", e.Message);
				Console.ResetColor();

				return false;
			}

			return true;
		}

		// -----------------------------------------------------------------------------------------------------------------------------------
		public int DoAction()
		{
			switch (_menuInput)
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
					RemoveClassRoom();
					break;
				case "5":
					RemoveStudent();
					break;
				case "6":
					DisplayAllClasses();
					break;
				case "7":
					DisplayClassInfo();
					break;
				case "8":
					DisplayTeachers();
					break;
				case "9":
					Console.WriteLine("Hello world.");
					break;
				case "10":
					Program.GenerateTestDatas();
					break;
				case "11":
					Program.UndefineTestingDatas();
					break;
				case "0":
					Console.WriteLine("This program is about to be terminated ... cy@");
					return 1;
				default:
					break;
			}

			return 0;
		}

		// -----------------------------------------------------------------------------------------------------------------------------------
		public void CreateClassRoom()
		{
			byte convertLevel;

			Console.Write("Enter class name(0 to cancel): ");
			var classNameInput = Console.ReadLine().ToUpper();

			if (classNameInput == "0") return;

			// Validation
			if (((classNameInput[0] == 'I') || (classNameInput[0] == 'E'))
					&&
					(classNameInput[1] > '0') && (classNameInput[1] < '5')
					&&
					((classNameInput[2] == 'A') || (classNameInput[2] == 'B') || (classNameInput[2] == 'C')))
			{
				if (!byte.TryParse(classNameInput[1].ToString(), out convertLevel))
				{
					Console.WriteLine("Wrong level of class ...");
					return;
				}
			}
			else
			{
				Console.WriteLine("class name doesnt match with the standarts ...");

				return;
			}

			// if exists
			try
			{
				Program.classRooms.First(x => x.name == classNameInput);
				Console.WriteLine("Class with this name already exists ...");
			}
			catch (Exception)
			{
				Program.classRooms.Add(new ClassRoom
				{
					name = classNameInput,
					memberType =
						(classNameInput[2] == 'A') ? MemberTypes.A : (classNameInput[2] == 'B') ? MemberTypes.B : MemberTypes.C,
					classOrientation = (classNameInput[0] == 'I') ? Orientations.Informatics : Orientations.Engineers,
					level = convertLevel
				});

				Console.WriteLine("Class has been set. ");
			}
		}

		// -----------------------------------------------------------------------------------------------------------------------------------
		public void CreateStudent()
		{
			string id;
			string age;
			string name;
			string className;

			if (Program.classRooms.Any())
			{
				DisplayAllClasses();

				Console.Write("Enter Class name, where student should be put(0 to cancel):");
				className = Console.ReadLine();

				if (className == "0") return;

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
				var classFound = Program.classRooms.First(x => x.name == className);

				classFound.students.Add(new Student(int.Parse(id), name, int.Parse(age), Person.Gender.Male, Subject.Programming));
				Console.WriteLine($"student {name} has been sucessfuly added to class {className}.");
			}
			catch (Exception e)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Error: \n{0}", e.Message);
			}
		}

		// -----------------------------------------------------------------------------------------------------------------------------------
		public void CreateTeacher()
		{
			string className;

			

			if (Program.classRooms.Any())
			{
				DisplayAllClasses();

				try
				{
					Console.Write("Enter class name, a Teacher should be created in(0 to cancel):");
					className = Console.ReadLine();

					if (className == "0") return;

					Console.WriteLine("Enter Teacher's id: ");
					var id = Console.ReadLine();

					Console.WriteLine("Enter Teacher's name: ");

					var name = Console.ReadLine();

					Console.WriteLine("Enter Teacher's age: ");
					var age = Console.ReadLine();

					var classFound = Program.classRooms.First(x => x.name == className);

					classFound.teacher = new Teacher(int.Parse(id), name, int.Parse(age), Subject.Math);
				}
				catch (Exception e)
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("ERROR: \n{0}", e.Message);
				}
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("There is no class where teachet could be assigned ...");
				Console.ResetColor();
			}
		}

		// -----------------------------------------------------------------------------------------------------------------------------------
		public void RemoveClassRoom()
		{
			if (Program.classRooms.Any())
			{
				Console.Write("Enter name of class, wich should be deleted(0 to cancel): ");
				var classNameToDelete = Console.ReadLine();

				if (classNameToDelete == "0") return;

				try
				{
					var classFound = Program.classRooms.FirstOrDefault(x => x.name == classNameToDelete);
					Program.classRooms.Remove(classFound);
					Console.WriteLine("Classroom has been succesfuly deleted.");
				}
				catch (Exception e)
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Error: \n{0}", e.Message);
				}
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("There is no class to be removed ...");
				Console.ResetColor();
			}
		}

		// -----------------------------------------------------------------------------------------------------------------------------------
		public void RemoveStudent()
		{
			if (Program.classRooms.Any())
			{
				Console.WriteLine("Enter name of class, where student is(0 to cancel): ");
				var nameOfClass = Console.ReadLine();

				if (nameOfClass == "0") return;

				try // try to find className in list of classes in Program
				{
					var classFound = Program.classRooms.First(x => x.name == nameOfClass);

					Console.WriteLine("Enter name of student, u wish to delete: ");
					var nameToDelete = Console.ReadLine();

					// checks if students name is in entered class
					var studentToDelete = classFound.students.First(x => x.name == nameToDelete);
					classFound.students.Remove(studentToDelete);
					Console.WriteLine("Student has been deleted.");
				}
				catch (Exception)
				{
					Console.WriteLine("Class name, or student name is invalid.");
				}
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("There is no class, so no students to be removed ...");
				Console.ResetColor();
			}
		}

		// -----------------------------------------------------------------------------------------------------------------------------------
		public void DisplayAllClasses()
		{
			if (Program.classRooms.Any())
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("List of all classes: ");

				Console.ForegroundColor = ConsoleColor.Cyan;
				foreach (var classRoom in Program.classRooms)
				{
					Console.WriteLine($"  class-name: { classRoom.name }\tclass -amount of students: { ((classRoom.students.Any()) ? classRoom.students.Count().ToString() : "0")} ");
				}
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("There is no class to be displayed.");
			}
		}

		// -----------------------------------------------------------------------------------------------------------------------------------
		public void DisplayClassInfo()
		{
			Console.Clear();

			if (Program.classRooms.Any())
			{
				Console.Write("Enter ClassRomm's name to be displayed: ");
				var className = Console.ReadLine().ToUpper();

				System.Threading.Thread.Sleep(1000);
				Console.Clear();

				try
				{
					var classFound = Program.classRooms.First(x => x.name == className);

					//try
					//{
					//	Console.ForegroundColor = ConsoleColor.White;
					//	Console.WriteLine($"Teacher: { classFound.teacher.name } with subject { classFound.teacher.subject }");
					//}
					//catch (Exception)
					//{
					//	Console.ForegroundColor = ConsoleColor.Red;
					//	Console.WriteLine("This class has no Teacher ...");
					//}

					Console.WriteLine();

					//for (int i = 0; i < 10; i++)
					//{
					//	for (int j = 0; j < 10; j++)
					//	{
					//		if (j == 0)
					//		{
					//			Console.ForegroundColor = ConsoleColor.White;
					//			Console.Write(j);
					//		}
					//		else
					//		{
					//			Console.Write(j);
					//		}
					//		Console.ResetColor();
					//	}
					//}

					//sets the window ...

					var maxLenghtOfname = 0;

					foreach (var student in classFound.students)
					{
						if (student.name.Length > maxLenghtOfname)
							maxLenghtOfname = student.name.Length;
					}

					Console.BackgroundColor = ConsoleColor.White;
					for (int i = 0; i < classFound.students.Count + 2; i++)
					{
						for (int j = 0; j < 52 + maxLenghtOfname + 2; j++)
						{
							Console.SetCursorPosition(j, i);
							if (i == 0 || i == classFound.students.Count + 1)
								Console.Write(" ");
							else if (j == 0 || j == 52 + maxLenghtOfname + 1)
								Console.Write(" ");
						}
					}
					Console.ResetColor();

					for (var i = 0; i < classFound.students.Count; i++)
					{
						//Console.SetCursorPosition(0, i + 3);
						//Console.Write("|");

						Console.SetCursorPosition(17, i + 1);
						Console.Write("->");

						Console.SetCursorPosition(35 + maxLenghtOfname, i + 1);
						Console.Write(";");
					}

					//end of setting window

					Console.ForegroundColor = ConsoleColor.Blue;
					var counterY = 0;
					var colorCounter = 0;
					foreach (var student in classFound.students)
					{
						switch (colorCounter)
						{
							case 0:
								Console.BackgroundColor = ConsoleColor.Gray;
								colorCounter++;
								break;
							case 1:
								Console.BackgroundColor = ConsoleColor.DarkGray;
								colorCounter--;
								break;
						}

						Console.SetCursorPosition(1, counterY + 1);
						Console.Write($"student-id: { ((student.id < 10) ? student.id.ToString() + " " : student.id.ToString()) }");
						Console.SetCursorPosition(19, counterY + 1);
						Console.Write($" student-name: { student.name }");
						Console.SetCursorPosition((37 + maxLenghtOfname), counterY + 1);
						Console.Write($" student-age: { student.age }");

						counterY++;
					}
				}
				catch (Exception e)
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("ERROR: \n{0}", e.Message);
				}
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("There is no class to be displayed ...\nu need to create one ...");
				Console.ResetColor();
			}
		}

		// -----------------------------------------------------------------------------------------------------------------------------------
		public void DisplayTeachers()
		{
			//try
			//{
			//	Console.ForegroundColor = ConsoleColor.Cyan;
			//	Console.WriteLine("List of teachers: ");
			//	Console.ForegroundColor = ConsoleColor.White;
			//	foreach (ClassRoom classToDisplay in Program.classRooms)
			//	{
			//		Console.WriteLine($"  Teachers-name: { classToDisplay.teacher.name } \twith { classToDisplay.teacher.subject.ToString() }");
			//	}
			//}
			//catch (Exception e)
			//{
			//	Console.ForegroundColor = ConsoleColor.Red;
			//	Console.WriteLine("Error: \n{0}", e.Message.ToString());
			//}

			try
			{
				if (Program.classRooms.Any())
				{
					Console.ForegroundColor = ConsoleColor.Cyan;
					Console.WriteLine("List of teachers: ");
					Console.ForegroundColor = ConsoleColor.White;
					foreach (var classToDisplay in Program.classRooms)
					{
						Console.WriteLine(
							$"  Teachers-name: {classToDisplay.teacher.name} \twith {classToDisplay.teacher.subject.ToString()}");
					}
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("There is no class ... so there are no teachers to be displayed ...");
					Console.ResetColor();
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("ERROR: {0}", e.Message);
			}
		}
	}
}
