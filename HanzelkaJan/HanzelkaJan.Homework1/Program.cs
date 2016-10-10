using System;
using System.Collections.Generic;
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

			//Declarations

			Program Program = new Program();

			Classroom class1 = new Classroom();
			Classroom class2 = new Classroom();
			Classroom class3 = new Classroom();

			Teacher Sladek = new Teacher();
			Teacher Hrabal = new Teacher();
			Teacher Trnka = new Teacher();

			Student Placka = new Student();
			Student Hryzal = new Student();
			Student Drozd = new Student();

			Subject Physics = new Subject();
			Subject Mathematics = new Subject();
			Subject Programming = new Subject();
			Subject Networking = new Subject();

			//Class initiation

			Program.InitiateClass(class1, Classroom.Orientations.Informatici, 2, Classroom.Groups.C);
			Program.InitiateClass(class1, Classroom.Orientations.Informatici, 2, Classroom.Groups.A);
			Program.InitiateClass(class1, Classroom.Orientations.Elektro, 2, Classroom.Groups.B);

			//Teacher initiation

			Sladek.FirstName = "Martin";
			Sladek.LastName = "Sladek";
			Sladek.SetClass(class1);
			Sladek.AddSubject(Programming);

			Hrabal.FirstName = "Marek";
			Hrabal.LastName = "Hrabal";
			Hrabal.SetClass(class2);
			Hrabal.AddSubject(Physics);
			Hrabal.AddSubject(Mathematics);

			Trnka.FirstName = "Daniel";
			Trnka.LastName = "Trnka";
			Trnka.SetClass(class3);
			Trnka.AddSubject(Programming);
			Trnka.AddSubject(Networking);

			//Student initiation

			Placka.FirstName = "Petr";
			Placka.LastName = "Placka";
			Placka.FavSubject = Networking;
			Placka.SetClass(class1);

			Hryzal.FirstName = "Pavel";
			Hryzal.LastName = "Hryzal";
			Hryzal.FavSubject = Physics;
			Hryzal.SetClass(class1);

			Drozd.FirstName = "Karel";
			Drozd.LastName = "Drozd";
			Drozd.FavSubject = Programming;
			Drozd.SetClass(class2);

			//Random printing test

			Console.WriteLine($"{Placka.GetStudentName()}'s favourite subject is {Placka.FavSubject.Name}, he's from {Placka.Class.GetClassName()}\n");
			Console.WriteLine($"{Placka.Class.Teacher.GetTeacherName()} is {Placka.Class.GetClassName()}'s teacher\n");
			Console.WriteLine($"{Placka.FavSubject.Name} is taught by these teachers:");

			foreach (Teacher teacher in Placka.FavSubject.Teachers)
			{
				Console.WriteLine($"\t{teacher.GetTeacherName()}");
			}

			Console.WriteLine();

			Console.WriteLine($"A total of {class1.Students.Count} people attend {class1.GetClassName()}, these are:");

			foreach (Student student in class1.Students)
			{
				Console.WriteLine($"\t{student.GetStudentName()}");
			}

			Console.WriteLine($"{Programming.Name} is taught by a total of {Programming.Teachers.Count} teachers, these are:");

			foreach (Teacher teacher in Programming.Teachers)
			{
				Console.WriteLine($"\t{teacher.GetTeacherName()}");
			}




			Console.ReadKey();

		}
	}
}