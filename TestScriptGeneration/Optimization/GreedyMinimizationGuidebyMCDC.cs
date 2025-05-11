using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestScriptGeneration
{
    class GreedyMinimizationGuidebyMCDC
    {
        public List<GroupConditionModel> MinimizeTestSuite(List<GroupConditionModel> gmList)
        {
            List<GroupConditionModel> GMLIST = new List<GroupConditionModel>();
            bool dup = false;
            bool resetaddedstatus = false;
            //bool testisReset = false;
           // bool distest = false;
            TestComparerBasedonGroups compare = new TestComparerBasedonGroups();

            EvaluteMCDC evaluate = new EvaluteMCDC();
            foreach (GroupConditionModel list in gmList)
            {
                List<GroupCondition> GClist = new List<GroupCondition>();
                foreach (GroupCondition gclist in list.group)
                {
                    List<Testcase> tests = new List<Testcase>();
                    List<Testcase> testdistinct = new List<Testcase>();
                    bool hasEffect;

                    foreach (Testcase test in gclist.testcases) {
                        if (testdistinct.Count() == 0)
                        {

                            testdistinct.Add(test);
                        }
                        else {
                            foreach (Testcase Distincttc in testdistinct)
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
                                //if (Distincttc.action.Any(act => act.ActionDescription == "Reset" || act.ActionDescription == "reset"))
                                //{
                                    //do nothing - skip comparison 
                                //}
                               // else
                               // {
                                    dup = compare.CompareTest(test.action, Distincttc.action, gclist.groupcondition);
                                    if (dup == true)
                                    {
                                        break;
                                    }
                               // }

                            }
                            if (dup == false)
                            {
                                testdistinct.Add(test);
                                resetaddedstatus = false;
                            }
                        }
                    }

                    foreach (Testcase tc in testdistinct)
                    {
                        
                        hasEffect = evaluate.EvaluateMCDC(gclist.groupcondition, tc.action);
                        if (hasEffect)
                        {
                            tests.Add(tc);
                        }
                    }
                    gclist.testcases = tests;
                }
                GClist = list.group;
            }
            GMLIST = gmList;
            return GMLIST;
        }

    }
    class EvaluteMCDC
    {

        public bool EvaluateMCDC(string condition, List<TestActions> variables)
        {
            List<string> relatedvariables = new List<string>();
            string cond=condition;
            bool PresenceOfVariableEffecting = false;
            var parameter = Expression.Parameter(typeof(TestActions), "x");
            //var valueDictionary = variables.ToDictionary(v => v.ActionVariable, v => v.ActionValue);
            foreach (TestActions tacount in variables)
            {
                if (tacount.ActionDescription != "Preserved Value from Reset State")
                {
                    if (cond.Contains(tacount.ActionVariable))
                    {
                        relatedvariables.Add(tacount.ActionVariable);
                    }
               }
            }
            foreach (string str in relatedvariables)
            {
                bool check;
                string val;
                // Replace the variable names with their corresponding values
                cond = condition;
                foreach (TestActions ta in variables)
                {
                    val = ta.ActionValue;
                    if (ta.ActionVariable == str)
                    {
                        if (ta.ActionValue == "true" || ta.ActionValue == "TRUE")
                        {
                            val = "false";
                        }
                        else {
                            val = "true";
                        }
                    }
                    cond = cond.Replace(ta.ActionVariable, val);
                }

                // Compile the condition string into a Lambda expression
                var expression = System.Linq.Dynamic.DynamicExpression.ParseLambda(new[] { parameter }, null, cond);

                // Compile the expression and evaluate it
                var compiledExpression = (Expression<Func<TestActions, bool>>)expression;
                check = compiledExpression.Compile()(new TestActions());
                if (PresenceOfVariableEffecting == false && check == false) {
                    PresenceOfVariableEffecting = true;
                }
                
            }
            return PresenceOfVariableEffecting;
        }
    }
    class TestComparerBasedonGroups {
        bool equalaction, equaltest, equalresults = true;
        int actcount = 0;
        int rescount = 0;
         bool AreObjectsEqual(object obj1, object obj2)
        {
            // If the objects are the same instance, they are equal
            if (object.ReferenceEquals(obj1, obj2))
            {
                return true;
            }

            // If either object is null, they are not equal
            if (obj1 == null || obj2 == null)
            {
                return false;
            }

            // Get the types of the objects
            Type type1 = obj1.GetType();
            Type type2 = obj2.GetType();

            // If the types are different, the objects are not equal
            if (type1 != type2)
            {
                return false;
            }

            // Get the properties of the objects
            PropertyInfo[] properties = type1.GetProperties();

            // Compare the values of each property
            foreach (PropertyInfo property in properties)
            {
                object value1 = property.GetValue(obj1, null);
                object value2 = property.GetValue(obj2, null);

                if (!object.Equals(value1, value2))
                {
                    return false;
                }
            }

            return true;
        }
        public bool CompareTest(List<TestActions> tests, List<TestActions> ytest,string condition/*, List<ExpectedResult> a, List<ExpectedResult> b*/)
        {
            string cond = condition;
            List<string> relatedvariables = new List<string>();
            foreach (TestActions tacount in tests)
            {
                if (tacount.ActionDescription != "Preserved Value from Reset State")
                {
                    if (cond.Contains(tacount.ActionVariable))
                    {
                        relatedvariables.Add(tacount.ActionVariable);
                    }
                }
            }



            //HashSet<TestActions> abc = new HashSet<TestActions>(x);
            //HashSet<TestActions> xyz = new HashSet<TestActions>(y);
            //equalaction = new HashSet<TestActions>(x).Equals(new HashSet<TestActions>(y));
            //equalaction = x.SequenceEqual(y);
            TestActions act = new TestActions();
            TestActions actcomp = new TestActions();
                foreach (string str in relatedvariables)
                {
                act = ytest.FirstOrDefault(x => x.ActionVariable == str);
                actcomp = tests.FirstOrDefault(x => x.ActionVariable == str);
                    if (/*AreObjectsEqual(*/act.ActionValue == actcomp.ActionValue)
                    {
                        equalaction = true;
                    }
                    else
                    {
                        equalaction = false;
                        actcount++;
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
}