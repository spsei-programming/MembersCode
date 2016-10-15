using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nasetrida
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //subjects
            Subject czech = new Subject();
            czech.Type = Subject.Name.Czech;

            Subject math = new Subject();
            math.Type = Subject.Name.Math;

            Subject history = new Subject();
            history.Type = Subject.Name.History;

            Subject english = new Subject();
            english.Type = Subject.Name.English;

            Subject chemistry = new Subject();
            chemistry.Type = Subject.Name.Chemistry;

            Subject physics = new Subject();
            physics.Type = Subject.Name.Physics;

            Subject gymnastics = new Subject();
            gymnastics.Type = Subject.Name.Gymnastics;

            Subject electrotechnics = new Subject();
            electrotechnics.Type = Subject.Name.Electrotechnics;

            Subject informatics = new Subject();
            informatics.Type = Subject.Name.Informatics;

            Subject graphicArts = new Subject();
            graphicArts.Type = Subject.Name.GraphicArts;

            Subject practice = new Subject();
            practice.Type = Subject.Name.Practice;

            Subject programming = new Subject();
            programming.Type = Subject.Name.Programming;

            Subject technicalDocumentation = new Subject();
            technicalDocumentation.Type = Subject.Name.TechnicalDocumentation;

            Subject computerNetworks = new Subject();
            computerNetworks.Type = Subject.Name.ComputerNetworks;

            Subject technicalComputerEquipment = new Subject();
            technicalComputerEquipment.Type = Subject.Name.TechnicalComputerEquipment;

            Subject database = new Subject();
            database.Type = Subject.Name.Database;

            //*****teachers*****
            //CSA
            teacher teacher1 = new teacher();
            teacher1.FirstName = "Irena";
            teacher1.Surname = "Csaladiova";
            teacher1.Gender = teacher.Genders.Woman;
            teacher1.Special.Add(math);
            teacher1.Special.Add(chemistry);
            math.Educator = teacher1;
            chemistry.Educator = teacher1;

            //GIB
            teacher teacher2 = new teacher();
            teacher2.FirstName = "Helena";
            teacher2.Surname = "Gibalova";
            teacher2.Gender = teacher.Genders.Woman;
            teacher2.Special.Add(czech);
            teacher2.Special.Add(history);
            czech.Educator = teacher2;
            history.Educator = teacher2;

            //MLE
            teacher teacher3 = new teacher();
            teacher3.FirstName = "Lucie";
            teacher3.Surname = "Mlejnecka";
            teacher3.Gender = teacher.Genders.Woman;
            teacher3.Special.Add(physics);
            physics.Educator = teacher3;

            //CHA
            teacher teacher4 = new teacher();
            teacher4.FirstName = "Jana";
            teacher4.Surname = "Charvatkova";
            teacher4.Gender = teacher.Genders.Woman;
            teacher4.Special.Add(database);
            database.Educator = teacher4;

            //LAC
            teacher teacher5 = new teacher();
            teacher5.FirstName = "Martina";
            teacher5.Surname = "Lackova";
            teacher5.Gender = teacher.Genders.Woman;
            teacher5.Special.Add(electrotechnics);
            teacher5.Special.Add(technicalDocumentation);
            electrotechnics.Educator = teacher5;
            technicalDocumentation.Educator = teacher5;

            //MAR
            teacher teacher6 = new teacher();
            teacher6.FirstName = "Renata";
            teacher6.Surname = "Martinakova";
            teacher6.Gender = teacher.Genders.Woman;
            teacher6.Special.Add(english);
            english.Educator = teacher6;

            //SKA
            teacher teacher7 = new teacher();
            teacher7.FirstName = "Ladislav";
            teacher7.Surname = "Skapa";
            teacher7.Gender = teacher.Genders.Man;
            teacher7.Special.Add(technicalComputerEquipment);
            technicalComputerEquipment.Educator = teacher7;

            //MAK
            teacher teacher8 = new teacher();
            teacher8.FirstName = "Boleslav";
            teacher8.Surname = "Martinik";
            teacher8.Gender = teacher.Genders.Man;
            teacher8.Special.Add(computerNetworks);
            computerNetworks.Educator = teacher8;

            //KAC
            teacher teacher9 = new teacher();
            teacher9.FirstName = "Antonin";
            teacher9.Surname = "Kacerovsky";
            teacher9.Gender = teacher.Genders.Man;
            teacher9.Special.Add(informatics);
            informatics.Educator = teacher9;

            //students
            student student1 = new student();
            student1.FirstName = "Robert";
            student1.Surname = "Klada";
            student1.Age = 15;
            student1.Gender = student.Genders.Man;
            student1.FavoriteSubject = gymnastics;

            student student2 = new student();
            student2.FirstName = "Jakub";
            student2.Surname = "Holy";
            student2.Age = 16;
            student2.Gender = student.Genders.Man;
            student2.FavoriteSubject = programming;

            student student3 = new student();
            student3.FirstName = "Dominik";
            student3.Surname = "Zacek";
            student3.Age = 17;
            student3.Gender = student.Genders.Man;
            student3.FavoriteSubject = czech;

            student student4 = new student();
            student4.FirstName = "Scarlet";
            student4.Surname = "Stark";
            student4.Age = 17;
            student4.Gender = student.Genders.Woman;
            student4.FavoriteSubject = math;

            student student5 = new student();
            student5.FirstName = "Pavel";
            student5.Surname = "Mica";
            student5.Age = 15;
            student5.Gender = student.Genders.Man;
            student5.FavoriteSubject = english;

            student student6 = new student();
            student6.FirstName = "Petr";
            student6.Surname = "Novak";
            student6.Age = 16;
            student6.Gender = student.Genders.Man;
            student6.FavoriteSubject = practice;

            student student7 = new student();
            student7.FirstName = "Lukas";
            student7.Surname = "Jan";
            student7.Age = 16;
            student7.Gender = student.Genders.Man;
            student7.FavoriteSubject = electrotechnics;

            student student8 = new student();
            student8.FirstName = "Jana";
            student8.Surname = "Mila";
            student8.Age = 15;
            student8.Gender = student.Genders.Woman;
            student8.FavoriteSubject = technicalDocumentation;

            student student9 = new student();
            student9.FirstName = "Dalibor";
            student9.Surname = "Bobek";
            student9.Age = 16;
            student9.Gender = student.Genders.Man;
            student9.FavoriteSubject = technicalComputerEquipment;

            student student10 = new student();
            student10.FirstName = "Robin";
            student10.Surname = "Bedrunka";
            student10.Age = 17;
            student10.Gender = student.Genders.Man;
            student10.FavoriteSubject = history;

            //*****classes*****
            //CLASS 1
            peopleclass class1 = new peopleclass();

            class1.Specialization = peopleclass.Specializations.Informatics;

            class1.Grade = 2;

            class1.Letter = peopleclass.Character.C;

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


            if (class1.Specialization == peopleclass.Specializations.Electrotechnics)
            {
                Console.Write("E");
            }
            if (class1.Specialization == peopleclass.Specializations.Informatics)
            {
                Console.Write("I");
            }

            Console.Write(class1.Grade);
            Console.Write(class1.Letter);
            Console.Write($"\nTridni ucitel: {class1.ClassTeacher.FirstName} {class1.ClassTeacher.Surname}");
            Console.Write($"\n\nStudenti");
            foreach (student studentzak in class1.Students)
            {
                Console.WriteLine($"\n First name: {studentzak.FirstName}\n Last name: {studentzak.Surname} \n Gender: {studentzak.Gender} \n Age: {studentzak.Age}\n Favorite subject: {studentzak.FavoriteSubject.Type}\n");
            }

            Console.Write("\nPredmety:");
            foreach (Subject subjectpredmet in class1.Subjects)
            {
                Console.WriteLine($"\n Subject: {subjectpredmet.Type} \n Teacher: {subjectpredmet.Educator.FirstName} {subjectpredmet.Educator.Surname}");
            }
            Console.ReadKey();
        }
    }
}
