using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestScriptGeneration
{
    class RTMModel
    {
        public List<string> requirements { get; set; }
        public string guard { get; set; }
        public List<Testcase> testcases { get; set; }
    }
}
