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
		public byte level;

		public MemberTypes memberType;
		public Orientations classOrientation;

		public List<Student> students;
		public Teacher teacher;

		public ClassRoom()
		{
			students = new List<Student>(30);
			teacher = new Teacher();
		}

		public ClassRoom(string name, MemberTypes memberType, Orientations classOrientation, byte level)
		{
			this.name = name;
			this.memberType = memberType;
			this.classOrientation = classOrientation;
			this.level = level;

			students = new List<Student>(30);
		}
	}
}
