using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestScriptGeneration
{
    static class SharedDataClass
    {
        static private List<Signal> signal;
        static private List<Rootobject> testcase;
        static private TestCaseModel testspec;
        static private List<GroupConditionModel> GM;
        static private string Jsonfilepath, outpath;
        static private int option = 0;
        static private string modelpath = "";
        static private string FileName = "Default";

        static public void setModelPath(string path) {
            modelpath = path;
        }
        static public void setSignal(List<Signal> sig)
        {
            signal = sig;
        }
        static public void setOption(int opt) {
            option = opt;        
        }
        static public string getFileName() {
            return FileName;
        }
        static public void setGroupCondition(List<GroupConditionModel> gm) {
            GM = gm;
        }
        static public List<GroupConditionModel> getGroupModel() {
            return GM;
        }

        static public void SetSharedData(List<Rootobject> root, List<Signal> sig, string path, string outputpath, int opt) {
            Jsonfilepath = path;
            outpath = outputpath;
            signal = sig;
            testcase = root;
            option = opt;
        }
        static public void SetSharedData(TestCaseModel test, List<Signal> sig, string path, string outputpath, int opt)
        {
            Jsonfilepath = path;
            outpath = outputpath;
            signal = sig;
            testspec = test;
            option = opt;
        }
        static public void setExcelOutputPath(string path) {
            Jsonfilepath = path;
        }
        static public void setExcelFileName(string name) {
            FileName = name;
        }

        static public List<Signal> GetSignal() {
            return signal;
        }
        static public TestCaseModel GetTestCaseModel() {
            return testspec;
        }

        static public string GetAbstractCasesJsonFilePath() {
            return Jsonfilepath;
        }
        static public string AbstractCasesOutputFilePath()
        {
            return outpath;
        }
        static public int GetOption() {
            return option;
        }
        static public string GetModelPath() {
            return modelpath;
        }
        static public List<Rootobject> GetTestcases()
        {
            return testcase;
        }
    }

    public static class GraphWalkerPath {
        public static string path = "C:\\GraphWalker";
    }
}
