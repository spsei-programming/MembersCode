using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nasetrida
{
    class Subject
    {
        public enum Name {Czech, Math, History, English, Chemistry, Physics, Gymnastics, Electrotechnics, Informatics, GraphicArts, Practice, Programming, TechnicalDocumentation, ComputerNetworks, TechnicalComputerEquipment, Database}

        public Name Type;

        public teacher Educator;
    }
}
