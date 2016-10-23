using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonusHomework.Templates
{
	public class Student : Person
	{
		public bool hasHomework;

		public Student(int id, string name, int age, Gender gender, Subject favSubject)
		{
			this.id = id;
			this.name = name;
			this.age = age;
			this.gender = gender;

			hasHomework = false;
		}

		//public void doHomework()
		//{
		//	if (hasHomework)
		//	{
		//		hasHomework = false;
		//		if (gender == Gender.Male)
		//			Console.WriteLine($"Student {name} has finished his homework.");
		//		else
		//			Console.WriteLine($"Student { name } has finished her homework.");
		//	}
		//	else
		//	{
		//		Console.WriteLine($"Student {name} has no homework.");
		//	}
		//}
	}
}
