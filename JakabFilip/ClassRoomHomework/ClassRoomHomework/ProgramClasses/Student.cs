using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRoomHomework.ProgramClasses
{
	public class Student : Person
	{
		public bool atLesson;
		public bool hasHomework;
		public Subject favSubject;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id">just ID</param>
		/// <param name="name">name of the student (name+id)</param>
		/// <param name="age">age of the student</param>
		/// <param name="favSubject">sets the favorite e</param>
		public Student(int id, string name, int age, Subject favSubject)
		{
			this.id = id;
			this.name = name + "_" + id;
			this.age = age;
			this.favSubject = favSubject;

			atLesson = false;
			hasHomework = false;
		}

		/// <summary>
		/// if student has Homework, he will do that
		/// </summary>
		public void DoSomeHomework()
		{
			if (hasHomework)
			{
				hasHomework = false;
				Console.WriteLine("homework has been done.");
			}
			else
			{
				Console.WriteLine("Student has no homework.");
			}
		}
	}
}
