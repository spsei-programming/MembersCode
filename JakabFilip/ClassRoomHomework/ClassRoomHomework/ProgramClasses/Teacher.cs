using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRoomHomework.ProgramClasses
{
	public class Teacher : Person
	{
		//public string subject;
		public string teachingClassName;
		public bool isTeaching;
		public Subject subject;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id">just ID</param>
		/// <param name="name">name of the teacher (name+id)</param>
		/// <param name="age">age of the teacher</param>
		/// <param name="subject">sets the main subject to a teacher</param>
		public Teacher(int id, string name, int age, Subject subject)
		{
			this.id = id;
			this.name = name + "_" + id;
			this.age = age;
			this.subject = subject;

			isTeaching = false;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="className">name of a class to start lesson with</param>
		public void StartLesson(string className)
		{
			if (!isTeaching)
			{
				ClassRoom classFound = Program.classRooms.FirstOrDefault(x => x.name == className);
				if (classFound != null)
				{
					classFound.students.ForEach(x => x.atLesson = true);
					teachingClassName = className;

					Console.WriteLine($"Teacher { name } has started lesson with { className }, all students has joined.");
				}
				else
				{
					Console.WriteLine($"Fatal error appeared. There is no class with name: { className }, teacher couldnt start lesson.");
				}
			}
			else
			{
				Console.WriteLine($"Teacher { name } is already teaching.");
			}
		}

		public void EndLesson()
		{
			if (isTeaching)
			{
				ClassRoom classFound = Program.classRooms.First(x => x.name == teachingClassName);
				classFound.students.ForEach(x => x.atLesson = false);

				teachingClassName = null;

				isTeaching = false;
				Console.WriteLine($"Teacher { name } has ended lesson with { teachingClassName }.");
			}
			else
			{
				Console.WriteLine($"Teacher { name } isnt teaching.");
			}
		}

		/// <summary>
		/// this will set homework to class(parameter)
		/// </summary>
		/// <param name="className">nam of a class, homework to b set</param>
		public void SetHomeWork(string className)
		{
			ClassRoom classFound = Program.classRooms.FirstOrDefault(x => x.name == className);
			if (classFound != null)
			{
				classFound.students.ForEach(x => x.hasHomework = true);
				Console.WriteLine("Homework has been set to all students.");
			}
			else
				Console.WriteLine("Class {0} couldnt be found. Teacher couldnt set HW.", className);

		}
	}
}
