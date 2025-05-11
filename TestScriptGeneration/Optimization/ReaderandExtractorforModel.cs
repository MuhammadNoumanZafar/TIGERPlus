using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System.Threading.Tasks;

namespace TestScriptGeneration
{
    class ReaderandExtractorforModel
    {
        public List<DataModelforFSMModel> readAndextract() {
            string path = SharedDataClass.GetModelPath();
            string json = File.ReadAllText(path);
            //List<dynamic> data = JsonConvert.DeserializeObject<List<dynamic>>(json);
            // Extract the Requirements and Guard using LINQ
            //var reqAndguard = from person in data
            //             from address in person.addresses
            //             select new
            //             {
            //                 Age = person.age,
            //                 Address = address
            //             };
            JObject parsedJson = JObject.Parse(json);
            List<DataModelforFSMModel> ListdM = new List<DataModelforFSMModel>();
            JArray models = (JArray)parsedJson["models"];
            int i = 0;
            foreach (JObject model in models)
            {
                JArray edges = (JArray)parsedJson["models"][i]["edges"];

                
                foreach (JObject edge in edges)
                {
                    string guard = (string)edge["guard"];
                    JArray requirementsArray = (JArray)edge["requirements"];

                    List<string> requirements = requirementsArray != null ? requirementsArray.Select(x => (string)x).ToList() : new List<string>();

                    if (guard != null)
                    {
                        DataModelforFSMModel dm = new DataModelforFSMModel();
                        dm.guard = guard;
                        dm.requirements = requirements;
                        ListdM.Add(dm);
                    }
                }
                i++;
            }
            return ListdM;
        }

    }
}
