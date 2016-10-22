using System;
using System.Collections.Generic;

namespace ClassroomHomework
{
	class Program
	{
		static void Main(string[] args)
		{
			Random rnd = new Random();
			Class data = GenerateData();

			int r = rnd.Next(data.Students.Count);

			data.StartLesson(data.Students[r].FavouriteSubject);
			data.DumpInfo();
			
			data.Students[r].LeaveLesson();
			data.DumpInfo();

			Console.ReadKey();
		}

		static Class GenerateData()
		{
			List<Subject> subjects = new List<Subject>(2);
			Subject math = new Subject("Mathematics", "MAT");
			Subject physics = new Subject("Physics", "FYZ");
			subjects.Add(math);
			subjects.Add(physics);

			List<Student> students = new List<Student>(30);
			Student am = new Student("Albert Moravec", 16, Person.Genders.Male, Student.Fields.InformationTechnologies,
				Student.Specializations.Programming, math);
			students.Add(am);

			Teacher teacher = new Teacher("Marie Kubickova", 0, Person.Genders.Female, subjects);

			Classroom classroom = new Classroom("C210");
			Class classobj = new Class("I2A", teacher, students, classroom);

			return classobj;
		}
	}
}
