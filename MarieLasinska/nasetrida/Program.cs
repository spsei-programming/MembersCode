using System;

namespace nasetrida
{
	internal class Program
	{
		string StudentFirstName;
		string StudentSurname;
		int StudentAge;

		private static void Main(string[] args)
		{
			int selektor;


			//subjects
			var czech = new Subject();
			czech.Name = Name.Czech;

			var math = new Subject();
			math.Name = Name.Math;

			var history = new Subject();
			history.Name = Name.History;

			var english = new Subject();
			english.Name = Name.English;

			var chemistry = new Subject();
			chemistry.Name = Name.Chemistry;

			var physics = new Subject();
			physics.Name = Name.Physics;

			var gymnastics = new Subject();
			gymnastics.Name = Name.Gymnastics;

			var electrotechnics = new Subject();
			electrotechnics.Name = Name.Electrotechnics;

			var informatics = new Subject();
			informatics.Name = Name.Informatics;

			var graphicArts = new Subject();
			graphicArts.Name = Name.GraphicArts;

			var practice = new Subject();
			practice.Name = Name.Practice;

			var programming = new Subject();
			programming.Name = Name.Programming;

			var technicalDocumentation = new Subject();
			technicalDocumentation.Name = Name.TechnicalDocumentation;

			var computerNetworks = new Subject();
			computerNetworks.Name = Name.ComputerNetworks;

			var technicalComputerEquipment = new Subject();
			technicalComputerEquipment.Name = Name.TechnicalComputerEquipment;

			var database = new Subject();
			database.Name = Name.Database;

			//*****teachers*****
			//CSA
			var teacher1 = new Teacher();
			teacher1.FirstName = "Irena";
			teacher1.Surname = "Csaladiova";
			teacher1.Genders = Genders.Woman;
			teacher1.Special.Add(math);
			teacher1.Special.Add(chemistry);
			math.Educator = teacher1;
			chemistry.Educator = teacher1;

			//GIB
			var teacher2 = new Teacher();
			teacher2.FirstName = "Helena";
			teacher2.Surname = "Gibalova";
			teacher2.Genders = Genders.Woman;
			teacher2.Special.Add(czech);
			teacher2.Special.Add(history);
			czech.Educator = teacher2;
			history.Educator = teacher2;

			//MLE
			var teacher3 = new Teacher();
			teacher3.FirstName = "Lucie";
			teacher3.Surname = "Mlejnecka";
			teacher3.Genders = Genders.Woman;
			teacher3.Special.Add(physics);
			physics.Educator = teacher3;

			//CHA
			var teacher4 = new Teacher();
			teacher4.FirstName = "Jana";
			teacher4.Surname = "Charvatkova";
			teacher4.Genders = Genders.Woman;
			teacher4.Special.Add(database);
			database.Educator = teacher4;

			//LAC
			var teacher5 = new Teacher();
			teacher5.FirstName = "Martina";
			teacher5.Surname = "Lackova";
			teacher5.Genders = Genders.Woman;
			teacher5.Special.Add(electrotechnics);
			teacher5.Special.Add(technicalDocumentation);
			electrotechnics.Educator = teacher5;
			technicalDocumentation.Educator = teacher5;

			//MAR
			var teacher6 = new Teacher();
			teacher6.FirstName = "Renata";
			teacher6.Surname = "Martinakova";
			teacher6.Genders = Genders.Woman;
			teacher6.Special.Add(english);
			english.Educator = teacher6;

			//SKA
			var teacher7 = new Teacher();
			teacher7.FirstName = "Ladislav";
			teacher7.Surname = "Skapa";
			teacher7.Genders = Genders.Man;
			teacher7.Special.Add(technicalComputerEquipment);
			technicalComputerEquipment.Educator = teacher7;

			//MAK
			var teacher8 = new Teacher();
			teacher8.FirstName = "Boleslav";
			teacher8.Surname = "Martinik";
			teacher8.Genders = Genders.Man;
			teacher8.Special.Add(computerNetworks);
			computerNetworks.Educator = teacher8;

			//KAC
			var teacher9 = new Teacher();
			teacher9.FirstName = "Antonin";
			teacher9.Surname = "Kacerovsky";
			teacher9.Genders = Genders.Man;
			teacher9.Special.Add(informatics);
			informatics.Educator = teacher9;

			//students
			var student1 = new Student();
			student1.FirstName = "Robert";
			student1.Surname = "Klada";
			student1.Age = 15;
			student1.Genders = Genders.Man;
			student1.FavoriteSubject = gymnastics;

			var student2 = new Student();
			student2.FirstName = "Jakub";
			student2.Surname = "Holy";
			student2.Age = 16;
			student2.Genders = Genders.Man;
			student2.FavoriteSubject = programming;

			var student3 = new Student();
			student3.FirstName = "Dominik";
			student3.Surname = "Zacek";
			student3.Age = 17;
			student3.Genders = Genders.Man;
			student3.FavoriteSubject = czech;

			var student4 = new Student();
			student4.FirstName = "Scarlet";
			student4.Surname = "Stark";
			student4.Age = 17;
			student4.Genders = Genders.Woman;
			student4.FavoriteSubject = math;

			var student5 = new Student();
			student5.FirstName = "Pavel";
			student5.Surname = "Mica";
			student5.Age = 15;
			student5.Genders = Genders.Man;
			student5.FavoriteSubject = english;

			var student6 = new Student();
			student6.FirstName = "Petr";
			student6.Surname = "Novak";
			student6.Age = 16;
			student6.Genders = Genders.Man;
			student6.FavoriteSubject = practice;

			var student7 = new Student();
			student7.FirstName = "Lukas";
			student7.Surname = "Jan";
			student7.Age = 16;
			student7.Genders = Genders.Man;
			student7.FavoriteSubject = electrotechnics;

			var student8 = new Student();
			student8.FirstName = "Jana";
			student8.Surname = "Mila";
			student8.Age = 15;
			student8.Genders = Genders.Woman;
			student8.FavoriteSubject = technicalDocumentation;

			var student9 = new Student();
			student9.FirstName = "Dalibor";
			student9.Surname = "Bobek";
			student9.Age = 16;
			student9.Genders = Genders.Man;
			student9.FavoriteSubject = technicalComputerEquipment;

			var student10 = new Student();
			student10.FirstName = "Robin";
			student10.Surname = "Bedrunka";
			student10.Age = 17;
			student10.Genders = Genders.Man;
			student10.FavoriteSubject = history;

			//*****classes*****
			//CLASS 1
			var class1 = new Personclass();

			class1.Specialization = Specialization.Informatics;

			class1.Grade = 2;

			class1.Character = Character.C;

			class1.ClassTeacher = teacher5;

			class1.Students.Add(student1);
			class1.Students.Add(student2);
			class1.Students.Add(student3);
			class1.Students.Add(student4);
			class1.Students.Add(student5);
			class1.Students.Add(student6);
			class1.Students.Add(student7);
			class1.Students.Add(student8);
			class1.Students.Add(student9);
			class1.Students.Add(student10);

			class1.Subjects.Add(math);
			class1.Subjects.Add(czech);
			class1.Subjects.Add(history);
			class1.Subjects.Add(physics);
			class1.Subjects.Add(database);
			class1.Subjects.Add(electrotechnics);
			class1.Subjects.Add(english);
			class1.Subjects.Add(technicalComputerEquipment);
			class1.Subjects.Add(computerNetworks);
			class1.Subjects.Add(informatics);

			
			if (class1.Specialization == Specialization.Electrotechnics)
			{
			    Console.Write("E");
			}
			if (class1.Specialization == Specialization.Informatics)
			{
			    Console.Write("I");
			}

			Console.Write(class1.Grade);
			Console.Write(class1.Character);
			Console.Write($"\nTridni ucitel: {class1.ClassTeacher.FirstName} {class1.ClassTeacher.Surname}");
			Console.Write($"\n\nStudenti");
			foreach (Student studentzak in class1.Students)
			{
			    Console.WriteLine($"\n First name: {studentzak.FirstName}\n Last name: {studentzak.Surname} \n Gender: {studentzak.Genders} \n Age: {studentzak.Age}\n Favorite subject: {studentzak.FavoriteSubject.Name}\n");
			}

			Console.Write("\nPredmety:");
			foreach (Subject subjectpredmet in class1.Subjects)
			{
			    Console.WriteLine($"\n Subject: {subjectpredmet.Name} \n Teacher: {subjectpredmet.Educator.FirstName} {subjectpredmet.Educator.Surname}");
			}
			
			/*
			do
			{
				Console.WriteLine("1-Create student");
				Console.WriteLine("2-Create classroom");
				Console.WriteLine("3-Remove student");
				Console.WriteLine("4-Remove classroom");
				Console.WriteLine("5-List of all students in classroom");
				Console.WriteLine("6-List of all clasrooms");
				Console.WriteLine("7-List of all teachers");
				Console.WriteLine("8-List of all subjects in classroom\n");

				Console.WriteLine("Special:");
				Console.WriteLine("0-ends the program");
				Console.WriteLine("9-Clear console\n");

				Console.WriteLine("Select command:");
				selektor = Convert.ToInt16(Console.ReadLine());

				switch (selektor)
				{
					case 1:
						Console.WriteLine("Selected create student");
						

						break;

					case 2:
						Console.WriteLine("Selected create classroom");

						break;

					case 3:
						Console.WriteLine("Selected remove student");

						break;

					case 4:
						Console.WriteLine("Selected remove classroom");

						break;

					case 5:
						Console.WriteLine("Selected list of all students in classroom");

						break;

					case 6:
						Console.WriteLine("Selected list of all classrooms");

						break;

					case 7:
						Console.WriteLine("Selected list of all teachers");

						break;

					case 8:
						Console.WriteLine("Selected list of all subjects in classroom");

						break;

					case 9:
						Console.WriteLine("Selected ");

						break;

					default:
						if (selektor != 0)
						{
							Console.WriteLine("Invalid number, Try it again.");
						}
						break;
				}
				Console.WriteLine("\n-----------------------------------------------------------\n");
			} while (selektor != 0); */

			Console.WriteLine("Press any key to exit...");
			Console.ReadKey();
		}

		//---------------------funkce---------------------
		//---------------------Create Student-------------
		/*public void CreateStudent()
		{
			Console.WriteLine("Student First Name?");
			StudentFirstName = Console.ReadLine();

			Console.WriteLine("Student Surname?");
			StudentSurname = Console.ReadLine();

			Console.WriteLine("Student age?");
			StudentAge = Console.Read();

			Console.WriteLine(StudentAge);
		} */
	}
}