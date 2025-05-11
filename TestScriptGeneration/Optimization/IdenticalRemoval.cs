using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestScriptGeneration
{
    class IdenticalRemoval
    {
        public TestCaseModel ReturnDistinct(TestCaseModel testCaseModel) {

            List<Testcase> distinctTestCases = new List<Testcase>();

            // get the test cases from the original TestCaseModel
            List<Testcase> testCases = testCaseModel.testcases;

            // loop through each test case in the original list
            foreach (Testcase testCase in testCases)
            {
                // check if the distinctTestCases list already contains this test case
                if (!distinctTestCases.Contains(testCase))
                {
                    // if it doesn't, add it to the distinctTestCases list
                    distinctTestCases.Add(testCase);
                }
            }

            // create a new TestCaseModel with the distinct test cases
            TestCaseModel distinctTestCaseModel = new TestCaseModel();
            distinctTestCaseModel.testcases = distinctTestCases;
            return distinctTestCaseModel;
        }
    }
}
