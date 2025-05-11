using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestScriptGeneration
{
    class TestGenerator
    {
        private List<Rootobject> testcaseData;
        private List<Signal> signals;
        public void GenerateTestScripts(List<Rootobject> tc, List<Signal> i_signals, string path) {
            testcaseData = tc;
            List<string> log = new List<string>();
            signals = i_signals;
            string time = ""; //bug should be in loop
            //Spliting string and coverting it into respective data type
            string filePath = path;

            try
            {
                ScriptCreator Creator = new ScriptCreator(filePath);
                Creator.StartScripting();

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
                                    if (myComp.IsPrefix(str.Trim(), "Time") || myComp.IsPrefix(str.Trim(), "time")) {
                                        string[] delimiters2 = { "=" };
                                        List<string> SplitActionValue2 = str.Split(delimiters2, StringSplitOptions.None).ToList();
                                        time = SplitActionValue2[1];
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
                                                //content0 = ""
                                                if (stepcout == 0)
                                                {
                                                    Creator.ActionStep(rootobj.currentElementName);
                                                    stepcout++;
                                                }
                                                Creator.ScriptAction(valPri, valSec, SplitActionValue2[1], SplitActionValue2[1]);
                                            }
                                            else
                                            {
                                                if (sig.LogicalName != "Time")
                                                {
                                                    if (stepcout == 0)
                                                    {
                                                        Creator.VerificationStep(rootobj.currentElementName);
                                                        stepcout++;
                                                    }
                                                    Creator.ScriptVerify(valPri, valSec, SplitActionValue2[1], SplitActionValue2[1], val2Pri, val2Sec, SplitActionValue2[1], SplitActionValue2[1],time);
                                                    
                                                }
                                            }

                                        }
                                        else {
                                        //MessageBox.Show("Missing Information of " + SplitActionValue2[0].Trim() + " in XML");
                                            if (!log.Any(x => x == SplitActionValue2[0].Trim()))
                                            {
                                                log.Add(SplitActionValue2[0].Trim());
                                            }
                                        }

                                    }

                                }
                            }

                        }
                    }
                Creator.EndScripting();
                if (log.Count > 0)
                {
                    string logstr = string.Join(",", log);
                    MessageBox.Show("Missing Signal technical names of " + logstr + " in XML");
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
            //Generating Test Scripts
        }
    }
}
