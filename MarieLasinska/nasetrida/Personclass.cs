using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nasetrida
{
    class PersonClass
    {
        public int Grade;

        public Specialization Specialization;

        public Character Character;

        public Teacher ClassTeacher;

        public List<Student> Students = new List<Student>(30);

        public List<Subject> Subjects = new List<Subject>(20);
    }
}
