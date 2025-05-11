using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestScriptGeneration
{
    class GroupConditionModel
    {
        public string guard { get; set; }
        public List<string> requiremenets { get; set; }
        public List<GroupCondition> group { get; set; }
        
    }
    class GroupCondition { 
        public int groupID { get; set; }
        public string groupcondition { get; set; }
        public List<Testcase> testcases { get; set; }
    }
}
