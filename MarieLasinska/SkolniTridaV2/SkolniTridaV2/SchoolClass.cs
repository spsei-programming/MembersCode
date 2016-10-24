using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkolniTridaV2.Enum;

namespace SkolniTridaV2
{
	class SchoolClass
	{
		public int Grade;

		public Specializations Specialization;

		public Letters Letter;

		public Teacher ClassTeacher;

		public string Name;

		public List<Student> Students = new List<Student>(30);

		public List<Subject> Subjects = new List<Subject>(20);
	}
}
