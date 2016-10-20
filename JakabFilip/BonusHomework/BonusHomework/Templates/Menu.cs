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

		// -----------------------------------------------------------------------------------------------------------------------------------
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

		// -----------------------------------------------------------------------------------------------------------------------------------
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
					Console.Clear();
					break;
				case "-1":
					break;
				default:
					break;
			}
		}

		// -----------------------------------------------------------------------------------------------------------------------------------
		public void CreateClassRoom()
		{
			//	string className;

			//	Console.WriteLine("Enter class's name:");
			//	className = Console.ReadLine();

			//	try
			//	{
			//		Program.classRooms.First(x => x.name == className);
			//		Console.WriteLine("This name of class is already used.");
			//	}
			//	catch (Exception)
			//	{
			//		Program.classRooms.Add(new ClassRoom(className));
			//		Console.WriteLine("Class has been sucessfuly added");
			//	}

			string classNameInput;
			byte convertLevel;
			ClassRoom classFound;

			Console.Write("Enter class name: ");
			classNameInput = Console.ReadLine().ToUpper();

			// Validation
			if ((classNameInput[0] == 'I') || (classNameInput[0] == 'E')
					&&
				(classNameInput[1] >= 1) && (classNameInput[1] <= 4)
					&&
				(classNameInput[2] == 'A') || (classNameInput[2] == 'B') || (classNameInput[2] == 'C'))
			{
				if (!(byte.TryParse(classNameInput[1].ToString(), out convertLevel)))
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
				classFound = Program.classRooms.First(x => x.name == classNameInput);
				Console.WriteLine("Class with this name already exists ...");
			}
			catch (Exception)
			{
				Program.classRooms.Add(new ClassRoom
				{
					name = classNameInput,
					memberType = (classNameInput[2] == 'A') ? MemberTypes.A : (classNameInput[2] == 'B') ? MemberTypes.B : MemberTypes.C,
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
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Error: \n{0}", e.ToString());
			}
		}

		// -----------------------------------------------------------------------------------------------------------------------------------
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
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Error: \n{0}", e.ToString());
			}
		}

		// -----------------------------------------------------------------------------------------------------------------------------------
		public void RemoveClassRoom()
		{
			string classNameToDelete;
			ClassRoom classFound;

			Console.WriteLine("Enter name of class, wich should be deleted.");
			classNameToDelete = Console.ReadLine();

			try
			{
				classFound = Program.classRooms.FirstOrDefault(x => x.name == classNameToDelete);
				Program.classRooms.Remove(classFound);
				Console.WriteLine("Classroom has been succesfuly deleted.");
			}
			catch (Exception e)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Error: \n{0}", e.ToString());
			}
		}

		// -----------------------------------------------------------------------------------------------------------------------------------
		public void RemoveStudent()
		{
			string nameToDelete;
			string nameOfClass;
			Student studentToDelete;
			ClassRoom classFound;

			Console.WriteLine("Enter name of class, where student is: ");
			nameOfClass = Console.ReadLine();

			Console.WriteLine("Enter name of student, u wish to delete: ");
			nameToDelete = Console.ReadLine();

			try
			{
				classFound = Program.classRooms.FirstOrDefault(x => x.name == nameOfClass);
				studentToDelete = classFound.students.FirstOrDefault(x => x.name == nameToDelete);

				classFound.students.Remove(studentToDelete);
			}
			catch (Exception e)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Error: \n{0}", e.ToString());
			}
		}

		// -----------------------------------------------------------------------------------------------------------------------------------
		public void DisplayAllClasses()
		{
			if (Program.classRooms.Count() > 0)
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("List of all classes: ");

				Console.ForegroundColor = ConsoleColor.Cyan;
				foreach (ClassRoom classRoom in Program.classRooms)
				{
					Console.WriteLine($"  class-name: { classRoom.name }\tclass -amount of students: { ((classRoom.students == null) ? "0" : classRoom.students.Count().ToString())} ");
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
			string className;
			ClassRoom classFound;

			Console.WriteLine("Enter ClassRomm's name to be displayed:");
			className = Console.ReadLine();

			try
			{
				classFound = Program.classRooms.First(x => x.name == className);

				try
				{
					Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine($"Teacher: { classFound.teacher.name } with subject { classFound.teacher.subject }");
				}
				catch (Exception)
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("This class has no Teacher ...");
				}

				Console.ForegroundColor = ConsoleColor.Blue;
				foreach (Student student in classFound.students)
				{
					Console.WriteLine($"  student-id: { student.id },\tstudent-name: { student.name },\tstudent-age: { student.age }");
				}
			}
			catch (Exception e)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Error: \n{0}", e.ToString());
			}
		}

		// -----------------------------------------------------------------------------------------------------------------------------------
		public void DisplayTeachers()
		{
			try
			{
				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.WriteLine("List of teachers: ");
				Console.ForegroundColor = ConsoleColor.White;
				foreach (ClassRoom classToDisplay in Program.classRooms)
				{
					Console.WriteLine($"  Teachers-name: { classToDisplay.teacher.name } \twith { classToDisplay.teacher.subject.ToString() }");
				}
			}
			catch (Exception e)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Error: \n{0}", e.ToString());
			}
		}
	}
}
