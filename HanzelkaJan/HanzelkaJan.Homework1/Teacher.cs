using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanzelkaJan.Homework1
{
	class Teacher
	{

		//Fields

		public string FirstName;

		public string LastName;

		public Classroom Class;

		public List<Subject> Subjects = new List<Subject>(10);

		//Methods

		public void SetClass(Classroom classroom)                //Sets teacher's class
		{
			Class = classroom;
			classroom.Teacher = this;
		}


		public void AddSubject(Subject subject)              //Adds a subject to teacher's teaching list and
		{                                                   //simultaneously adds teacher to subject's list of teachers
			Subjects.Add(subject);
			if (!subject.Teachers.Contains(this))
			{
				subject.AddTeacher(this);
			}
		}


		public string GetTeacherName()                  //Returns teacher's first and last name
		{
			string name = "";

			name += FirstName + " " + LastName;

			return name;
		}
	}
}
