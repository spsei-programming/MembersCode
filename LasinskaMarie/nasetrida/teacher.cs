using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nasetrida
{
    class teacher
    {
        public string FirstName;

        public string Surname;

        public enum Genders {Man, Woman}

        public Genders Gender;

        public List<Subject> Special = new List<Subject>(3);

    }
}
