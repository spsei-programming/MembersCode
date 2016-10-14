using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRoomHomework.ProgramClasses
{
	public class ClassRoom
	{
		public string name;
		public int classLevel;

		public Teacher teacher;
		public List<Student> students;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="classRoomName">name of the classroom (examle: "I1C")</param>
		/// <param name="classLevel">level of the class, 1 - 4</param>
		/// <param name="teacherName">name of the teacher</param>
		/// <param name="amountOfStudents">amount of students in the classrooms</param>
		public ClassRoom(string classRoomName, int classLevel, string teacherName, int amountOfStudents)
		{
			this.name = classRoomName;
			this.classLevel = classLevel;

			// init teacher
			teacher = new Teacher(Program.teachers + 1, teacherName, 30);
			Program.teachers++;

			// init students

			// - getting age by class level
			int tmpAge;
			switch (classLevel)
			{
				case 1:
					tmpAge = 16;
					break;
				case 2:
					tmpAge = 17;
					break;
				case 3:
					tmpAge = 18;
					break;
				case 4:
					tmpAge = 19;
					break;
				default:
					tmpAge = 0;
					break;
			}
			students = new List<Student>(30);
			for (int i = 0; i <= amountOfStudents; i++)
			{
				students.Add(new Student(i, "Jmeno_Student", tmpAge));
			}

			Console.WriteLine("ClassRoom created ...");
		}

		public void PrintClass()
		{
			Console.Write("vypisuji tridu {0} \nStudenti: \n", name);
			foreach (Student student in students)
			{
				Console.WriteLine($"id: { student.id }, name: { student.name }, age: { student.age }, gender: { student.gender }.");
			}

			Console.WriteLine($"With teacher { teacher }");
		}

		public void Validate()
		{
			if (classLevel > 4)
			{
				Program.classRooms.Remove(this);
				Console.WriteLine($"Classroom { name } has been deleted due to its invalid class level. only (1 to 4)");
			}
		}
	}
}
