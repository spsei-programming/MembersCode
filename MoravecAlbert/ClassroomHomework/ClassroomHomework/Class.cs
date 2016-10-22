using System;
using System.Collections.Generic;

namespace ClassroomHomework
{
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
				if (student.IsInLesson) Console.WriteLine($"Is in lesson: {student.HasLesson.Name}");
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
}