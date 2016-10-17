using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanzelkaJan.Homework1
{
	class Student
	{

		//Fields

		public int IdentificationNumber;

		public string FirstName;

		public string LastName;

		public Classroom Class;

		public Subject FavSubject;

		//Methods

		public void SetClass(Classroom classroom)            //Sets student's classroom and adds him to classroom's list
		{
			Class = classroom;

			if (!classroom.Students.Contains(this))
			{
				classroom.AddStudent(this);
			}
		}


		public string GetStudentName()                  //Returns student's first and last name
		{
			string name = "";

			name += FirstName + " " + LastName;

			return name;
		}
	}
}
