using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestScriptGeneration
{
    public partial class DecisionTable : Form
    {
        public DecisionTable()
        {
            InitializeComponent();
        }

        private void DecisionTable_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource = ShowGrid();
        }
        public System.Data.DataTable ShowGrid()
        {
            System.Data.DataTable table = new System.Data.DataTable();

            if (SharedDataClass.GetOption() == 0) {
                table.Columns.Add("Requirements");
                table.Columns.Add("Guard Condition");
                table.Columns.Add("Group ID");
                table.Columns.Add("Group Condition");
                table.Columns.Add("Test Case ID", typeof(string));
            }

            if (SharedDataClass.GetOption() == 2)
            {
                table.Columns.Add("Test Case ID", typeof(string));
            }
            if (SharedDataClass.GetOption() == 3)
            {
                table.Columns.Add("Test Case ID", typeof(string));
            }
            foreach (Signal sig in SharedDataClass.GetSignal())
            {
                // if (sig.Stype == "Input")
                //  {
                
                table.Columns.Add(sig.LogicalName, typeof(string));
              //  }
                /*string url = SharedDataClass.Jsonfilepath;
                using (StreamReader r = new StreamReader(url))
                {
                    string json = r.ReadToEnd();
                    //  List<Rootobject> items = JsonConvert.DeserializeObject<List<Rootobject>>(json);
                    List<Rootobject> tc = FromDelimitedJson<Rootobject>(new StringReader(json)).ToList();
                }*/
            }
            if (SharedDataClass.GetOption() == 0) {
                foreach (GroupConditionModel gcm in SharedDataClass.getGroupModel()) {
                    foreach (GroupCondition gc in gcm.group) {
                        foreach (Testcase tc in gc.testcases) {
                            DataRow dr = table.NewRow();
                            dr["Requirements"] = String.Join(",",gcm.requiremenets);
                            dr["Guard Condition"] = gcm.guard;
                            dr["Group ID"] = gc.groupID;
                            dr["Group Condition"] = gc.groupcondition;
                            dr["Test Case ID"] = tc.TestcaseID;
                            foreach (TestActions act in tc.action)
                            {
                                dr[act.ActionVariable] = act.ActionValue;
                            }
                            foreach (ExpectedResult ex in tc.expectedresult)
                            {
                                dr[ex.ResultVariable] = ex.ResultValue;
                            }
                            dr["Time"] = tc.Withintime;
                            table.Rows.Add(dr);
                        }
                    }
                }            
            }
            AbstractTestcasesGen ab = new AbstractTestcasesGen();
            TestCaseModel test = new TestCaseModel();
            if (SharedDataClass.GetOption() == 1 || SharedDataClass.GetOption() == 3)
            {
                test = ab.OptimizeAbstractTestcases(SharedDataClass.GetTestcases(), SharedDataClass.GetSignal());
            }
            else if (SharedDataClass.GetOption() == 2)
            {
                test = SharedDataClass.GetTestCaseModel();
            }

            if (SharedDataClass.GetOption() == 1 || SharedDataClass.GetOption() == 2 || SharedDataClass.GetOption() == 3)
            {
                foreach (Testcase tes in test.testcases)
                {
                   
                    DataRow dr = table.NewRow();
                    dr["Test Case ID"] = tes.TestcaseID;
                    foreach (TestActions act in tes.action)
                    {
                        dr[act.ActionVariable] = act.ActionValue;
                    }
                    foreach (ExpectedResult ex in tes.expectedresult)
                    {
                        dr[ex.ResultVariable] = ex.ResultValue;
                    }
                    dr["Time"] = tes.Withintime;
                    table.Rows.Add(dr);
                }
            }
           
            return table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // creating Excel Application  
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            // see the excel sheet behind the program  
            app.Visible = true;
            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            // changing the name of active sheet  
            worksheet.Name = "Exported from gridview";
            // storing header part in Excel  
            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                }
            }
            string path= SharedDataClass.GetAbstractCasesJsonFilePath();
            // save the application  
            workbook.SaveAs(SharedDataClass.GetAbstractCasesJsonFilePath() + "TestCases", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // Exit from the application  
            app.Quit();
        }
    }
}
