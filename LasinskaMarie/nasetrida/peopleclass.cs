using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nasetrida
{
    class peopleclass
    {
        public int Grade;

        public enum Specializations { Informatics, Electrotechnics}

        public Specializations Specialization;

        public enum Character {A, B, C}

        public Character Letter;

        public teacher ClassTeacher;

        public List<student> Students = new List<student>(30);

        public List<Subject> Subjects = new List<Subject>(20);
    }
}
