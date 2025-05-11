using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestScriptGeneration
{
    class RemoveDuplicationsNew
    {
        TestCaseModel testSpec = new TestCaseModel();
        TestCaseModel testDistinctSpec = new TestCaseModel();
        public TestCaseModel ReturnDistinct(TestCaseModel testspec)
        {
            testSpec = testspec;
            bool dup = true;
            int outerdup = 0;
            int check = 0;
            int inerdup = 0;
            bool resetadded = true;
            //var list = testSpec;
            for (int i = 0; i < testSpec.testcases.Count(); i++)
            {
                if (testSpec.testcases[i].action[0].ActionDescription == "Reset" || testSpec.testcases[i].action[0].ActionDescription == "reset")
                {
                    if (resetadded == true)
                    {
                        testSpec.testcases.Remove(testSpec.testcases[i]);

                    }
                    if (resetadded==false)
                    {
                        //testDistinctSpec.testcases.Add(testSpec.testcases[i]);
                        resetadded = true;
                    }
                    
                }
                else
                {
                    int inerdupcheck = 0;
                    resetadded = false;
                    for (int j = i + 1; j < testSpec.testcases.Count(); j++)
                    {
                        //check = j;
                        if (testSpec.testcases[i].action.Count() != testSpec.testcases[j].action.Count())
                        {
                            //outerdup--;
                            dup = false;
                        }
                        else
                        {
                            //outerdup++;
                            /*if (testSpec.testcases[i].action.Select(n => n.ActionVariable).Equals(testSpec.testcases[j].action.Select(x => x.ActionVariable)) && testSpec.testcases[i].action.Select(n => n.ActionValue).Equals(testSpec.testcases[j].action.Select(x => x.ActionValue)))
                            {

                                dup = true;
                            }
                            else {
                                dup = false;
                            }*/
                            dup = true;
                            inerdupcheck = 0;
                            bool innerdup = true;
                            foreach (TestActions act1 in testSpec.testcases[i].action)
                            {
                                if (act1.ActionDescription != "Reset")
                                {
                                    foreach (TestActions act in testSpec.testcases[j].action)
                                    {
                                        if (act.ActionDescription != "Reset")
                                        {
                                            if (act1.ActionVariable.Equals(act.ActionVariable) && act1.ActionValue.Equals(act.ActionValue))
                                            {
                                                innerdup = true;
                                                break;
                                            }
                                            else //if (act1.ActionDescription != "Reset" && act.ActionDescription != "Reset")
                                            {
                                                innerdup = false;
                                            }
                                        }
                                    }
                                    if (innerdup == true)
                                    {
                                        inerdupcheck++;
                                        innerdup = false;
                                    }
                                }
                                else { inerdupcheck++; }
                            }
                            
                        }
                        if (inerdupcheck == testSpec.testcases[i].action.Count())
                        {
                            testSpec.testcases.Remove(testSpec.testcases[j]);
                            inerdupcheck = 0;
                            //inerdup++;

                        }
                    }

                    /*if (((outerdup == 0 || inerdup == 0) || i == testSpec.testcases.Count() - 1))
                    {
                        testDistinctSpec.testcases.Add(testSpec.testcases[i]);
                        resetadded = false;
                        dup = true;
                        inerdup = 0;
                        outerdup = 0;
                        //check = 0;
                    }
                    else
                    {
                        inerdup = 0;
                        outerdup = 0;
                    }*/
                }
            }
                return testSpec;
        }
        public bool checkExpectedResult(Testcase t1, Testcase t2) {
            bool same = false;
            int inerdupcheck = 0;
            bool innerdup = true;
            //int inerdup = 0;
            if (t1.expectedresult.Count != t2.expectedresult.Count)
            {
                same = false;
            }
            else
            {
                foreach (ExpectedResult exp in t1.expectedresult)
                {
                    foreach (ExpectedResult exp2 in t2.expectedresult)
                    {
                        if (exp.ResultVariable.Equals(exp2.ResultVariable) && exp.ResultValue.Equals(exp2.ResultValue))
                        {
                            innerdup = true;
                            break;
                        }else
                        {
                            innerdup = false;
                        }
                    }
                    if (innerdup == true) {
                        inerdupcheck++;
                    }
                }
                if (inerdupcheck == t1.expectedresult.Count) {
                    same = true;
                }
            }
            return same;
            
        }
    }
}
