using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonusHomework.Templates
{
	public class Teacher : Person
	{
		public Subject subject;

		public Teacher(int id, string name, int age, Subject mainSubject)
		{
			this.id = id;
			this.name = name;
			this.age = age;

			subject = mainSubject;
		}
	}
}
