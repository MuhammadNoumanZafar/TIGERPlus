using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestScriptGeneration
{
    class ScriptCreator
    {
        StreamWriter outputFile;
        //Removed because of NDA
        public ScriptCreator(string filePath) {
            outputFile = new StreamWriter(filePath);
        }
        public void StartScripting() {
            //Removed because of NDA
        }
        public void ActionStep(string elementname) {
            //Removed because of NDA
        }
        public void ScriptAction(string PriSignalName, string SecSignalName, string PriSignalValue, string SecSignalValue){
            //Removed because of NDA
        }
        public void VerificationStep(string elementname)
        {
            outputFile.WriteLine("this.Trace(LogType.Verification,\"" + elementname + "\");");
        }
        public void ScriptVerify(string PriSignalName, string SecSignalName, string PriSignalValue, string SecSignalValue, string PriSignal2Name, string SecSignal2Name, string PriSignal2Value, string SecSignal2Value, string time) {
            //Removed because of NDA
        }
        public void EndScripting() {
            //Removed because of NDA
        }

    }
}
