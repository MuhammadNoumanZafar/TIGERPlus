using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestScriptGeneration
{
    class MinimizedTestScriptGenerator
    {

        public void GenerateTestScript(TestCaseModel Tests, List<Signal> i_signals, string path) {
            ScriptCreator Creator = new ScriptCreator(path);
            Creator.StartScripting();
            foreach (Testcase tc in Tests.testcases) {
                foreach (TestActions action in tc.action) {
                    Creator.ActionStep(action.ActionDescription);
                    Signal sig = new Signal();
                    sig = i_signals.Find(x => x.LogicalName.Trim() == action.ActionVariable);
                    string valPri = sig.PrimarySignalName;
                    string valSec = sig.SecondarySignalName;
                    string val2Pri = sig.Primary2SignalName;
                    string val2Sec = sig.Secondary2SignalName;
                    Creator.ScriptAction(valPri, valSec, action.ActionValue, action.ActionValue);
                }
                foreach (ExpectedResult result in tc.expectedresult) {
                    Creator.VerificationStep(result.ResultDescription);
                    Signal sig = new Signal();
                    sig = i_signals.Find(x => x.LogicalName.Trim() == result.ResultVariable);
                    string valPri = sig.PrimarySignalName;
                    string valSec = sig.SecondarySignalName;
                    string val2Pri = sig.Primary2SignalName;
                    string val2Sec = sig.Secondary2SignalName;
                    Creator.ScriptVerify(valPri, valSec, result.ResultValue, result.ResultValue, val2Pri, val2Sec, result.ResultValue, result.ResultValue, tc.Withintime);
                }


            }
            Creator.EndScripting();
        }
    }
}
