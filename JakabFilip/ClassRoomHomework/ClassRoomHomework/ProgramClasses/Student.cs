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

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id">just ID</param>
		/// <param name="name">name of the student (name+id)</param>
		/// <param name="age">age of the student</param>
		public Student(int id, string name, int age)
		{
			this.id = id;
			this.name = name + "_" + id;
			this.age = age;

			atLesson = false;
		}
	}
}
