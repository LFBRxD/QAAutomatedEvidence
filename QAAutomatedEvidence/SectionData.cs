using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAAutomatedEvidence
{

    public class SectionData
    {
        public string Name { get; set; }
        public List<string> Evidences { get; set; }

        public SectionData(string name)
        {
            Name = name;
            Evidences = new List<string>();
        }
    }

}
