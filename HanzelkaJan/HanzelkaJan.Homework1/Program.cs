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

		//----------------------------- Fields -----------------------------
		short index;
		string ClassroomName;
		string StudentName;
		List<Classroom> Classrooms = new List<Classroom>(5);
		List<Student> Students = new List<Student>(25);

		//----------------------------- Main -----------------------------

		static void Main(string[] args)
		{

			short selection;

			Program program = new Program();

			do
			{

				Console.WriteLine("1. Create a classroom");
				Console.WriteLine("2. Create a student");
				Console.WriteLine("3. Remove classroom");
				Console.WriteLine("4. Remove student ");
				Console.WriteLine("5. List of all classrooms");
				Console.WriteLine("6. List of all students");
				Console.WriteLine("7. List of all students in a class");
				Console.WriteLine("8. Clear the screen");
				Console.WriteLine("0. Exit program\n");

				selection = Convert.ToInt16(Console.ReadLine());

				if (selection == 0) break;


				switch (selection)
				{

					case 1:

						program.CreateClassroom();
						break;

					case 2:

						program.CreateStudent();
						break;

					case 3:

						program.RemoveClassroom();
						break;

					case 4:

						program.RemoveStudent();
						break;

					case 5:

						program.GetClassrooms();
						Console.WriteLine("\nPress any key to continue.\n");
						Console.ReadKey(true);

						break;

					case 6:

						program.GetStudents();
						Console.WriteLine("\nPress any key to continue\n");
						Console.ReadKey(true);
						break;

					case 7:

						program.GetClassStudents();
						Console.WriteLine("\nPress any key to continue.\n");
						Console.ReadKey(true);
						break;

					case 8:

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

		//----------------------------- Methods -----------------------------

		//----------------------------- CreateClassroom -----------------------------

		/// <summary>
		/// Creates a new classroom based on text input
		/// </summary>
		public void CreateClassroom()
		{
			do
			{
				Console.Write("Classroom name(e.g. I1A, 0 to cancel): ");
				ClassroomName = Console.ReadLine().ToUpper();

				if (ClassroomName == "0") break;

				//Checks format
				if ((ClassroomName[0] == 'I' || ClassroomName[0] == 'E') &&
						Convert.ToByte(ClassroomName[1]) > '0' && Convert.ToByte(ClassroomName[1]) < '5' &&
						(ClassroomName[2] == 'A' || ClassroomName[2] == 'B' || ClassroomName[2] == 'C'))		
				{
					//Checks if classroom already exists
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
						//Converts from text to Classroom fields and then adds Classroom to a list
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
			} while (Console.ReadKey(true).Key == ConsoleKey.Y);
		}

		//----------------------------- CreateStudent -----------------------------

		/// <summary>
		/// Creates a new student based on text input
		/// </summary>
		public void CreateStudent()
		{
			do
			{
				Console.Write("Student name(e.g. Martin Sladek, 0 to cancel): ");
				StudentName = Console.ReadLine();

				if (StudentName == "0") break;

				Console.WriteLine("Which classroom will they be attending?(Index)\n");

				GetClassrooms();

				Console.WriteLine();

				//Splits text into Student fields
				var names = StudentName.Split(' ');
				Students.Add(new Student { FirstName = names.First(), LastName = names.Last(), IdentificationNumber = Students.Count + 1, Class = Classrooms[Int16.Parse(Console.ReadLine()) - 1] });

				Console.WriteLine("Press Y to add another student, anything else to go back to menu\n");
			} while (Console.ReadKey(true).Key == ConsoleKey.Y);
		}

		//----------------------------- RemoveClassroom -----------------------------

		/// <summary>
		/// Removes classroom from list based on selection
		/// </summary>
		public void RemoveClassroom()
		{
			do
			{
				Console.WriteLine("Which class do you want to remove?(Index, 0 to cancel)\n");

				GetClassrooms();

				Console.WriteLine();

				index = Int16.Parse(Console.ReadLine());

				if (index == 0) break;

				Console.WriteLine("Press Y to confirm deletion, anything else to cancel\n");

				//Confirmation for deletion
				if (Console.ReadKey(true).Key == ConsoleKey.Y)
				{
					Console.WriteLine($"Classroom {Classrooms[index - 1].GetClassName()} deleted\n");
					Classrooms.RemoveAt(index - 1);
				}

				Console.WriteLine("Press Y to delete another classroom, anything else to go back to menu\n");

			} while (Console.ReadKey(true).Key == ConsoleKey.Y);
		}

		//----------------------------- RemoveStudent -----------------------------

		/// <summary>
		/// Removes student from list based on selection
		/// </summary>
		public void RemoveStudent()
		{
			do
			{
				Console.WriteLine("Which student do you want to remove?(Index, 0 to cancel)\n");

				GetStudents();

				index = Int16.Parse(Console.ReadLine());

				if (index == 0) break;

				Console.WriteLine("Press Y to confirm deletion, anything else to cancel\n");

				//Confirmation for deletion
				if (Console.ReadKey(true).Key == ConsoleKey.Y)
				{
					Console.WriteLine($"Student {Students[index - 1].GetStudentName()} deleted\n");
					Students.RemoveAt(index - 1);
				}

				Console.WriteLine("Press Y to delete another student, anything else to go back to menu\n");

			} while (Console.ReadKey(true).Key == ConsoleKey.Y);
		}

		//----------------------------- GetClassrooms -----------------------------

		/// <summary>
		/// Prints out Index and Class name of all classrooms
		/// </summary>
		public void GetClassrooms()
		{

			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("{0,-20}{1,-20}", "Index", "Class name");
			Console.ForegroundColor = ConsoleColor.Gray;

			foreach (Classroom classroom in Classrooms)
				Console.WriteLine("{0,-20}{1,-20}", Classrooms.IndexOf(classroom) + 1, classroom.GetClassName());

		}

		//----------------------------- GetStudents -----------------------------

		/// <summary>
		/// Prints out the ID, First Name, Last Name and Classroom of all students
		/// </summary>
		public void GetStudents()
		{
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}", "ID", "First name", "Last name", "Classroom");
			Console.ForegroundColor = ConsoleColor.Gray;
			foreach (Student student in Students)
			{
				Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}", student.IdentificationNumber, student.FirstName, student.LastName, student.Class.GetClassName());
			}
		}

		//----------------------------- GetClassStudents -----------------------------

		/// <summary>
		/// Prints out all students attending a class based on selection
		/// </summary>
		public void GetClassStudents()
		{
			Console.WriteLine("Show students from which classroom?(Index, 0 to cancel)");

			GetClassrooms();

			index = Int16.Parse(Console.ReadLine());

			if (index == 0) return;

			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("{0,-20}{1,-20}{2,-20}", "ID", "First name", "Last name");
			Console.ForegroundColor = ConsoleColor.Gray;

			foreach (Student student in Students)
			{
				if (student.Class == Classrooms[index - 1])
					Console.WriteLine("{0,-20}{1,-20}{2,-20}", student.IdentificationNumber, student.FirstName, student.LastName);
			}
		}

	}
}