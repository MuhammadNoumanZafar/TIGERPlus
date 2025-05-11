using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestScriptGeneration
{
    public class TestCaseModel 
    {
        public TestCaseModel() {
            testcases = new List<Testcase>();
        }
        public List<Testcase> testcases { get; set; }
        
    }
    public class Testcase {
        public Testcase() {
            
            action = new List<TestActions>();
            expectedresult = new List<ExpectedResult>();
        }

        public int TestcaseID { get; set; }
        public List<TestActions> action { get; set; }
        public List<ExpectedResult> expectedresult { get; set; }
        public string Withintime { get; set; }

        
        //addition
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Testcase other = (Testcase)obj;

            return action.SequenceEqual(other.action) && expectedresult.SequenceEqual(other.expectedresult) && Withintime == other.Withintime;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + action.GetHashCode();
                hash = hash * 23 + expectedresult.GetHashCode();
                hash = hash * 23 + (Withintime != null ? Withintime.GetHashCode() : 0);
                return hash;
            }
        }

    }

    public class TestActions 
    {

        public string ActionDescription { get; set; }
        public string ActionVariable { get; set; }
        public string ActionValue { get; set; }

        
    }
    public class ExpectedResult 
    {
        public string ResultDescription { get; set; }
        public string ResultVariable { get; set; }
        public string ResultValue { get; set; }
        
    }
}
