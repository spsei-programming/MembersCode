using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolniTridaV2
{
	class Teacher: Person
	{
		public List<Subject> Special = new List<Subject>(5);
		public string Indication;
	}
}
