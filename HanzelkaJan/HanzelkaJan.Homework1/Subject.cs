using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanzelkaJan.Homework1
{
	class Subject
	{

		//Fields

		public enum Names { Mathematics, Programming, Networking, Physics };

		public Names Name;

		public List<Teacher> Teachers = new List<Teacher>(10);

		//Methods

		public void AddTeacher(Teacher teacher)                //Adds a teacher to subject's list of teachers
		{                                                   //and simultaneously adds subject to teacher's teaching list

			Teachers.Add(teacher);

			if (!teacher.Subjects.Contains(this))
			{
				teacher.AddSubject(this);
			}
		}
	}
}
