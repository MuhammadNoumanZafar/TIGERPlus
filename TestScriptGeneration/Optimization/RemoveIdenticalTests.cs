using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestScriptGeneration
{
    class RemoveIdenticalTests
    {
        TestCaseModel testSpec = new TestCaseModel();
        TestCaseModel testDistinctSpec = new TestCaseModel();
        ListComparer compare = new ListComparer();
        public TestCaseModel ReturnDistinct(TestCaseModel testspec)
        {
            testSpec = testspec;
            bool dup = false;
            bool resetaddedstatus = false;
            bool testisReset = false;
            bool distest = false;
            
            //var list = testSpec;
            foreach (Testcase tc in testSpec.testcases)
            {
                if (testDistinctSpec.testcases.Count == 0)
                {
                    testDistinctSpec.testcases.Add(tc);
                }
                else {
                    foreach (TestActions ac in tc.action)
                    {
                        if (ac.ActionDescription.Equals("Reset") || ac.ActionDescription.Equals("reset"))
                        {
                            testisReset = true;
                        }
                        else
                        {
                            testisReset = false;
                        }
                    }
                    if (testisReset == true && resetaddedstatus == false)
                    {
                        testDistinctSpec.testcases.Add(tc);
                        resetaddedstatus = true;
                    }
                    if (testisReset == false && resetaddedstatus == true )
                    {
                        foreach (Testcase Distincttc in testDistinctSpec.testcases)
                        {
         
                            /*bool actcomp = tc.action.SequenceEqual(Distincttc.action);
                            bool rescomp = tc.expectedresult.SequenceEqual(Distincttc.expectedresult);
                            if (actcomp == false && rescomp == false)
                            {
                                dup = false;
                            }
                            else {
                                dup= true;
                                break;
                            }*/
                            if (Distincttc.action.Any(act => act.ActionDescription == "Reset" || act.ActionDescription == "reset")) {
                              //do nothing - skip comparison 
                            }
                            else
                            {
                                dup = compare.CompareTest(tc.action, Distincttc.action/*, tc.expectedresult, Distincttc.expectedresult*/);
                                if (dup == true)
                                {
                                    break;
                                }
                            }

                        }       
                        if (dup == false)
                        {
                            testDistinctSpec.testcases.Add(tc);
                            resetaddedstatus = false;
                        }
                    }
                }
            }
            return testDistinctSpec;
        }
        public TestCaseModel ReturnDistinctwithoutReset(TestCaseModel testspec)
        {
            testSpec = testspec;
            bool dup = false;
            bool resetaddedstatus = false;
            bool testisReset = false;
            bool distest = false;

            //var list = testSpec;
            foreach (Testcase tc in testSpec.testcases)
            {
                if (testDistinctSpec.testcases.Count == 0)
                {
                    testDistinctSpec.testcases.Add(tc);
                }
                else
                {
                    
                        foreach (Testcase Distincttc in testDistinctSpec.testcases)
                        {

                            /*bool actcomp = tc.action.SequenceEqual(Distincttc.action);
                            bool rescomp = tc.expectedresult.SequenceEqual(Distincttc.expectedresult);
                            if (actcomp == false && rescomp == false)
                            {
                                dup = false;
                            }
                            else {
                                dup= true;
                                break;
                            }*/
                            
                                dup = compare.CompareTestwithoutDes(tc.action, Distincttc.action/*, tc.expectedresult, Distincttc.expectedresult*/);
                                if (dup == true)
                                {
                                    break;
                                }

                        }
                        if (dup == false)
                        {
                            testDistinctSpec.testcases.Add(tc);
                            resetaddedstatus = false;
                        }
                    
                }
            }
            return testDistinctSpec;
        }
    }
    public class ListComparer
    {
        
        
        public bool CompareTest(List<TestActions> x, List<TestActions> y/*, List<ExpectedResult> a, List<ExpectedResult> b*/)
        {
            bool equalaction, equaltest, equalresults = true;
            int actcount = 0;
            int rescount = 0;

            if (x.Count != y.Count)
            {
                //equalaction = false;
                actcount = 1;
            }
            else
            {
                //HashSet<TestActions> abc = new HashSet<TestActions>(x);
                //HashSet<TestActions> xyz = new HashSet<TestActions>(y);
                //equalaction = new HashSet<TestActions>(x).Equals(new HashSet<TestActions>(y));
                //equalaction = x.SequenceEqual(y);
                for (int i = 0; i < x.Count(); i++)
                {
                    
                    if (y.Any(act => act.ActionVariable == x[i].ActionVariable && act.ActionValue == x[i].ActionValue /*&& act.ActionDescription.Equals(x[i].ActionDescription)*/))
                    {
                        equalaction = true;
                    }
                    else
                    {
                        equalaction = false;
                        actcount++;
                    }
                }
            }
            /*if (a.Count != b.Count)
            {
                equalresults = false;
            }
            else
            {
                //equalresults = new HashSet<ExpectedResult>(a).Equals(new HashSet<ExpectedResult>(b));
                //equalresults = a.SequenceEqual(b);
                for (int i = 0; i < a.Count(); i++)
                {

                    if (b.Any(exp => exp.ResultVariable == a[i].ResultVariable && exp.ResultValue == a[i].ResultValue && exp.ResultDescription.Equals(a[i].ResultDescription)))
                    { 
                        // rescount++;
                        equalresults = true;
                    }
                    else
                    {

                        equalresults = false;
                        rescount++;

                    }
                }
            }*/
            if (actcount > 0 /*&& rescount>0*/)
            {
                equaltest = false;
                actcount = 0;
               // rescount = 0;
            }
            else
            {
                equaltest = true;
                actcount = 0;
              //  rescount = 0;
            }
            return equaltest;
        }
        public bool CompareTestwithoutDes(List<TestActions> x, List<TestActions> y/*, List<ExpectedResult> a, List<ExpectedResult> b*/)
        {
            bool equalaction, equaltest, equalresults = true;
            int actcount = 0;
            int rescount = 0;

            if (x.Count != y.Count)
            {
                //equalaction = false;
                actcount = 1;
            }
            else
            {
                //HashSet<TestActions> abc = new HashSet<TestActions>(x);
                //HashSet<TestActions> xyz = new HashSet<TestActions>(y);
                //equalaction = new HashSet<TestActions>(x).Equals(new HashSet<TestActions>(y));
                //equalaction = x.SequenceEqual(y);
                for (int i = 0; i < x.Count(); i++)
                {

                    if (y.Any(act => act.ActionVariable == x[i].ActionVariable && act.ActionValue == x[i].ActionValue))
                    {
                        equalaction = true;
                    }
                    else
                    {
                        equalaction = false;
                        actcount++;
                    }
                }
            }
            /*if (a.Count != b.Count)
            {
                equalresults = false;
            }
            else
            {
                //equalresults = new HashSet<ExpectedResult>(a).Equals(new HashSet<ExpectedResult>(b));
                //equalresults = a.SequenceEqual(b);
                for (int i = 0; i < a.Count(); i++)
                {

                    if (b.Any(exp => exp.ResultVariable == a[i].ResultVariable && exp.ResultValue == a[i].ResultValue && exp.ResultDescription.Equals(a[i].ResultDescription)))
                    { 
                        // rescount++;
                        equalresults = true;
                    }
                    else
                    {

                        equalresults = false;
                        rescount++;

                    }
                }
            }*/
            if (actcount > 0 /*&& rescount>0*/)
            {
                equaltest = false;
                actcount = 0;
                // rescount = 0;
            }
            else
            {
                equaltest = true;
                actcount = 0;
                //  rescount = 0;
            }
            return equaltest;
        }

    }
    class MyComparerTest : IEqualityComparer<Testcase>
    {
        public bool Equals(Testcase x, Testcase y)
        {
            return Compare2Objects.CompareEquals(x, y);

        }

        public int GetHashCode(Testcase obj)
        {
            return obj.action.GetHashCode();
        }
    }
    static class Compare2ObjectsTest
    {
        public static bool CompareEquals<T>(this T objectFromCompare, T objectToCompare)
        {
            if (objectFromCompare == null && objectToCompare == null)
                return true;

            else if (objectFromCompare == null && objectToCompare != null)
                return false;

            else if (objectFromCompare != null && objectToCompare == null)
                return false;

            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in props)
            {
                object dataFromCompare =
                objectFromCompare.GetType().GetProperty(prop.Name).GetValue(objectFromCompare, null);

                object dataToCompare =
                objectToCompare.GetType().GetProperty(prop.Name).GetValue(objectToCompare, null);

                Type type =
                objectFromCompare.GetType().GetProperty(prop.Name).GetValue(objectToCompare, null).GetType();

                if (prop.PropertyType.IsClass &&
                !prop.PropertyType.FullName.Contains("System.String"))
                {
                    dynamic convertedFromValue = Convert.ChangeType(dataFromCompare, type);
                    dynamic convertedToValue = Convert.ChangeType(dataToCompare, type);

                    object result = Compare2Objects.CompareEquals(convertedFromValue, convertedToValue);

                    bool compareResult = (bool)result;
                    if (!compareResult)
                        return false;
                }

                else if (!dataFromCompare.Equals(dataToCompare))
                    return false;
            }

            return true;
        }
    }
}
