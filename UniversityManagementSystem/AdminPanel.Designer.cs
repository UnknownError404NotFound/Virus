namespace UniversityManagementSystem
{
    partial class AdminPanel
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
            this.AdminMainPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.Students = new System.Windows.Forms.Button();
            this.Faculty = new System.Windows.Forms.Button();
            this.Attendance = new System.Windows.Forms.Button();
            this.Courses = new System.Windows.Forms.Button();
            this.Department = new System.Windows.Forms.Button();
            this.Marks = new System.Windows.Forms.Button();
            this.NameLbl = new System.Windows.Forms.Label();
            this.AccountName = new System.Windows.Forms.Label();
            this.AdminStudentPanel = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.AdminStudentAddPanel = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FNameTxt = new System.Windows.Forms.TextBox();
            this.LNameTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Username = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.qualification = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.AdminMainPanel.SuspendLayout();
            this.AdminStudentPanel.SuspendLayout();
            this.AdminStudentAddPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // AdminMainPanel
            // 
            this.AdminMainPanel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.AdminMainPanel.Controls.Add(this.AccountName);
            this.AdminMainPanel.Controls.Add(this.NameLbl);
            this.AdminMainPanel.Controls.Add(this.Marks);
            this.AdminMainPanel.Controls.Add(this.Department);
            this.AdminMainPanel.Controls.Add(this.Courses);
            this.AdminMainPanel.Controls.Add(this.Attendance);
            this.AdminMainPanel.Controls.Add(this.Faculty);
            this.AdminMainPanel.Controls.Add(this.Students);
            this.AdminMainPanel.Controls.Add(this.button1);
            this.AdminMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AdminMainPanel.Location = new System.Drawing.Point(0, 0);
            this.AdminMainPanel.Name = "AdminMainPanel";
            this.AdminMainPanel.Size = new System.Drawing.Size(784, 461);
            this.AdminMainPanel.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(691, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 21);
            this.button1.TabIndex = 0;
            this.button1.Text = "Logout";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Students
            // 
            this.Students.Location = new System.Drawing.Point(96, 115);
            this.Students.Name = "Students";
            this.Students.Size = new System.Drawing.Size(100, 100);
            this.Students.TabIndex = 1;
            this.Students.Text = "Students";
            this.Students.UseVisualStyleBackColor = true;
            this.Students.Click += new System.EventHandler(this.Students_Click);
            // 
            // Faculty
            // 
            this.Faculty.Location = new System.Drawing.Point(241, 115);
            this.Faculty.Name = "Faculty";
            this.Faculty.Size = new System.Drawing.Size(100, 100);
            this.Faculty.TabIndex = 2;
            this.Faculty.Text = "Faculty";
            this.Faculty.UseVisualStyleBackColor = true;
            this.Faculty.Click += new System.EventHandler(this.Faculty_Click);
            // 
            // Attendance
            // 
            this.Attendance.Location = new System.Drawing.Point(399, 115);
            this.Attendance.Name = "Attendance";
            this.Attendance.Size = new System.Drawing.Size(100, 100);
            this.Attendance.TabIndex = 3;
            this.Attendance.Text = "Attendance";
            this.Attendance.UseVisualStyleBackColor = true;
            // 
            // Courses
            // 
            this.Courses.Location = new System.Drawing.Point(554, 115);
            this.Courses.Name = "Courses";
            this.Courses.Size = new System.Drawing.Size(100, 100);
            this.Courses.TabIndex = 4;
            this.Courses.Text = "Courses";
            this.Courses.UseVisualStyleBackColor = true;
            // 
            // Department
            // 
            this.Department.Location = new System.Drawing.Point(241, 242);
            this.Department.Name = "Department";
            this.Department.Size = new System.Drawing.Size(100, 100);
            this.Department.TabIndex = 5;
            this.Department.Text = "Department";
            this.Department.UseVisualStyleBackColor = true;
            // 
            // Marks
            // 
            this.Marks.Location = new System.Drawing.Point(399, 242);
            this.Marks.Name = "Marks";
            this.Marks.Size = new System.Drawing.Size(100, 100);
            this.Marks.TabIndex = 6;
            this.Marks.Text = "Marks";
            this.Marks.UseVisualStyleBackColor = true;
            // 
            // NameLbl
            // 
            this.NameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLbl.Location = new System.Drawing.Point(569, 18);
            this.NameLbl.Name = "NameLbl";
            this.NameLbl.Size = new System.Drawing.Size(60, 14);
            this.NameLbl.TabIndex = 7;
            this.NameLbl.Text = "Welcome";
            this.NameLbl.Click += new System.EventHandler(this.NameLbl_Click);
            // 
            // AccountName
            // 
            this.AccountName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountName.Location = new System.Drawing.Point(625, 18);
            this.AccountName.Name = "AccountName";
            this.AccountName.Size = new System.Drawing.Size(60, 65);
            this.AccountName.TabIndex = 8;
            this.AccountName.Click += new System.EventHandler(this.AccountName_Click);
            // 
            // AdminStudentPanel
            // 
            this.AdminStudentPanel.BackColor = System.Drawing.SystemColors.Menu;
            this.AdminStudentPanel.Controls.Add(this.button5);
            this.AdminStudentPanel.Controls.Add(this.button4);
            this.AdminStudentPanel.Controls.Add(this.button3);
            this.AdminStudentPanel.Controls.Add(this.button2);
            this.AdminStudentPanel.Location = new System.Drawing.Point(2, 3);
            this.AdminStudentPanel.Name = "AdminStudentPanel";
            this.AdminStudentPanel.Size = new System.Drawing.Size(781, 455);
            this.AdminStudentPanel.TabIndex = 11;
            this.AdminStudentPanel.Visible = false;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(21, 15);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(52, 26);
            this.button5.TabIndex = 3;
            this.button5.Text = "Back";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(517, 157);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 100);
            this.button4.TabIndex = 2;
            this.button4.Text = "Show All Students";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(347, 157);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 100);
            this.button3.TabIndex = 1;
            this.button3.Text = "Modify Student";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(174, 157);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 100);
            this.button2.TabIndex = 0;
            this.button2.Text = "Add Student";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // AdminStudentAddPanel
            // 
            this.AdminStudentAddPanel.Controls.Add(this.button6);
            this.AdminStudentAddPanel.Controls.Add(this.qualification);
            this.AdminStudentAddPanel.Controls.Add(this.label8);
            this.AdminStudentAddPanel.Controls.Add(this.comboBox1);
            this.AdminStudentAddPanel.Controls.Add(this.dateTimePicker1);
            this.AdminStudentAddPanel.Controls.Add(this.label7);
            this.AdminStudentAddPanel.Controls.Add(this.Password);
            this.AdminStudentAddPanel.Controls.Add(this.label6);
            this.AdminStudentAddPanel.Controls.Add(this.Username);
            this.AdminStudentAddPanel.Controls.Add(this.label5);
            this.AdminStudentAddPanel.Controls.Add(this.label4);
            this.AdminStudentAddPanel.Controls.Add(this.LNameTxt);
            this.AdminStudentAddPanel.Controls.Add(this.label3);
            this.AdminStudentAddPanel.Controls.Add(this.FNameTxt);
            this.AdminStudentAddPanel.Controls.Add(this.label2);
            this.AdminStudentAddPanel.Controls.Add(this.label1);
            this.AdminStudentAddPanel.Location = new System.Drawing.Point(5, 3);
            this.AdminStudentAddPanel.Name = "AdminStudentAddPanel";
            this.AdminStudentAddPanel.Size = new System.Drawing.Size(778, 458);
            this.AdminStudentAddPanel.TabIndex = 13;
            this.AdminStudentAddPanel.Visible = false;
            this.AdminStudentAddPanel.Click += new System.EventHandler(this.AdminStudentAddPanel_Click);
            this.AdminStudentAddPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.AdminStudentAddPanel_Paint);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(296, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add Students";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(269, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "First Name";
            // 
            // FNameTxt
            // 
            this.FNameTxt.Location = new System.Drawing.Point(360, 86);
            this.FNameTxt.Name = "FNameTxt";
            this.FNameTxt.Size = new System.Drawing.Size(144, 20);
            this.FNameTxt.TabIndex = 2;
            // 
            // LNameTxt
            // 
            this.LNameTxt.Location = new System.Drawing.Point(360, 128);
            this.LNameTxt.Name = "LNameTxt";
            this.LNameTxt.Size = new System.Drawing.Size(144, 20);
            this.LNameTxt.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(269, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Last Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(269, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "DOB";
            // 
            // Username
            // 
            this.Username.Location = new System.Drawing.Point(361, 214);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(144, 20);
            this.Username.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(270, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Username";
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(361, 258);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(144, 20);
            this.Password.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(270, 261);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Password";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(269, 306);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Department";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(360, 166);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(144, 20);
            this.dateTimePicker1.TabIndex = 13;
            this.dateTimePicker1.Value = new System.DateTime(2018, 4, 3, 21, 37, 31, 0);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "**Select Dept**"});
            this.comboBox1.Location = new System.Drawing.Point(361, 303);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(143, 21);
            this.comboBox1.TabIndex = 14;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(268, 349);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Intermediate";
            // 
            // qualification
            // 
            this.qualification.Location = new System.Drawing.Point(361, 346);
            this.qualification.Name = "qualification";
            this.qualification.Size = new System.Drawing.Size(143, 20);
            this.qualification.TabIndex = 16;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(361, 403);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 17;
            this.button6.Text = "Add";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // AdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.AdminStudentAddPanel);
            this.Controls.Add(this.AdminStudentPanel);
            this.Controls.Add(this.AdminMainPanel);
            this.Name = "AdminPanel";
            this.Text = "AdminPanel";
            this.Load += new System.EventHandler(this.AdminPanel_Load);
            this.AdminMainPanel.ResumeLayout(false);
            this.AdminStudentPanel.ResumeLayout(false);
            this.AdminStudentAddPanel.ResumeLayout(false);
            this.AdminStudentAddPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel AdminMainPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Courses;
        private System.Windows.Forms.Button Attendance;
        private System.Windows.Forms.Button Faculty;
        private System.Windows.Forms.Button Students;
        private System.Windows.Forms.Button Marks;
        private System.Windows.Forms.Button Department;
        private System.Windows.Forms.Label NameLbl;
        private System.Windows.Forms.Label AccountName;
        private System.Windows.Forms.Panel AdminStudentPanel;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel AdminStudentAddPanel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Username;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox LNameTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox FNameTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox qualification;
        private System.Windows.Forms.Label label8;
    }
}