using System;
using System.Collections.Generic;
using System.Net;

namespace ClassroomHomework
{
	class Program
	{
		static List<Class> Classes = new List<Class>(40);
		static List<Classroom> Classrooms = new List<Classroom>(10);

		static void Main(string[] args)
		{
			int selection;
			bool valid;

			do
			{
				ShowMenu();

				do
				{
					valid = false;

					Console.Write("Please select option: ");

					if (int.TryParse(Console.ReadLine(), out selection) && selection >= 0 && selection <= 9)
					{
						valid = true;
						DoAction(selection);
					}
					else
					{
						Console.WriteLine("Please, enter valid option.");
					}
				} while (!valid);

			} while (true);
		}

		static void ShowMenu()
		{
			Console.WriteLine("1) Create class");
			Console.WriteLine("2) Create student");
			Console.WriteLine("3) Show classes");
			Console.WriteLine("4) Show students");
			Console.WriteLine("5) Show students in class");
			Console.WriteLine("6) Remove class");
			Console.WriteLine("7) Remove student");
			Console.WriteLine("9) Clear console");
			Console.WriteLine("0) Exit");
		}

		static void DoAction(int action)
		{
			switch (action)
			{
				case 1:
					CreateClass();
					break;

				case 2:
					CreateStudent();
					break;

				case 3:
					ShowClasses();
					break;

				case 9:
					Console.Clear();
					break;

				case 0:
					Environment.Exit(0);
					break;
			}
		}

		/*static Class GenerateData()
		{
			List<Subject> subjects = new List<Subject>(2);
			Subject math = new Subject("Mathematics", "MAT");
			Subject physics = new Subject("Physics", "FYZ");
			subjects.Add(math);
			subjects.Add(physics);

			List<Student> students = new List<Student>(30);
			Student am = new Student("Albert", "Moravec", 16, Person.Genders.Male, Student.Fields.InformationTechnologies,
				Student.Specializations.Programming, math);
			students.Add(am);

			Teacher teacher = new Teacher("Marie", "Kubickova", 0, Person.Genders.Female, subjects);

			Classroom classroom = new Classroom("C210");
			Class classobj = new Class("I2A", teacher, students, classroom);

			return classobj;
		}*/

		static void CreateClass()
		{
			string classname;

			do
			{
				Console.Write("Please enter class name: ");
				classname = Console.ReadLine();

				try
				{
					if (Helper.CheckClassname(classname))
					{
						Classes.Add(new Class(classname));
						break;
					}
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			} while (true);
		}

		static void CreateStudent()
		{
			string classname;
			int age;
			Person.Genders gender;
			Class assignTo = null;

			Console.Write("Enter first name: ");
			string firstName = Console.ReadLine();

			Console.Write("Enter last name: ");
			string lastName = Console.ReadLine();

			do
			{
				Console.Write("Enter age: ");

				if (int.TryParse(Console.ReadLine(), out age))
				{
					break;
				}

				Console.WriteLine("Invalid value. Please enter a valid one.");
			} while (true);

			do
			{
				Console.Write("Enter gender [M/F]: ");

				string rawGender = Console.ReadLine().ToLower();

				if (rawGender.Length == 1 && (rawGender[0] == 'm' || rawGender[0] == 'f'))
				{
					gender = (rawGender[0] == 'm') ? Person.Genders.Male : Person.Genders.Female;
					break;
				}

				Console.WriteLine("Invalid gender. Please enter valid one.");
			} while (true);

			do
			{

				Console.Write("Assign to class: ");
				classname = Console.ReadLine();

				if (Helper.CheckClassname(classname))
				{
					foreach (var @class in Classes)
					{
						if (@class.Name.Equals(classname))
							assignTo = @class;
					}

					if (assignTo == null)
					{
						Console.WriteLine("Class not found. Do you want to go to the main menu [Y/N]: ");
						do
						{
							string answer = Console.ReadLine().ToLower();
							if (answer.Length == 1)
							{
								if (answer[0] == 'y') return;
								if (answer[0] == 'n') break;
							}

							Console.WriteLine("Do you want to go to the main menu [Y/N]: ");
						} while (true);
					}
					else break;
				}
			} while (true);

			assignTo.Students.Add(new Student(firstName, lastName, age, gender));

		}

		static void ShowClasses()
		{
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("| Name\t| Students\t|");
			Console.ResetColor();

			foreach (var classMember in Classes)
			{
				Console.WriteLine($"| {classMember.Name}\t| {classMember.Students.Count}\t\t|");
			}
		}
	}
}
