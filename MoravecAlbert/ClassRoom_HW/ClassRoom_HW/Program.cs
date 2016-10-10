using System;
using System.Collections.Generic;

namespace ClassRoom_HW
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Subject> subjects = new List<Subject>(2);
            subjects.Add(new Subject("Mathematics", "MAT")); // How to save all the subjects so I can reuse them instead of instantiating the same ones every time...
            subjects.Add(new Subject("Physics", "FYZ"));

            Teacher teacher = new Teacher("Marie Kubickova", 0, Person.Sex.Female, subjects);

            List<Student> students = new List<Student>(30);
            students.Add(new Student("Albert Moravec", 16, Person.Sex.Male, Student.Fields.InformationTechnologies, Student.Specializations.Programming, new Subject("Mathematics", "MAT"))); // ...as I do here

            Classroom classroom = new Classroom("C210");

            Class classobj = new Class("I2A", teacher, students, classroom);

            Console.WriteLine($"Teacher is {classobj.Teacher.Name} and classroom is {classobj.Classroom.ID}.");
            Console.Write($"Student {classobj.Students[0].Name} is ");
            if (!classobj.Students[0].IsAtLesson) Console.Write("not");
            Console.WriteLine(" in a lesson.");
            Console.ReadKey();
        }

        public class Class
        {
            public string Name;
            public Teacher Teacher;
            public List<Student> Students;
            public Classroom Classroom;

            public Class(string name, Teacher teacher, List<Student> students, Classroom classroom)
            {
                Name = name;
                Teacher = teacher;
                Students = students;
                Classroom = classroom;
            }

            public void StartLesson()
            {
                Teacher.IsTeaching = true;
                foreach (var student in Students)
                {
                    student.IsAtLesson = true;
                }
                Classroom.IsUsed = true;
            }
        }
        
        public class Person
        {
            public enum Sex { Male, Female };

            public string Name;
            public int Age;
            public Sex Gender;

            public Person(string name, int age, Sex gender)
            {
                Name = name;
                Age = age;
                Gender = gender;
            }
        }

        public class Teacher : Person
        {
            public List<Subject> Subjects;
            public bool IsTeaching = false;

            public Teacher(string name, int age, Sex gender, List<Subject> subjects) : base(name, age, gender)
            {
                Subjects = subjects;
            }
        }

        public class Student : Person
        {
            public enum Fields { InformationTechnologies, ElectricalEngineering};
            public enum Specializations { Programming, Networking, MicrocontrollerApplication, Electroenergetics };

            public Fields Field;
            public Specializations Specialization;
            public Subject FavouriteSubject;
            public bool IsAtLesson = false;

            public Student(string name, int age, Sex gender, Fields field, Specializations spec, Subject favsub) : base(name, age, gender)
            {
                Field = field;
                Specialization = spec;
                FavouriteSubject = favsub;
            }
        }

        public class Subject
        {
            public string Name;
            public string ShortName;

            public Subject(string name, string shortname)
            {
                Name = name;
                ShortName = shortname;
            }
        }

        public class Classroom
        {
            public string ID;
            public bool IsUsed = false;

            public Classroom(string id)
            {
                ID = id;
            }
        }
    }
}
