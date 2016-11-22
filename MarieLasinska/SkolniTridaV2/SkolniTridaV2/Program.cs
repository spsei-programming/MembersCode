using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SkolniTridaV2.Enum;

namespace SkolniTridaV2
{
	class Program
	{
		static List<SchoolClass> schoolClasses = new List<SchoolClass>(20);
		static List<Student> students = new List<Student>(50);
		static List<Teacher> teachers = new List<Teacher>(10);
		static List<Subject> subjects = new List<Subject>(20);


		static void Main(string[] args)
		{
			string selektor;
			int number;
			CreateDummyData();
			do

			{

				Console.WriteLine("1-Create student");

				Console.WriteLine("2-Create classroom");

				Console.WriteLine("3-Remove student");

				Console.WriteLine("4-Remove classroom");

				Console.WriteLine("5-List of all students in classroom");

				Console.WriteLine("6-List of all clasrooms");

				Console.WriteLine("7-List of all teachers");

				Console.WriteLine("8-List of all students");

				Console.WriteLine("Special:");

				Console.WriteLine("0-ends the program");

				Console.WriteLine("9-Clear console\n");

				do
				{
					Console.WriteLine("Select command:");

					selektor = Console.ReadLine();
					if (int.TryParse(selektor, out number))
					{
						break;
					}
					Console.ForegroundColor = ConsoleColor.Red;
					Console.Write("Please enter valid number between 0-9\n");
					Console.ForegroundColor = ConsoleColor.Gray;
				} while (true);
				




				if (number == 0)
				{
					break;
				}
				switch (number)
				{
					case 1:
						CreateStudent();
						break;

					case 2:
						CreateClassroom();
						break;

					case 3:
						RemoveStudent();
						break;

					case 4:
						RemoveClass();
						break;

					case 5:
						GetStudentsInClass();
						Console.WriteLine("\n\n");
						break;

					case 6:
						GetSchoolClasses();
						Console.WriteLine("\n\n");
						break;

					case 7:
						GetTeachers();
						Console.WriteLine("\n\n");
						break;

					case 8:
						GetStudents();
						Console.WriteLine("\n\n");
						break;

					case 9:
						Console.Clear();
						break;
				}

			} while (number != 0);
		}

		//*****funkce*****
		//-----CreateStudent-----
		public static void CreateStudent()
		{
			Console.WriteLine("Student class (Eg. I1A)?");
			GetSchoolClasses();

			string studentClass = Console.ReadLine();

			Console.WriteLine("Student first name?");
			String studentFirstName = Console.ReadLine();

			Console.WriteLine("Student surname?");
			String studentSurname = Console.ReadLine();

			Console.WriteLine("Student age?");
			int studentAge = Convert.ToInt32(Console.ReadLine());

			Console.WriteLine("Student Gender(M / F)?");
			char studentGender = Convert.ToChar(Console.ReadLine().ToUpper()[0]);

			Student student = new Student();

			if (studentGender == 'M')
			{
				student.Gender = Genders.Man;
			}
			if (studentGender == 'F')
			{
				student.Gender = Genders.Woman;
			}
			
			student.FirstName = studentFirstName;
			student.Surname = studentSurname;
			student.Age = studentAge;

			foreach (SchoolClass schoolClass in schoolClasses)
			{
				if (studentClass.Equals(schoolClass.Name, StringComparison.InvariantCultureIgnoreCase))
				{
					schoolClass.Students.Add(student);
				}

			}

			students.Add(student);

		}
		//-----CreateClass-----
		public static void CreateClassroom()
		{
			Console.WriteLine("Jmeno tridy? Eg. I1A");
			string className = Console.ReadLine();
			Console.WriteLine("Class teacher? Eg. CSA");
			GetTeachers();
			string classTeacher = Console.ReadLine();
			SchoolClass schoolClass = new SchoolClass();
			schoolClass.Name = className;
			switch (className[0])
			{
				case 'I':
					schoolClass.Specialization = Specializations.Informatics;
					break;

				case 'E':
					schoolClass.Specialization = Specializations.Electrotechnics;
					break;
			}
			schoolClass.Grade = Convert.ToInt32(className[1].ToString());
			switch (className[2])
			{
				case 'A':
					schoolClass.Letter = Letters.A;
					break;

				case 'B':
					schoolClass.Letter = Letters.B;
					break;

				case 'C':
					schoolClass.Letter = Letters.C;
					break;
			}
			foreach (Teacher teacher in teachers)
			{
				if (classTeacher == teacher.Indication)
				{
					schoolClass.ClassTeacher = teacher;
				}
			}
			schoolClasses.Add(schoolClass);
		}

		//-----RemoveStudent-----
		public static void RemoveStudent()
		{
			Console.WriteLine("Which student? Eg. Klada");
			GetStudents();
			string whichStudent = Console.ReadLine();

			Student toremove = null;
			foreach (Student student in students)
			{
				if (whichStudent == student.Surname)
				{
					students.Remove(student);
					//toremove = student;
				}
			}
			foreach (SchoolClass schoolClass in schoolClasses)
			{
				schoolClass.Students.Remove(toremove);
			}
		
			students.Remove(toremove);
			
		}

		//-----RemoveClass
		public static void RemoveClass()
		{
			Console.WriteLine("Which class? Eg. I2C");
			GetSchoolClasses();
			string whichClass = Console.ReadLine();

			SchoolClass toremove = null;
			foreach (SchoolClass schoolClass in schoolClasses)
			{
				if (whichClass == schoolClass.Name)
				{
					toremove = schoolClass;
				}
			}
			schoolClasses.Remove(toremove);
		}
		//-----GetSchoolClasses-----
		public static void GetSchoolClasses()
		{
			
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("Class Name \t Specialization \t Grade \t Letter \t Class Teacher");
			Console.ForegroundColor = ConsoleColor.Gray;
			foreach (SchoolClass personClass in schoolClasses)
			{
				if (personClass.Specialization == Specializations.Electrotechnics)
				{
					Console.Write("E");
				}
				if (personClass.Specialization == Specializations.Informatics)
				{
					Console.Write("I");
				}

				Console.Write(personClass.Grade);
				Console.Write(personClass.Letter);
				Console.Write("       \t ");
				Console.Write(personClass.Specialization);
				if (personClass.Specialization == Specializations.Informatics)
				{
					Console.Write("\t\t ");
				}
				if (personClass.Specialization == Specializations.Electrotechnics)
				{
					Console.Write("\t ");
				}
				Console.Write(personClass.Grade);
				Console.Write("\t ");
				Console.Write(personClass.Letter);
				Console.Write("\t\t ");
				Console.Write(personClass.ClassTeacher!=null?personClass.ClassTeacher.FirstName:"without teacher");
				Console.Write(" ");
				Console.Write(personClass.ClassTeacher != null ? personClass.ClassTeacher.Surname : "");
				Console.Write("\n");
			}
		}
		
		
		//GetTeachers
		public static void GetTeachers()
		{
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("Indication \t First Name and Surname");
			Console.ForegroundColor = ConsoleColor.Gray;
			foreach (Teacher teacher in teachers)
			{
				Console.Write(teacher.Indication);
				Console.Write("\t\t ");
				Console.Write(teacher.FirstName);
				Console.Write(" ");
				Console.WriteLine(teacher.Surname);
			}
		}

		//GetStudentsInClass
		public static void GetStudentsInClass()
		{
			Console.WriteLine("Choose class. Eg. I1A");
			GetSchoolClasses();
			string chooseClass = Console.ReadLine();
			foreach (SchoolClass schoolClass in schoolClasses)
			{
				if (chooseClass == schoolClass.Name)
				{
					Console.ForegroundColor = ConsoleColor.Cyan;
					Console.Write("Age\tFirst name and Surname \n");
					Console.ForegroundColor = ConsoleColor.Gray;
					foreach (Student student in schoolClass.Students)
					{
						Console.Write(student.Age);
						Console.Write("\t");
						Console.Write(student.FirstName);
						Console.Write(" ");
						Console.WriteLine(student.Surname);
					}
				}
			}

		}
		//GetStudents
		public static void GetStudents()
		{
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("Age\tFirst name and Surname ");
			Console.ForegroundColor = ConsoleColor.Gray;
			foreach (Student student in students)
			{
				Console.Write(student.Age);
				Console.Write("\t");
				Console.Write(student.FirstName);
				Console.Write(" ");
				Console.WriteLine(student.Surname);
			}
		}
		//CreateDummy
		public static void CreateDummyData()
		{
			//*****subjects*****
			Subject czech = new Subject();
			czech.SubjectName = SubjectNames.Czech;
			subjects.Add(czech);

			Subject math = new Subject();
			math.SubjectName = SubjectNames.Math;
			subjects.Add(math);

			Subject history = new Subject();
			history.SubjectName = SubjectNames.History;
			subjects.Add(history);

			Subject english = new Subject();
			english.SubjectName = SubjectNames.English;
			subjects.Add(english);

			Subject chemistry = new Subject();
			chemistry.SubjectName = SubjectNames.Chemistry;
			subjects.Add(chemistry);

			Subject physics = new Subject();
			physics.SubjectName = SubjectNames.Physics;
			subjects.Add(physics);

			Subject gymnastics = new Subject();
			gymnastics.SubjectName = SubjectNames.Gymnastics;
			subjects.Add(gymnastics);

			Subject electrotechnics = new Subject();
			electrotechnics.SubjectName = SubjectNames.Electrotechnics;
			subjects.Add(electrotechnics);

			Subject informatics = new Subject();
			informatics.SubjectName = SubjectNames.Informatics;
			subjects.Add(informatics);

			Subject graphicArts = new Subject();
			graphicArts.SubjectName = SubjectNames.GraphicArts;
			subjects.Add(graphicArts);

			Subject practice = new Subject();
			practice.SubjectName = SubjectNames.Practice;
			subjects.Add(practice);

			Subject programming = new Subject();
			programming.SubjectName = SubjectNames.Programming;
			subjects.Add(programming);

			Subject technicalDocumentation = new Subject();
			technicalDocumentation.SubjectName = SubjectNames.TechnicalDocumentation;
			subjects.Add(technicalDocumentation);

			Subject computerNetworks = new Subject();
			computerNetworks.SubjectName = SubjectNames.ComputerNetworks;
			subjects.Add(computerNetworks);

			Subject technicalComputerEquipment = new Subject();
			technicalComputerEquipment.SubjectName = SubjectNames.TechnicalComputerEquipment;
			subjects.Add(technicalComputerEquipment);

			Subject database = new Subject();
			database.SubjectName = SubjectNames.Database;
			subjects.Add(database);


			//*****teachers*****
			//CSA
			Teacher csaladiova = new Teacher();
			csaladiova.FirstName = "Irena";
			csaladiova.Surname = "Csaladiova";
			csaladiova.Gender = Genders.Woman;
			csaladiova.Special.Add(math);
			csaladiova.Special.Add(chemistry);
			math.Educator.Add(csaladiova);
			chemistry.Educator.Add(csaladiova);

			csaladiova.Indication = "CSA";
			teachers.Add(csaladiova);

			//GIB
			Teacher gibalova = new Teacher();
			gibalova.FirstName = "Helena";
			gibalova.Surname = "Gibalova";
			gibalova.Gender = Genders.Woman;
			gibalova.Special.Add(czech);
			gibalova.Special.Add(history);
			czech.Educator.Add(gibalova);
			history.Educator.Add(gibalova);

			gibalova.Indication = "GIB";
			teachers.Add(gibalova);

			//MLE
			Teacher mlejnecka = new Teacher();
			mlejnecka.FirstName = "Lucie";
			mlejnecka.Surname = "Mlejnecka";
			mlejnecka.Gender = Genders.Woman;
			mlejnecka.Special.Add(physics);
			physics.Educator.Add(mlejnecka);

			mlejnecka.Indication = "MLE";
			teachers.Add(mlejnecka);

			//CHA
			Teacher charvatkova = new Teacher();
			charvatkova.FirstName = "Jana";
			charvatkova.Surname = "Charvatkova";
			charvatkova.Gender = Genders.Woman;
			charvatkova.Special.Add(database);
			database.Educator.Add(charvatkova);

			charvatkova.Indication = "CHA";
			teachers.Add(charvatkova);

			//LAC
			Teacher lackova = new Teacher();
			lackova.FirstName = "Martina";
			lackova.Surname = "Lackova";
			lackova.Gender = Genders.Woman;
			lackova.Special.Add(electrotechnics);
			lackova.Special.Add(technicalDocumentation);
			electrotechnics.Educator.Add(lackova);
			technicalDocumentation.Educator.Add(lackova);

			lackova.Indication = "LAC";
			teachers.Add(lackova);

			//MAR
			Teacher martinakova = new Teacher();
			martinakova.FirstName = "Renata";
			martinakova.Surname = "Martinakova";
			martinakova.Gender = Genders.Woman;
			martinakova.Special.Add(english);
			english.Educator.Add(martinakova);

			martinakova.Indication = "MAR";
			teachers.Add(martinakova);

			//SKA
			Teacher kappa = new Teacher();
			kappa.FirstName = "Ladislav";
			kappa.Surname = "Skapa";
			kappa.Gender = Genders.Man;
			kappa.Special.Add(technicalComputerEquipment);
			technicalComputerEquipment.Educator.Add(kappa);

			kappa.Indication = "SKA";
			teachers.Add(kappa);

			//MAK
			Teacher martinik = new Teacher();
			martinik.FirstName = "Boleslav";
			martinik.Surname = "Martinik";
			martinik.Gender = Genders.Man;
			martinik.Special.Add(computerNetworks);
			computerNetworks.Educator.Add(martinik);

			martinik.Indication = "MAK";
			teachers.Add(martinik);

			//KAC
			Teacher kacerovsky = new Teacher();
			kacerovsky.FirstName = "Antonin";
			kacerovsky.Surname = "Kacerovsky";
			kacerovsky.Gender = Genders.Man;
			kacerovsky.Special.Add(informatics);
			informatics.Educator.Add(kacerovsky);

			kacerovsky.Indication = "KAC";
			teachers.Add(kacerovsky);

			//*****students*****
			Student klada = new Student();
			klada.FirstName = "Robert";
			klada.Surname = "Klada";
			klada.Age = 15;
			klada.Gender = Genders.Man;
			students.Add(klada);

			Student holy = new Student();
			holy.FirstName = "Jakub";
			holy.Surname = "Holy";
			holy.Age = 16;
			holy.Gender = Genders.Man;
			students.Add(holy
				);
			Student zacek = new Student();
			zacek.FirstName = "Dominik";
			zacek.Surname = "Zacek";
			zacek.Age = 17;
			zacek.Gender = Genders.Man;
			students.Add(zacek);

			Student stark = new Student();
			stark.FirstName = "Scarlet";
			stark.Surname = "Stark";
			stark.Age = 17;
			stark.Gender = Genders.Woman;
			students.Add(stark);

			Student mica = new Student();
			mica.FirstName = "Pavel";
			mica.Surname = "Mica";
			mica.Age = 15;
			mica.Gender = Genders.Man;
			students.Add(mica);

			Student novak = new Student();
			novak.FirstName = "Petr";
			novak.Surname = "Novak";
			novak.Age = 16;
			novak.Gender = Genders.Man;
			students.Add(novak);

			Student jan = new Student();
			jan.FirstName = "Lukas";
			jan.Surname = "Jan";
			jan.Age = 16;
			jan.Gender = Genders.Man;
			students.Add(jan);

			Student mila = new Student();
			mila.FirstName = "Jana";
			mila.Surname = "Mila";
			mila.Age = 15;
			mila.Gender = Genders.Woman;
			students.Add(mila);

			Student bobek = new Student();
			bobek.FirstName = "Dalibor";
			bobek.Surname = "Bobek";
			bobek.Age = 16;
			bobek.Gender = Genders.Man;
			students.Add(bobek);

			Student bedrunka = new Student();
			bedrunka.FirstName = "Robin";
			bedrunka.Surname = "Bedrunka";
			bedrunka.Age = 17;
			bedrunka.Gender = Genders.Man;
			students.Add(bedrunka);

			//*****Classes*****
			//I2C
			SchoolClass i2C = new SchoolClass();
			i2C.Specialization = Specializations.Informatics;
			i2C.Grade = 2;
			i2C.Letter = Letters.C;
			i2C.ClassTeacher = lackova;
			i2C.Name = "I2C";

			i2C.Students.Add(bedrunka);
			i2C.Students.Add(bobek);
			i2C.Students.Add(stark);
			i2C.Students.Add(mica);
			i2C.Students.Add(mila);
			i2C.Students.Add(jan);
			i2C.Students.Add(holy);
			i2C.Students.Add(zacek);
			i2C.Students.Add(novak);
			i2C.Students.Add(klada);

			i2C.Subjects.Add(math);
			i2C.Subjects.Add(czech);
			i2C.Subjects.Add(history);
			i2C.Subjects.Add(physics);
			i2C.Subjects.Add(database);
			i2C.Subjects.Add(electrotechnics);
			i2C.Subjects.Add(english);
			i2C.Subjects.Add(technicalComputerEquipment);
			i2C.Subjects.Add(computerNetworks);
			i2C.Subjects.Add(informatics);

			schoolClasses.Add(i2C);

		}
	}
}
