using System.Collections.Generic;

namespace ClassroomHomework
{
	public class Teacher : Person
	{
		public List<Subject> Subjects;
		public bool IsTeaching;

		public Teacher(string firstName, string lastName, int age, Genders gender, List<Subject> subjects) : base(firstName, lastName, age, gender)
		{
			Subjects = subjects;
		}

		public void AddSubject(Subject subject)
		{
			Subjects.Add(subject);
		}
	}
}