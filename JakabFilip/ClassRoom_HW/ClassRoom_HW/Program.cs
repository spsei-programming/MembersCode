using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRoom_HW
{
	class Program
    {
        static void Main(string[] args)
        {
			// List prepared for 6 classes
			List<ClassRoom> clssrms = new List<ClassRoom>(6);

			clssrms.Add(new ClassRoom("I1C"));
			clssrms.Add(new ClassRoom("E1C"));
			clssrms.Add(new ClassRoom("I2C"));
			clssrms.Add(new ClassRoom("E2C"));

			// init classroom
			clssrms[0].GenerateEntities("Igor Hnizdo", 15); // I1C
			clssrms[1].GenerateEntities("Ivan Skritek", 15); // E1C
			clssrms[2].GenerateEntities("Adam Nedockal", 16); // I2C
			clssrms[3].GenerateEntities("Leos Pospisil", 16); // E2C

			// printing classrooms
			foreach(ClassRoom CR in clssrms)
			{
				Console.WriteLine($"students in classroom -> { CR.ID }");
				Console.WriteLine("ID \t Name \t\t Age \t ID \t Name \t\t Age");
				Console.WriteLine("------------------------------------------------------------\t||");
				for (int i = 0; i < 20; i++)
				{
					Console.Write($" { CR.students[i].ID }.\t { CR.students[i].Name },\t { CR.students[i].Age } \t");
					Console.Write($" { CR.students[i + 10].ID}.\t { CR.students[i + 10].Name },\t { CR.students[i + 10].Age } \t|| \n");
				}
				Console.WriteLine($"with teacher { CR.tchr.Name }.\t\t\t\t\t||");
				Console.WriteLine("-------------------------------------------------------\t\t||");
			}

			Console.ReadKey();
        }
    }

    public class Man
    {
        public int Age;
		public int ID;
        public string Name;
        public enum Gender { Male, Female };

		public Gender Gndr;
	}

	public class ClassRoom
	{
		public string ID;
		public List<Student> students;
		public Teacher tchr;

		public ClassRoom(string ID)
		{
			this.ID = ID;

			students = new List<Student>(31);
		}

		public void GenerateEntities(string TchrName, int StdAge)
		{
			for (int i = 0; i < 30; i++)
			{
				students.Add(new Student("Adam Novak", i + 1, StdAge, Man.Gender.Male, "PRG"));
			}

			tchr = new Teacher(TchrName, 0, 46, "Math", Man.Gender.Male);
		}
	}

	public class Teacher : Man
    {
		public bool IsTeaching;
		public string Subject;

        public Teacher(string N, int D, int A, string Sbj, Gender G)
        {
			this.Name = N;
			this.ID = D;
			this.Age = A;
			this.Subject = Sbj;
			this.Gndr = G;

			IsTeaching = false;
        }
		
		public void StartLesson(string ClassRoom)
		{
			if (IsTeaching == false) // TODO: najit tridu "ClassRoom" ("I2C") a nastavit studenty AtLsson = true pokud mozno
			{
				IsTeaching = true;
				Console.WriteLine($"Teacher { this.Name } has started Lesson({ this.Subject }) at \"{ ClassRoom }\". ");
			}
			else
			{
				Console.WriteLine($"Teacher { this.Name }, is already teaching \"{ ClassRoom }\".");
			}
		}

		public void SetHW(string ToClass) // TODO: zada ukol urcite tride
		{

		}
    }

    public class Student : Man
    {
		public int Absent;
		public bool Snack;
		public bool AtLesson;
		public bool HasHW;
		public string FavSub;

        public Student(string N, int D, int A, Gender G, string FS)
        {
			this.Name = N;
			this.ID = D;
			this.Age = A;
			this.Gndr = G;
			this.FavSub = FS;

			Absent = 0;
			Snack = true;
			AtLesson = false;
			HasHW = false;
        }

		public void JoinLesson(string Lssn, string Sbj)
		{
			if (AtLesson == false)
			{
				AtLesson = true;
				Console.WriteLine($"Student { this.Name } has joinded lesson({ Sbj })");
			}
			else
			{
				Console.WriteLine($"Student { this.Name } is already in Lesson({ Sbj }).");
			}
		}

		public void LeaveLesson()
		{
			if (AtLesson == true)
			{
				AtLesson = false;
				Console.WriteLine($"Student { this.Name } has left lesson.");
			}
			else
			{
				Console.WriteLine($"Student { this.Name } isnt in the lesson, at the moment.");
			}
		}
    }
}
