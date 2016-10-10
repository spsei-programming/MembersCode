using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanzelkaJan.Homework1
{
	class Classroom
	{

		//Fields

		public enum Orientations { Informatici, Elektro }

		public enum Groups { A, B, C }

		public Orientations Orientation;

		public Groups Group;

		public byte Level;

		public Teacher Teacher;

		public List<Student> Students = new List<Student>(10);

		//Methods

		public void SetTeacher(Teacher teacher)          //Sets the classroom's teacher and vice versa
		{
			Teacher = teacher;
			teacher.Class = this;
		}


		public void AddStudent(Student student)           //Adds a student to classroom
		{
			if (!Students.Contains(student))
			{
				Students.Add(student);
			}
		}


		public string GetClassName()                    //Returns classroom's name
		{
			string name = "";

			if (Orientation == Orientations.Informatici)
				name += "I";
			else
			{
				name += "E";
			}

			name += Level;

			name += Group;

			return name;
		}
	}
}
