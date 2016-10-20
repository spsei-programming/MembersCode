using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanzelkaJan.Homework1
{
	class Program
	{
		public void InitiateClass(Classroom classroom, Classroom.Orientations orientation, byte level, Classroom.Groups group)
		{
			classroom.Orientation = orientation;
			classroom.Level = level;
			classroom.Group = group;
			Console.WriteLine("Class initiated, class name: " + classroom.GetClassName());
		}


		static void Main(string[] args)
		{

			short index;
			short selection;
			string ClassroomName;
			string StudentName;
			List<Classroom> Classrooms = new List<Classroom>(5);
			List<Student> Students = new List<Student>(25);


			do
			{
				Console.WriteLine("1. Create a classroom");
				Console.WriteLine("2. Create a student");
				Console.WriteLine("3. Remove classroom");
				Console.WriteLine("4. Remove student ");
				Console.WriteLine("5. List of all classrooms");
				Console.WriteLine("6. List of all students");
				Console.WriteLine("7. List of all students in a class");
				Console.WriteLine("8. ");
				Console.WriteLine("9. Clear the screen");
				Console.WriteLine("0. Exit program\n");

				selection = Convert.ToInt16(Console.ReadLine());

				if (selection == 0) break;


				switch (selection)
				{

					case 1:

						do
						{
							Console.Write("Classroom name(e.g. I1A, 0 to cancel): ");
							ClassroomName = Console.ReadLine().ToUpper();

							if (ClassroomName == "0") break;

							if ((ClassroomName[0] == 'I' || ClassroomName[0] == 'E') &&
							    Convert.ToByte(ClassroomName[1])>'0' && Convert.ToByte(ClassroomName[1])<'5' &&
							    (ClassroomName[2] == 'A' || ClassroomName[2] == 'B' || ClassroomName[2] == 'C'))
							{
								if (
									Classrooms.Exists(
										x =>
											x.Orientation ==
											(ClassroomName[0] == 'I' ? Classroom.Orientations.Informatici : Classroom.Orientations.Elektro)) &&
									Classrooms.Exists(x => x.Level == Byte.Parse(Convert.ToString(ClassroomName[1]))) &&
									Classrooms.Exists(
										x =>
											x.Group == (ClassroomName[2] == 'A'
												? Classroom.Groups.A
												: ClassroomName[2] == 'B' ? Classroom.Groups.B : Classroom.Groups.C)))
								{
									Console.WriteLine("\n---Classroom already exists---\n");
								}
								else
								{
									Classrooms.Add(new Classroom
									{
										Orientation = ClassroomName[0] == 'I' ? Classroom.Orientations.Informatici : Classroom.Orientations.Elektro,
										Level = Byte.Parse(Convert.ToString(ClassroomName[1])),
										Group =
											ClassroomName[2] == 'A'
												? Classroom.Groups.A
												: ClassroomName[2] == 'B' ? Classroom.Groups.B : Classroom.Groups.C
									});
								}

							}
							else
							{
								Console.WriteLine("Invalid classroom name\n");
							}
							Console.WriteLine("Press Y to add another classroom, anything else to go back to menu\n");
						} while (Console.ReadKey(true).Key==ConsoleKey.Y);

						break;

					case 2:

						do
						{
							Console.Write("Student name(e.g. Martin Sladek, 0 to cancel): ");
							StudentName = Console.ReadLine();
							if (StudentName == "0") break;
							Console.WriteLine("Which classroom will they be attending?(Index)\n");

							foreach(Classroom classroom in Classrooms)
								Console.WriteLine(Classrooms.IndexOf(classroom)+1+ ". " + classroom.GetClassName());

							Console.WriteLine();

							var names = StudentName.Split(' ');

							Students.Add(new Student {FirstName = names.First(), LastName = names.Last(), IdentificationNumber = Students.Count+1, Class = Classrooms[Int16.Parse(Console.ReadLine())-1]});

							Console.WriteLine("Press Y to add another student, anything else to go back to menu\n");
						} while (Console.ReadKey(true).Key == ConsoleKey.Y);

						break;

					case 3:

						do
						{


							Console.WriteLine("Which class do you want to remove?(Index, 0 to cancel)\n");
							foreach (Classroom classroom in Classrooms)
								Console.WriteLine(Classrooms.IndexOf(classroom) + 1 + ". " + classroom.GetClassName());
							Console.WriteLine();

							index = Int16.Parse(Console.ReadLine());

							if (index == 0) break;

							Console.WriteLine("Press Y to confirm deletion, anything else to cancel\n");
							if (Console.ReadKey(true).Key == ConsoleKey.Y)
							{
								Console.WriteLine($"Classroom {Classrooms[index-1].GetClassName()} deleted\n");
								Classrooms.RemoveAt(index - 1);
							}
							Console.WriteLine("Press Y to delete another classroom, anything else to go back to menu\n");
						} while (Console.ReadKey(true).Key == ConsoleKey.Y);

						break;
					case 4:

					do
					{
						Console.WriteLine("Which student do you want to remove?(Index, 0 to cancel)\n");
						foreach (Student student in Students)
							Console.WriteLine(Students.IndexOf(student) + 1 + ". " + student.GetStudentName());
						Console.WriteLine();

						index = Int16.Parse(Console.ReadLine());

						if (index == 0) break;

						Console.WriteLine("Press Y to confirm deletion, anything else to cancel\n");
						if (Console.ReadKey(true).Key == ConsoleKey.Y)
						{
							Console.WriteLine($"Student {Students[index - 1].GetStudentName()} deleted\n");
							Students.RemoveAt(index - 1);
						}
						Console.WriteLine("Press Y to delete another student, anything else to go back to menu\n");
					} while (Console.ReadKey(true).Key == ConsoleKey.Y) ;

					break;

					case 5:

						Console.ForegroundColor = ConsoleColor.Cyan;
						Console.WriteLine("{0,-20}{1,-20}","Index", "Class name");
						Console.ForegroundColor = ConsoleColor.Gray;
						foreach (Classroom classroom in Classrooms)
							Console.WriteLine("{0,-20}{1,-20}",Classrooms.IndexOf(classroom) + 1 + ". ", classroom.GetClassName());
						Console.WriteLine();
						Console.ReadKey(true);

						break;
					case 6:

						Console.ForegroundColor = ConsoleColor.Cyan;
						Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}","ID","First Name","Last Name","Classroom");
						Console.ForegroundColor = ConsoleColor.Gray;
						foreach (Student student in Students)
						{
							Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}", student.IdentificationNumber, student.FirstName,student.LastName, student.Class.GetClassName());
						}
						Console.ReadKey(true);
						Console.WriteLine();

						break;
					case 7:

						Console.WriteLine("Show students from which classroom?(Index, 0 to cancel)");

						foreach (Classroom classroom in Classrooms)
							Console.WriteLine(Classrooms.IndexOf(classroom) + 1 + ". " + classroom.GetClassName());
						Console.WriteLine();

						index = Int16.Parse(Console.ReadLine());

						if (index == 0) break;

						Console.ForegroundColor = ConsoleColor.Cyan;
						Console.WriteLine("{0,-20}{1,-20}{2,-20}", "ID", "First name", "Last name");
						Console.ForegroundColor = ConsoleColor.Gray;

						foreach (Student student in Students)
						{
							if(student.Class == Classrooms[index-1])
							Console.WriteLine("{0,-20}{1,-20}{2,-20}", student.IdentificationNumber, student.FirstName, student.LastName);
						}
						Console.WriteLine();
						Console.ReadKey(true);

						break;
					case 8:
						break;
					case 9:
						Console.Clear();
						break;
					case 0:
						break;
					default:
						Console.WriteLine("Invalid selection.\n");
						break;

				}


			} while (selection!=0);


		}
	}
}