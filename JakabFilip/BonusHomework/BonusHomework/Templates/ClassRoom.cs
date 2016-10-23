using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonusHomework.Templates
{
	public class ClassRoom
	{
		public string name;

		public List<Student> students;
		public Teacher teacher;

		public ClassRoom(string name)
		{
			this.name = name;

			students = new List<Student>(30);
		}
	}
}
