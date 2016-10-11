using System;
using System.Collections.Generic;

namespace ClassRoom_HW
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Subject> subjects = new List<Subject>(2);
            Subject math = new Subject("Mathematics", "MAT");
            Subject physics = new Subject("Physics", "FYZ");
            subjects.Add(math);
            subjects.Add(physics);

            List<Student> students = new List<Student>(30);
            Student am = new Student("Albert Moravec", 16, Person.Genders.Male, Student.Fields.InformationTechnologies, Student.Specializations.Programming, math);
            students.Add(am);

            Teacher teacher = new Teacher("Marie Kubickova", 0, Person.Genders.Female, subjects);
            Classroom classroom = new Classroom("C210");
            Class classobj = new Class("I2A", teacher, students, classroom);

            classobj.StartLesson(math);
            classobj.DumpInfo();
            am.LeaveLesson(); //should I access this object through classobj?
            classobj.DumpInfo();

            Console.ReadKey();
        }

        public class Class
        {
            public string Name;
            public Teacher Teacher; //this example expects only one teacher per class
            public List<Student> Students;
            public Classroom Classroom;

            public Class(string name, Teacher teacher, List<Student> students, Classroom classroom)
            {
                Name = name;
                Teacher = teacher;
                Students = students;
                Classroom = classroom;
            }

            public void DumpInfo()
            {
                Console.WriteLine($"Class: {Name}\nClass teacher: {Teacher.Name}\nClassroom: {Classroom.Id}");
                Console.WriteLine($"Students:\n");

                foreach (Student student in Students)
                {
                    Console.WriteLine($"Name: {student.Name}\n" +
                                      $"Age: {student.Age}\n" +
                                      $"Field: {student.Field}\n" +
                                      $"Specialization: {student.Specialization}\n" +
                                      $"Favourite subject: {student.FavouriteSubject.Name}");
                    if(student.IsInLesson) Console.WriteLine($"Is in lesson: {student.HasLesson.Name}");
                }
                Console.WriteLine("------------------------");

            }

            public void AddStudent(Student student)
            {
                Students.Add(student);
            }

            public void AssignTeacher(Teacher teacher)
            {
                Teacher = teacher;
            }

            public void StartLesson(Subject subject)
            {
                if (Teacher.IsTeaching || Classroom.IsUsed)
                    return;

                Teacher.IsTeaching = true;
                Classroom.IsUsed = true;
                foreach (Student student in Students)
                {
                    student.IsInLesson = true;
                    student.HasLesson = subject;
                }
            }

            public void EndLesson()
            {
                if (!Teacher.IsTeaching)
                    return;

                Teacher.IsTeaching = false;
                Classroom.IsUsed = false;
                foreach (Student student in Students)
                {
                    student.IsInLesson = false;
                    student.HasLesson = null;
                }
            }
        }
        
        public class Person
        {
            public enum Genders { Male, Female };

            public string Name;
            public int Age;
            public Genders Gender;

            public Person(string name, int age, Genders gender)
            {
                Name = name;
                Age = age;
                Gender = gender;
            }
        }

        public class Teacher : Person
        {
            public List<Subject> Subjects;
            public bool IsTeaching;

            public Teacher(string name, int age, Genders gender, List<Subject> subjects) : base(name, age, gender)
            {
                Subjects = subjects;
            }

            public void AddSubject(Subject subject)
            {
                Subjects.Add(subject);
            }
        }

        public class Student : Person
        {
            public enum Fields { InformationTechnologies, ElectricalEngineering};
            public enum Specializations { Programming, Networking, MicrocontrollerApplication, Electroenergetics };

            public Fields Field;
            public Specializations Specialization;
            public Subject FavouriteSubject;
            public bool IsInLesson; //possibly unecessary field as we can check against HasLesson (HasLesson != null (?))
            public Subject HasLesson;

            public Student(string name, int age, Genders gender, Fields field, Specializations spec, Subject favsub) : base(name, age, gender)
            {
                Field = field;
                Specialization = spec;
                FavouriteSubject = favsub;
            }

            public void LeaveLesson()
            {
                IsInLesson = false;
                HasLesson = null;
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
            public string Id;
            public bool IsUsed;

            public Classroom(string id)
            {
                Id = id;
            }
        }
    }
}
