using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkolniTridaV2.Enum;

namespace SkolniTridaV2
{
	class Subject
	{
		public SubjectNames SubjectName;

		public List<Teacher> Educator = new List<Teacher>(5);
	}
}
