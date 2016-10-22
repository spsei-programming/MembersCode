using System.Collections.Generic;

namespace ClassroomHomework
{
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
}