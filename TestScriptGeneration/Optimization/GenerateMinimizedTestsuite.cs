using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestScriptGeneration
{
    class GenerateMinimizedTestsuite
    {
        TestCaseModel tests = new TestCaseModel();
        TestCaseModel tests2 = new TestCaseModel();
        public TestCaseModel generate(List<GroupConditionModel> GMLIST) {
            foreach (GroupConditionModel gcm in GMLIST) {

                foreach (GroupCondition gc in gcm.group) {
                    foreach (Testcase tc in gc.testcases) {
                        if (tests.testcases.Count()==0)
                        {
                            tests.testcases.Add(tc);
                        }
                        else {
                            bool testexist = false;
                            foreach (Testcase distest in tests.testcases) {
                                if (tc.TestcaseID == distest.TestcaseID) {
                                    testexist = true;
                                    break;
                                }
                            }
                            if (testexist == false) {
                                tests.testcases.Add(tc);
                            }
                        }
                    }
                }
            }
            RemoveIdenticalTests remove = new RemoveIdenticalTests();
            tests2 = remove.ReturnDistinctwithoutReset(tests);
            return tests2;
        } 
    }
}
