using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversityManagementSystem
{
    public partial class AdminPanel
    {
        List<Course> CourseList;
        SqlConnection con;
        List<Faculty> facultyList = new List<Faculty>();


        private void button6_Click(object sender, EventArgs e)
       {
          
            //Add Student On Insert Button
             con = new SqlConnection(@"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=universityManagementSystem;Integrated Security=True");
            try
            {

                SqlCommand cmd = new SqlCommand("Proc_AddStd", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                string value = ((KeyValuePair<string, string>)comboBox1.SelectedItem).Value;
                cmd.Parameters.AddWithValue("@Name", FNameTxt.Text);
                cmd.Parameters.AddWithValue("@DOB", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@AddedBy", userAccount.AccountID);
                cmd.Parameters.AddWithValue("@Username", Username.Text);
                cmd.Parameters.AddWithValue("@Password", Password.Text);
                cmd.Parameters.AddWithValue("@AccountType", "Student");
                cmd.Parameters.AddWithValue("@FName", LNameTxt.Text);
                cmd.Parameters.AddWithValue("@Department", value);
                cmd.Parameters.AddWithValue("@Qualification", qualification.Text);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            MessageBox.Show("Student Successfully Added !", "Successfully Added");
            Back(AdminStudentAddPanel, AdminStudentPanel);
        }
        public void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //Execute Query on Background
            try
            {
                studentLists = new List<Student>();
                departments = new List<Department>();
                CourseList = new List<Course>();
                facultyList = new List<Faculty>();
                SqlConnection con = new SqlConnection(@"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=universityManagementSystem;Integrated Security=True");
                SqlDataAdapter adapterStudents = new SqlDataAdapter("SELECT s.AccountID,u.Name,u.DOB,u.AddedBy,u.Username,u.password,u.AccountType,u.FName,s.StudentID,s.Department,s.Qualification FROM STUDENT s , UserAccount u where s.AccountID=u.AccountID", con);
                SqlDataAdapter adapterFaculty = new SqlDataAdapter("SELECT s.AccountID,u.Name,u.DOB,u.AddedBy,u.Username,u.password,u.AccountType,u.FName,s.FacultyID,s.Department,s.Qualification,s.Experience FROM Faculty s , UserAccount u where s.AccountID=u.AccountID", con);
                SqlDataAdapter adapterDepartments = new SqlDataAdapter("SELECT * FROM Department", con);
                SqlDataAdapter adapterCourse = new SqlDataAdapter("SELECT * FROM Course", con);

                DataSet ds = new DataSet();
                adapterStudents.Fill(ds, "Students");
                adapterDepartments.Fill(ds, "Departments");
                adapterCourse.Fill(ds, "Couse");
                adapterFaculty.Fill(ds,"Faculty");
                DataTable dtStd = ds.Tables["Students"];
                DataTable dtDep = ds.Tables["Departments"];
                DataTable dtCourse = ds.Tables["Couse"];
                DataTable dtFaculty = ds.Tables["Faculty"];

                foreach (DataRow dr in dtStd.Rows)
                {
                    studentLists.Add(new Student((int)dr[0], dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), (int)dr[8], dr[9].ToString(), dr[10].ToString()));
                }
                foreach (DataRow dr in dtDep.Rows)
                {
                    departments.Add(new Department((int)dr[0], dr[1].ToString(), dr[2].ToString(), dr[3].ToString()));
                }
                foreach (DataRow dr in dtCourse.Rows)
                {
                    CourseList.Add(new Course((int)dr[0]
                        , dr[1].ToString(), 
                        dr[2].ToString(),
                        dr[3].ToString(),dr[5].ToString(),dr[6].ToString(),
                        (int)dr[4]));
                }
                foreach (DataRow dr in dtFaculty.Rows)
                {
                    /*
        private int facultytID;
        private int department;
        private string qualification;
        private string experience;*/
        
                    facultyList.Add(new Faculty((int)dr[0],
                        dr[1].ToString(), 
                        dr[2].ToString(),
                        dr[3].ToString(),
                        
                        dr[4].ToString(),
                        dr[5].ToString(), 
                        dr[6].ToString(), 
                        dr[7].ToString(),
                        (int)dr[8],
                        (int) dr[9], 
                        dr[10].ToString()
                        ,dr[11].ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        { }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //When Background work is Completed
            var query = from dep in departments select new { DepName = dep.DepartmentName, DepID = dep.DepartmentID };

            DictionaryCombo = new Dictionary<string, string>();
            DictionaryCombo.Add("**SELECT DEPT**", "0");
            foreach (var deptNames in query)
            {
                DictionaryCombo.Add(deptNames.DepName.ToString(), deptNames.DepID.ToString());
            }
            comboBox1.DataSource = new BindingSource(DictionaryCombo, null);
            comboBox1.DisplayMember = "Key";
            comboBox1.ValueMember = "Value";
            AddFaculty_DepartmentCombo.DataSource = new BindingSource(DictionaryCombo, null);
            AddFaculty_DepartmentCombo.DisplayMember = "Key";
            AddFaculty_DepartmentCombo.ValueMember = "Value";
            AddCourse_DeptCombo.DataSource = new BindingSource(DictionaryCombo, null);
            AddCourse_DeptCombo.DisplayMember = "Key";
            AddCourse_DeptCombo.ValueMember = "Value";

            UpdateCourse_DeptCombo.DataSource = new BindingSource(DictionaryCombo, null);
            UpdateCourse_DeptCombo.DisplayMember = "Key";
            UpdateCourse_DeptCombo.ValueMember = "Value";
            


            Faculty_UpdateDep.DataSource = new BindingSource(DictionaryCombo, null);
            Faculty_UpdateDep.DisplayMember = "Key";
            Faculty_UpdateDep.ValueMember = "Value";

        }


        private void btn4_Click(object sender, EventArgs e)
        {
            //StudentPanel To Student-View/Modify Panel
            Back(AdminStudentPanel, AdminStudentShow);
            //Load Student GridView
            dtSource = new DataTable();
            try
            {
                dtSource.Columns.Add("StudentID");
                dtSource.Columns.Add("Name");
                dtSource.Columns.Add("FName");
                dtSource.Columns.Add("DOB");
                dtSource.Columns.Add("Department");
                dtSource.Columns.Add("Username");
                dtSource.Columns.Add("AddedBy");
                dtSource.Columns.Add("AccountType");
                dtSource.Columns.Add("Qualification");
                foreach (var item in studentLists)
                {
                    var dr = dtSource.NewRow();
                    dr["StudentID"] = item.StudentID;
                    dr["Name"] = item.Name;
                    dr["FName"] = item.FName1;
                    dr["DOB"] = item.DOB;
                    dr["Department"] = item.Department;
                    dr["AddedBy"] = item.AddedBy;
                    dr["AccountType"] = item.AccountType;
                    dr["Username"] = item.Username;
                    dr["Qualification"] = item.Qualification;
                    dtSource.Rows.Add(dr);
                }
                dataGridView1.DataSource = dtSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //Search Button For Filtering Students in Gridview
            filteredList = new List<Student>();
            int index = comboBox2.SelectedIndex;

            try
            {
                switch (index)
                {
                    case 0:
                        return;

                    case 1:
                        var studentsID = from std in studentLists where std.studentID == int.Parse(filter.Text) select std;
                        filterGridView(studentsID);
                        break;
                    case 2:
                        var studentsName = from std in studentLists where std.Name.ToUpper().Contains(filter.Text.ToUpper()) select std;
                        filterGridView(studentsName);
                        break;
                    case 3:
                        var studentsFName = from std in studentLists where std.FName1.ToUpper().Contains(filter.Text.ToUpper()) select std;
                        filterGridView(studentsFName);
                        break;
                    case 4:
                        var studentsDept = from std in studentLists where std.Department.ToUpper().Contains(filter.Text.ToUpper()) select std;
                        filterGridView(studentsDept);
                        break;
                    case 5:
                        var studentsUser = from std in studentLists where std.Username.ToUpper().Contains(filter.Text.ToUpper()) select std;
                        filterGridView(studentsUser);
                        break;
                    default: MessageBox.Show("Student Not Found!"); StudentGridViewReload(); break;
                }
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(ex.Message + ", Please Enter Correct StudentID");
                StudentGridViewReload();
            }
        }

        private void filterGridView(IEnumerable<Student> students)
        {
            DataTable dt = new DataTable();
            dataGridView1.DataSource = dt;
            dt.Columns.Add("StudentID");
            dt.Columns.Add("Name");
            dt.Columns.Add("FName");
            dt.Columns.Add("DOB");
            dt.Columns.Add("Department");
            dt.Columns.Add("Username");
            dt.Columns.Add("AddedBy");
            dt.Columns.Add("AccountType");
            dt.Columns.Add("Qualification");
            foreach (var item in students)
            {
                var dr = dt.NewRow();
                dr["StudentID"] = item.StudentID;
                dr["Name"] = item.Name;
                dr["FName"] = item.FName1;
                dr["DOB"] = item.DOB;
                dr["Department"] = item.Department;
                dr["AddedBy"] = item.AddedBy;
                dr["AccountType"] = item.AccountType;
                dr["Username"] = item.Username;
                dr["Qualification"] = item.Qualification;
                dt.Rows.Add(dr);
            }
            dataGridView1.DataSource = dt;

        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            //Reload Button For GridView
            StudentGridViewReload();
        }
        private void StudentGridViewReload()
        {

            comboBox2.SelectedIndex = 0;
            filter.Text = "";
            dataGridView1.DataSource = dtSource;
        }
        private void button10_Click(object sender, EventArgs e)
        {
            //Admin Student View To Student Panel
            Back(AdminStudentShow, AdminStudentPanel);
        }



        private void UpdateBt_Click(object sender, EventArgs e)
        {
            //Student Update Button
            string val = "" + dataGridView1.SelectedCells[0].Value;
            SqlConnection con = new SqlConnection(@"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=universityManagementSystem;Integrated Security=True");
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("proc_updateStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                string value = ((KeyValuePair<string, string>)DepartmentComboUpdate.SelectedItem).Value;
                cmd.Parameters.AddWithValue("@Name", UpdateName.Text);
                cmd.Parameters.AddWithValue("@DOB", DOBUpdate.Text);
                cmd.Parameters.AddWithValue("@Username", UsernameUpdate.Text);
                cmd.Parameters.AddWithValue("@FName", FNameUpdate.Text);
                cmd.Parameters.AddWithValue("@Department", value);
                cmd.Parameters.AddWithValue("@Qualification", QualificationUpdate.Text);
                cmd.Parameters.AddWithValue("@StudentID", val);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Student Record Updated");
                backgroundWorker1.RunWorkerAsync();
                btn4_Click(sender, e);
                StudentGridViewReload();
                Back(AdminStudentShow, AdminStudentPanel);



            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Student GridView Row Click
            try
            {
                int SelectedIndex = int.Parse("" + dataGridView1.SelectedCells[0].Value);
                var query = from std in studentLists where std.studentID == SelectedIndex select std;
                string department = "";
                foreach (var a in query)
                {
                    UpdateName.Text = a.Name;
                    FNameUpdate.Text = a.FName1;
                    DOBUpdate.Text = a.DOB;
                    UsernameUpdate.Text = a.Username;
                    QualificationUpdate.Text = a.Qualification;
                    department = a.Department;
                }
                var queryDep = from dep in departments select new { DepName = dep.DepartmentName, DepID = dep.DepartmentID };

                DictionaryCombo = new Dictionary<string, string>();
                DictionaryCombo.Add("**SELECT DEPT**", "0");
                int i = 1, dptComboboxIndex = 0;
                foreach (var deptNames in queryDep)
                {
                    DictionaryCombo.Add(deptNames.DepName.ToString(), deptNames.DepID.ToString());
                    if (deptNames.DepID.ToString().Equals(department))
                        dptComboboxIndex = i;
                    i++;
                }
                DepartmentComboUpdate.DataSource = new BindingSource(DictionaryCombo, null);
                DepartmentComboUpdate.DisplayMember = "Key";
                DepartmentComboUpdate.ValueMember = "Value";
                DepartmentComboUpdate.SelectedIndex = dptComboboxIndex;
            }
            catch (Exception) { }

        }
       private void addStud_Click(object sender, EventArgs e)
        {
            AdminStudentAddPanel.Visible = true;
            AdminStudentPanel.Visible = false;
            //     backgroundWorker1.RunWorkerAsync();
        }
        private void button5_Click(object sender, EventArgs e)
        { //Admin Student Panel Back Button
            Back(AdminStudentPanel, AdminMainPanel);
        }
     private void button5_Click_3(object sender, EventArgs e)
        {  //Admin Student Panel Back Button
            Back(AdminStudentPanel, AdminMainPanel);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            //Student-Add panel To Student Panel
            Back(AdminStudentAddPanel, AdminStudentPanel);
        }
        public void Back(Panel currentPanel, Panel prevPanel)
        {
            currentPanel.Visible = false;
            prevPanel.Visible = true;
        }


        private void AdminPanel_Load(object sender, EventArgs e)
        {
            AdminStudentPanel.Visible = false;
            AdminStudentShow.Visible = false;
            AccountName.Text = userAccount.Name;
            comboBox1.SelectedIndex = 0;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void button1_Click(object sender, EventArgs e) { }


        private void Students_Click(object sender, EventArgs e)
        {
            //ON Student Button Click 
            AdminStudentPanel.Visible = true;
            AdminMainPanel.Visible = false;
            backgroundWorker1.RunWorkerAsync();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        

        private void AdminStudentShow_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click1(object sender, EventArgs e)
        {
            Back(AdminStudentShow, RegisterStudentCourse);
            int SelectedIndex = int.Parse("" + dataGridView1.SelectedCells[0].Value);
            SqlDataAdapter adapterCourseList = new SqlDataAdapter("SELECT CourseID,CourseName,Date,Timings FROM Course WHERE CourseID  NOT IN(SELECT CourseCode FROM Enrollment where StudentID = '" + SelectedIndex + "') AND DepartmentID = (SELECT Department From Student where StudentID = '" + SelectedIndex + "')", @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=universityManagementSystem;Integrated Security=True");
            DataSet ds = new DataSet();
            adapterCourseList.Fill(ds, "CourseList");
            DataTable dt = new DataTable();
            dt = ds.Tables["CourseList"];
            CourseListGrid.DataSource = dt;




        }

        private void RegisterStudentCourse_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            int SelectedIndex = int.Parse("" + CourseListGrid.SelectedCells[0].Value);
            var conn = new SqlConnection(@"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=universityManagementSystem;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("INSERT INTO Enrollment (CourseCode,StudentID) VALUES('" + SelectedIndex + "','" + dataGridView1.SelectedCells[0].Value + "')", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            Back(RegisterStudentCourse, AdminStudentShow);

        }

        private void button13_Click(object sender, EventArgs e)
        {

            Back(RegisterStudentCourse, AdminStudentShow);
        }

    }
}
