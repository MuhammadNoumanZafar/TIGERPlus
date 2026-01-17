using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
namespace TestScriptGeneration
{
    class AbstractTestcasesGen
    {
        private List<Rootobject> testcaseData;
        private List<Signal> signals;
        private TestCaseModel testcaseSpec = new TestCaseModel();
        private Testcase testcase;
        private TestActions testaction;
        private ExpectedResult result;
        int id = 1;
        public TestCaseModel OptimizeAbstractTestcases(List<Rootobject> tc, List<Signal> i_signals)
        {
            
            testcaseData = tc;
            signals = i_signals;
            string time = ""; //bug should be in loop
            try
            {

                //Mapping Json Signal Names with Technical Signals
                //List<String> Act = new List<String>();
                /* foreach (Rootobject rootobj in testcaseData) //bug elimination code in Progress for Time constraint
                 {
                     if (rootobj.actions != null)
                     {
                         string action = "";
                         int stepcout = 0;
                         foreach (Actions act in rootobj.actions)  //bug elimination should be done
                         {
                             action = String.Concat(act.Action);
                         }
                         Act.Add(action);
                     }
                 }*/
                testcase = new Testcase();
                bool visitedoutput = false;
                foreach (Rootobject rootobj in testcaseData)
                {
                    if (rootobj.actions != null)
                    {
                        int stepcout = 0;
                        foreach (Actions act in rootobj.actions)
                        {

                            string[] delimiters = { ";" };
                            List<string> SplitActionValue = act.Action.Split(delimiters, StringSplitOptions.None).ToList();
                            CompareInfo myComp = CultureInfo.InvariantCulture.CompareInfo;
                            foreach (string str in SplitActionValue)
                            {
                                if (myComp.IsPrefix(str.Trim(), "Time") || myComp.IsPrefix(str.Trim(), "time"))
                                {
                                    string[] delimiters2 = { "=" };
                                    List<string> SplitActionValue2 = str.Split(delimiters2, StringSplitOptions.None).ToList();
                                    time = SplitActionValue2[1];
                                    testcase.Withintime = time;
                                }
                            }
                            foreach (string str in SplitActionValue)
                            {
                                if (str.Trim().Length > 1)
                                {
                                    string[] delimiters2 = { "=" };
                                    List<string> SplitActionValue2 = str.Split(delimiters2, StringSplitOptions.None).ToList();
                                    if (signals.Any(x => x.LogicalName.Trim() == SplitActionValue2[0].Trim()))
                                    {
                                        Signal sig = new Signal();
                                        sig = signals.Find(x => x.LogicalName.Trim() == SplitActionValue2[0].Trim());
                                        string valPri = sig.PrimarySignalName;
                                        string valSec = sig.SecondarySignalName;
                                        string val2Pri = sig.Primary2SignalName;
                                        string val2Sec = sig.Secondary2SignalName;
                                        //if (valPri == "Time") {
                                        //    int time = Convert.ToInt32(SplitActionValue2[1]);
                                        //}
                                        //string content, content2, content12, content22;
                                        if (sig.Stype == "Input")
                                        {
                                            if (visitedoutput == true)
                                            {
                                                visitedoutput = false;
                                                testcase.TestcaseID = id;
                                                testcaseSpec.testcases.Add(testcase);
                                                testcase = new Testcase();
                                                id++;
                                            }

                                            //content0 = ""
                                            //if (stepcout == 0)
                                            // {
                                            testaction = new TestActions();
                                            testaction.ActionDescription = rootobj.currentElementName.Trim();
                                            testaction.ActionVariable = SplitActionValue2[0].Trim();
                                            testaction.ActionValue = SplitActionValue2[1].Trim();
                                            testcase.action.Add(testaction);
                                            //  stepcout++;
                                            // }
                                        }
                                        else
                                        {
                                            if (sig.LogicalName != "Time")
                                            {
                                                // if (stepcout == 0)
                                                // {
                                                result = new ExpectedResult();
                                                result.ResultDescription = rootobj.currentElementName.Trim();
                                                result.ResultVariable = SplitActionValue2[0].Trim();
                                                result.ResultValue = SplitActionValue2[1].Trim();
                                                testcase.expectedresult.Add(result);
                                                // Creator.VerificationStep(rootobj.currentElementName);
                                                stepcout++;
                                                // }
                                                // Creator.ScriptVerify(valPri, valSec, SplitActionValue2[1], SplitActionValue2[1], val2Pri, val2Sec, SplitActionValue2[1], SplitActionValue2[1], time);

                                            }
                                            visitedoutput = true;
                                        }

                                    }
                                    else
                                    {
                                        //  MessageBox.Show("Missing Information of " + SplitActionValue2[0].Trim() + " in XML");
                                    }

                                }

                            }
                        }

                    }
                }
                // Creator.EndScripting();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            /*string Jsonstr = JsonConvert.SerializeObject(testcaseSpec);
            using (var streamWriter = new StreamWriter(filePath + ".json", true))
            {
                streamWriter.WriteLine(Jsonstr.ToString());
                streamWriter.Close();
            }
            TestCaseModel test = new TestCaseModel();
            RemoveDuplications remove = new RemoveDuplications();
            test = remove.ReturnDistinct(testcaseSpec);
            string Jsonstr2 = JsonConvert.SerializeObject(test);
            using (var streamWriter = new StreamWriter(filePath + "_Optimized.json", true))
            {
                //streamWriter.WriteLine("//Orignal Generated Test cases were " + +" And optimized are ") ;
                streamWriter.WriteLine(Jsonstr2.ToString());
                streamWriter.Close();
            }*/

            return testcaseSpec;
        }
    }
}
