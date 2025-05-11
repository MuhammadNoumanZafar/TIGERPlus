namespace TestScriptGeneration
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.filepath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btBrowse = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btGenerateTC = new System.Windows.Forms.Button();
            this.txtDestFolder = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btSelectFolder = new System.Windows.Forms.Button();
            this.pathgenerator = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.stoppingCondition = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btTestScriptGen = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMappingFile = new System.Windows.Forms.TextBox();
            this.bt_MappingFile = new System.Windows.Forms.Button();
            this.txtDestTS = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // filepath
            // 
            this.filepath.Location = new System.Drawing.Point(260, 236);
            this.filepath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.filepath.Name = "filepath";
            this.filepath.ReadOnly = true;
            this.filepath.Size = new System.Drawing.Size(508, 22);
            this.filepath.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 238);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Model File (RA, RS, RO):";
            // 
            // btBrowse
            // 
            this.btBrowse.Location = new System.Drawing.Point(774, 236);
            this.btBrowse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btBrowse.Name = "btBrowse";
            this.btBrowse.Size = new System.Drawing.Size(105, 23);
            this.btBrowse.TabIndex = 2;
            this.btBrowse.Text = "Browse";
            this.btBrowse.UseVisualStyleBackColor = true;
            this.btBrowse.Click += new System.EventHandler(this.btBrowse_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btGenerateTC
            // 
            this.btGenerateTC.Location = new System.Drawing.Point(258, 522);
            this.btGenerateTC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btGenerateTC.Name = "btGenerateTC";
            this.btGenerateTC.Size = new System.Drawing.Size(241, 25);
            this.btGenerateTC.TabIndex = 3;
            this.btGenerateTC.Text = "Generate JSON Format Test Cases";
            this.btGenerateTC.UseVisualStyleBackColor = true;
            this.btGenerateTC.Click += new System.EventHandler(this.btGenerateTC_Click);
            // 
            // txtDestFolder
            // 
            this.txtDestFolder.Location = new System.Drawing.Point(405, 394);
            this.txtDestFolder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDestFolder.Name = "txtDestFolder";
            this.txtDestFolder.ReadOnly = true;
            this.txtDestFolder.Size = new System.Drawing.Size(364, 22);
            this.txtDestFolder.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 397);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(333, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Path to Select/Save Abstract Test Cases (RA, RS, RO):";
            // 
            // btSelectFolder
            // 
            this.btSelectFolder.Location = new System.Drawing.Point(773, 394);
            this.btSelectFolder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btSelectFolder.Name = "btSelectFolder";
            this.btSelectFolder.Size = new System.Drawing.Size(105, 23);
            this.btSelectFolder.TabIndex = 6;
            this.btSelectFolder.Text = "Select Folder";
            this.btSelectFolder.UseVisualStyleBackColor = true;
            this.btSelectFolder.Click += new System.EventHandler(this.btSelectFolder_Click);
            // 
            // pathgenerator
            // 
            this.pathgenerator.FormattingEnabled = true;
            this.pathgenerator.Items.AddRange(new object[] {
            "random",
            "quick_random"});
            this.pathgenerator.Location = new System.Drawing.Point(260, 277);
            this.pathgenerator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pathgenerator.Name = "pathgenerator";
            this.pathgenerator.Size = new System.Drawing.Size(201, 24);
            this.pathgenerator.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 281);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Path Generator (RA):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 320);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Stopping Condition (RA):";
            // 
            // stoppingCondition
            // 
            this.stoppingCondition.FormattingEnabled = true;
            this.stoppingCondition.Items.AddRange(new object[] {
            "edge_coverage(100)",
            "vertex_coverage(100)",
            "requirement_coverage(100)",
            "length(100)"});
            this.stoppingCondition.Location = new System.Drawing.Point(258, 317);
            this.stoppingCondition.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stoppingCondition.Name = "stoppingCondition";
            this.stoppingCondition.Size = new System.Drawing.Size(157, 24);
            this.stoppingCondition.TabIndex = 10;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Excluding Test Data",
            "Include Test Data"});
            this.comboBox1.Location = new System.Drawing.Point(258, 353);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(205, 24);
            this.comboBox1.TabIndex = 12;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(469, 356);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(271, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "(Select include test data if generating scripts)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 355);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(202, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "Level of Detail in test cases (RA):";
            // 
            // btTestScriptGen
            // 
            this.btTestScriptGen.Location = new System.Drawing.Point(525, 522);
            this.btTestScriptGen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btTestScriptGen.Name = "btTestScriptGen";
            this.btTestScriptGen.Size = new System.Drawing.Size(243, 23);
            this.btTestScriptGen.TabIndex = 16;
            this.btTestScriptGen.Text = "Generate C# Test Script";
            this.btTestScriptGen.UseVisualStyleBackColor = true;
            this.btTestScriptGen.Click += new System.EventHandler(this.btTestScriptGen_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 439);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(192, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = "Signals Mapping File (RS, RO):";
            // 
            // txtMappingFile
            // 
            this.txtMappingFile.Location = new System.Drawing.Point(258, 436);
            this.txtMappingFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMappingFile.Name = "txtMappingFile";
            this.txtMappingFile.ReadOnly = true;
            this.txtMappingFile.Size = new System.Drawing.Size(509, 22);
            this.txtMappingFile.TabIndex = 18;
            // 
            // bt_MappingFile
            // 
            this.bt_MappingFile.Location = new System.Drawing.Point(773, 436);
            this.bt_MappingFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bt_MappingFile.Name = "bt_MappingFile";
            this.bt_MappingFile.Size = new System.Drawing.Size(105, 23);
            this.bt_MappingFile.TabIndex = 19;
            this.bt_MappingFile.Text = "Browse";
            this.bt_MappingFile.UseVisualStyleBackColor = true;
            this.bt_MappingFile.Click += new System.EventHandler(this.bt_MappingFile_Click);
            // 
            // txtDestTS
            // 
            this.txtDestTS.Location = new System.Drawing.Point(258, 477);
            this.txtDestTS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDestTS.Name = "txtDestTS";
            this.txtDestTS.ReadOnly = true;
            this.txtDestTS.Size = new System.Drawing.Size(509, 22);
            this.txtDestTS.TabIndex = 20;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(773, 477);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "Select Folder";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(35, 482);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(175, 16);
            this.label8.TabIndex = 22;
            this.label8.Text = "Destination Folder (RS, RO):";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(309, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(340, 108);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(525, 563);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(243, 26);
            this.button2.TabIndex = 24;
            this.button2.Text = "Generate Decision Table for TC";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(260, 565);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(241, 23);
            this.button3.TabIndex = 25;
            this.button3.Text = "Generate Minimized Test Suite";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "and",
            "or"});
            this.comboBox2.Location = new System.Drawing.Point(429, 317);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(74, 24);
            this.comboBox2.TabIndex = 26;
            this.comboBox2.Text = "Optional";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "edge_coverage(100)",
            "vertex_coverage(100)",
            "requirement_coverage(100)",
            "length(100)",
            "timeduration (15)",
            "timeduration (30)",
            "timeduration (60)",
            "timeduration (100)",
            "timeduration (200)",
            "timeduration (300)",
            "timeduration (400)",
            "timeduration (500)"});
            this.comboBox3.Location = new System.Drawing.Point(514, 317);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(157, 24);
            this.comboBox3.TabIndex = 27;
            this.comboBox3.Text = "Optional";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(310, 199);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(248, 16);
            this.label9.TabIndex = 28;
            this.label9.Text = "Selected GraphWalker CLI Version (AR):";
            // 
            // comboBox4
            // 
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "random",
            "quick_random"});
            this.comboBox4.Location = new System.Drawing.Point(580, 196);
            this.comboBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(298, 24);
            this.comboBox4.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(35, 138);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(834, 16);
            this.label10.TabIndex = 30;
            this.label10.Text = "Note: Requied fields for abstract test case generation, script generation, and op" +
    "timization are indicated by (RA), (RS), and (RO), respectively.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(77, 154);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(703, 16);
            this.label11.TabIndex = 31;
            this.label11.Text = "The name of model file and test cases generated from it should be the same for te" +
    "st script generation and optimization.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 623);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtDestTS);
            this.Controls.Add(this.bt_MappingFile);
            this.Controls.Add(this.txtMappingFile);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btTestScriptGen);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.stoppingCondition);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pathgenerator);
            this.Controls.Add(this.btSelectFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDestFolder);
            this.Controls.Add(this.btGenerateTC);
            this.Controls.Add(this.btBrowse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.filepath);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Model-based Test scrIpt GenEration fRamework and Optimizer (TIGER+)";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox filepath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btGenerateTC;
        private System.Windows.Forms.TextBox txtDestFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btSelectFolder;
        private System.Windows.Forms.ComboBox pathgenerator;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox stoppingCondition;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btTestScriptGen;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMappingFile;
        private System.Windows.Forms.Button bt_MappingFile;
        private System.Windows.Forms.TextBox txtDestTS;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}

