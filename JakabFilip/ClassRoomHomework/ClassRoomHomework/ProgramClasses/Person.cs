using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRoomHomework.ProgramClasses
{
	public class Person
	{
		public enum Gender { MALE, FEMALE };

		public int id;
		public int age;
		public string name;
		public Gender gender;
	}
}
