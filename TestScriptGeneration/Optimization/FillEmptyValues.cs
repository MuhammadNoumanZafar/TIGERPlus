using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestScriptGeneration
{
    class FillEmptyValues
    {
        
        public TestCaseModel FillValuesinEmptyCell(TestCaseModel testspecs) {
            TestCaseModel withmissingtestvalues = new TestCaseModel();
            withmissingtestvalues = testspecs;

            //finding the reset test case from the list
            Testcase ResetTestcase = new Testcase();
                ResetTestcase = withmissingtestvalues.testcases.FirstOrDefault(x => x.action.Any(a => a.ActionDescription == "Reset" || a.ActionDescription == "reset"));

            //creating a new list of test cases with missing values
            TestCaseModel testwithoutEmptyValues = new TestCaseModel();

            foreach (Testcase test in withmissingtestvalues.testcases) {

                foreach (Signal sig in SharedDataClass.GetSignal()) {
                    if (sig.Stype == "Input")
                    {
                        if (!test.action.Any(a => a.ActionVariable == sig.LogicalName))
                        {
                            TestActions NewAction = new TestActions()
                            {
                                ActionDescription = "Preserved Value from Reset State",
                                ActionVariable = sig.LogicalName,
                                ActionValue = ResetTestcase.action.Where(a => a.ActionVariable == sig.LogicalName)
                                        .Select(a => a.ActionValue)
                                        .FirstOrDefault()
                            };
                            test.action.Add(NewAction);
                        }
                    }
                }
            }
            return withmissingtestvalues;
        }
    }
}
