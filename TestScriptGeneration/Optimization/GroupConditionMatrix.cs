using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestScriptGeneration
{
    class GroupConditionMatrix
    {
        public List<GroupConditionModel> createGroupConditionMatrix(List<RTMModel> rtm)
        {
            Evaluator evaluate = new Evaluator();
            List<GroupConditionModel> GCMList = new List<GroupConditionModel>();
            
            foreach (RTMModel reqmat in rtm) {
                List<GroupCondition> GMList = new List<GroupCondition>();
                GroupConditionModel GCM = new GroupConditionModel();
                GCM.requiremenets = reqmat.requirements;
                GCM.guard = reqmat.guard;

                // Remove all whitespaces
                string pattern = @"\s+";
                string noSpaces = Regex.Replace(GCM.guard, pattern, "");

                // Get conditions within the outer brackets
                string conditionPattern =// @"\([^()]+\)";
                                          @"\((?>[^()]+|\((?<depth>)|\)(?<-depth>))*(?(depth)(?!))\)";
                MatchCollection matches = Regex.Matches(GCM.guard, conditionPattern);
                int x = 1;
                // Print extracted conditions
                foreach (Match match in matches)
                {
                    List<Testcase> testcases = new List<Testcase>();
                    GroupCondition GM = new GroupCondition();
                    GM.groupID = x;
                    GM.groupcondition = match.Value;
                    foreach (Testcase tc in reqmat.testcases)
                    {
                           bool result = evaluate.EvaluateCondition( GM.groupcondition, tc.action);
                        if (result) {
                            testcases.Add(tc);
                         }
                    }
                    GM.testcases = testcases;
                    GMList.Add(GM);
                    GCM.group = GMList;
                    x++;
                }
                
                GCMList.Add(GCM);
            }
            return GCMList;
        }
        
    }
}
