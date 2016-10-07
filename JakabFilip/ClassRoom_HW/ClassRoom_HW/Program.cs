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
			List<Teacher> tchrs = new List<Teacher>(5);
			List<Student> students = new List<Student>(30);

			tchrs.Add(new Teacher(45, 176, 20, Man.Gender.Male, "ICT", "C210", "I2C", "Igor Novak", 0));
			for (int i = 0; i < 30; i++)
			{
				students.Add(new Student(i + 3, i + 160, Man.Gender.Male, "Adam Novak", "PRG", "PRG", "MATH", true, i + 1));
			}

			Console.WriteLine("Class has been generated.");
			foreach(Student stdnt in students)
			{
				Console.WriteLine($"{ stdnt.ID } Name: { stdnt.Name }, Age: { stdnt.Age }, Fav. Sbj: { stdnt.FavSubject }.");
			}

			Console.WriteLine("\nwith this teachers: ");
			foreach(Teacher tchr in tchrs)
			{
				Console.WriteLine($"{ tchr.ID } Name: { tchr.Name }, Age: { tchr.Age }.");
			}
			
			Console.ReadKey();
        }
    }

    public class Man
    {
        public int Age;
        public int Height;
        public string Name;
        public enum Gender { Male, Female };
    }

    public class Teacher : Man
    {
        public int LessonsCount;
		public int ID;
        public string MainSubject;
        public string Room;
        public string MainClass;
		public string TchingCR;
        public bool Teaching;

        public Gender Gndr;

        public Teacher(int A, int H, int lssns, Gender G, string MainSub, string R, string MainC, string N, int D)
        {
            this.Age = A;
            this.Height = H;
            this.LessonsCount = lssns;
            this.Gndr = G;
            this.MainSubject = MainSub;
            this.Room = R;
            this.MainClass = MainC;
            this.Name = N;
			this.ID = D;

            Teaching = false;
        }

        public void GoTeach(string ClassRoom)
        {
            if (Teaching == false)
            {
                Teaching = true;
                Console.WriteLine($"Teacher { Name } has started teaching at { ClassRoom }.");
				TchingCR = ClassRoom;
            }
            else
            {
                Console.WriteLine($"Teacher { Name } is currently teaching in { TchingCR }.");
            }
        }

		public void EndTeaching()
		{
			if (Teaching == true)
			{
				Console.WriteLine($"Teacher { Name } has stopped lesson in { TchingCR }.");
				TchingCR = null;
			}
			else
			{
				Console.WriteLine($"Teacher { Name } isnt teaching at the moment.");
			}
		}
    }

    public class Student : Man
    {
        public int HWToDo;
		public int ID;
        public string FavSubject;
        public string BadSubject;
        public string Hobby;
        public bool AtSchool;
		public bool Snack;
		public bool InLesson;

        public Gender Gndr;

        public Student(int A, int H, Gender G, string N, string Hbb, string FS, string BS, bool S, int D)
        {
            this.Age = A;
            this.Height = H;
            this.Gndr = G;
            this.Name = N;
            this.Hobby = Hbb;
            this.FavSubject = FS;
            this.BadSubject = BS;
			this.Snack = S;
			this.ID = D;

            AtSchool = false;
			InLesson = false;
            HWToDo = 0;
        }

        public void GoToSchool()
        {
            if (AtSchool == false)
            {
                Console.WriteLine($"Student { Name } is going to school.");
            }
            else
            {
                Console.WriteLine($"Student { Name } is already at school.");
            }
        }

        public void DoHW(int Amount)
        {
            if (HWToDo >= Amount)
            {
                Console.WriteLine($"Student { Name } has started ...");
                for (int i = 0; i < Amount; i++)
                {
                    System.Threading.Thread.Sleep(500);
                    Console.WriteLine($"{ i }. Student { Name } has done one HW.");
                }

		HWToDo -= Amount;
                Console.WriteLine($"Student { Name } has done requested amount({ Amount }) of HW");
            }
            else
            {
                Console.WriteLine($"Student { Name } nema tolik HW, udela tedy vsechny({ HWToDo }).");
            }
        }

		public void EatSnack()
		{
			if (Snack == true)
			{
				Console.WriteLine($"Student { Name } is eating snack.");
				Snack = false;
			}
			else
			{
				Console.WriteLine($"Student { Name } dont have any snack.");
			}
		}

		public void JoinLesson()
		{
			if (InLesson == false)
			{
				Console.WriteLine($"Student { Name } has joined lesson.");
				InLesson = true;
			}
			else
			{
				Console.WriteLine($"Student { Name } is currently in Lesson.");
			}
		}

		public void LeaveLesson()
		{
			if (InLesson == true)
			{
				Console.WriteLine($"Student { Name } has left lesson.");
				InLesson = false;
			}
			else
			{
				Console.WriteLine($"Studnet { Name } isnt currently in lesson.");
			}
		}
    }
}
