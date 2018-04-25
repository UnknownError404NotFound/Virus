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
    public partial class AdminPanel : Form
    {
        public static Account  userAccount;
        public static List<Student> studentLists;
        public static List<Department> departments;
        public static List<Student> filteredList;
        Dictionary<string, string> DictionaryCombo;
        public static DataTable dtSource;
        public AdminPanel()
        {
            InitializeComponent();

            comboBox3.SelectedIndex = 0;
            backgroundWorker1.RunWorkerAsync();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Back(AdminFacultyPanel,FacultyAdd);
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            Back(FacultyAdd, AdminFacultyPanel);
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

        }

        private void Button21_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=universityManagementSystem;Integrated Security=True");
            try
            {

                SqlCommand cmd = new SqlCommand("Proc_AddFaculty", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                string value = ((KeyValuePair<string, string>)AddFaculty_DepartmentCombo.SelectedItem).Value;
                cmd.Parameters.AddWithValue("@Name", AddFaculty_Name.Text);
                cmd.Parameters.AddWithValue("@DOB", AddFaculty_DOB.Text);
                cmd.Parameters.AddWithValue("@AddedBy", userAccount.AccountID);
                cmd.Parameters.AddWithValue("@Username", AddFaculty_Username.Text);
                cmd.Parameters.AddWithValue("@Password", AddFaculty_Password.Text);
                cmd.Parameters.AddWithValue("@AccountType", "Faculty");
                cmd.Parameters.AddWithValue("@FName", AddFaculty_FName.Text);
                cmd.Parameters.AddWithValue("@Department", value);
                cmd.Parameters.AddWithValue("@Qualification", AddFaculty_Qualification.Text);
                cmd.Parameters.AddWithValue("@AreaOfWork", AddFaculty_AreaOfWork.Text);
                cmd.Parameters.AddWithValue("@Experience", AddFaculty_Exp.Text);
                cmd.ExecuteNonQuery();
                backgroundWorker1.RunWorkerAsync();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            MessageBox.Show("Faculty Successfully Added !", "Successfully Added");
            Back(FacultyAdd, AdminFacultyPanel);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            //StudentPanel To Student-View/Modify Panel
            Back(AdminFacultyPanel, FacultyList);
            //Load Student GridView
            dtSource = new DataTable();
            try
            {
                dtSource.Columns.Add("FacultyID");
                dtSource.Columns.Add("Name");
                dtSource.Columns.Add("FName");
                dtSource.Columns.Add("DOB");
                dtSource.Columns.Add("Department");
                dtSource.Columns.Add("Username");
                dtSource.Columns.Add("AddedBy");
                dtSource.Columns.Add("AccountType");
                dtSource.Columns.Add("Qualification");
                dtSource.Columns.Add("Experience");
                foreach (var item in facultyList)
                {
                    var dr = dtSource.NewRow();
                    dr["FacultyID"] = item.FacultytID;
                    dr["Name"] = item.Name;
                    dr["FName"] = item.FName1;
                    dr["DOB"] = item.DOB;
                    dr["Department"] = item.Department;
                    dr["AddedBy"] = item.AddedBy;
                    dr["AccountType"] = item.AccountType;
                    dr["Username"] = item.Username;
                    dr["Qualification"] = item.Qualification;
                    dr["Experience"] = item.Experience;
                    dtSource.Rows.Add(dr);
                }
                dataGridView2.DataSource = dtSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {
            //Student Update Button
            string val = "" + dataGridView2.SelectedCells[0].Value;
            SqlConnection con = new SqlConnection(@"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=universityManagementSystem;Integrated Security=True");
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("proc_updateFaculty", con);
                cmd.CommandType = CommandType.StoredProcedure;
                string value = ((KeyValuePair<string, string>)Faculty_UpdateDep.SelectedItem).Value;
                cmd.Parameters.AddWithValue("@Name", UpdateName.Text);
                cmd.Parameters.AddWithValue("@DOB", Faculty_UpdateDOB.Text);
                cmd.Parameters.AddWithValue("@Username", Faculty_UpdateUsername.Text);
                cmd.Parameters.AddWithValue("@FName", Faculty_UpdateFName.Text);
                cmd.Parameters.AddWithValue("@Department", value);
                cmd.Parameters.AddWithValue("@Qualification", Faculty_UpdateQualification.Text);
                cmd.Parameters.AddWithValue("@Experience", Faculty_UpdateExp.Text);
                cmd.Parameters.AddWithValue("@FacultyID", val);
                cmd.ExecuteNonQuery();
                con.Close();
       
                dataGridView2.Rows.Clear();
                backgroundWorker1.RunWorkerAsync();
                btn4_Click(sender, e);
            //    FacultyGridViewReload();
                Back(AdminStudentShow, AdminStudentPanel);



            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
        }
        private void FacultyGridViewReload()
        {
            Faculty_UpdateDep.SelectedIndex = 0;
            filter.Text = "";
            dataGridView2.DataSource = dtSource;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
              try
                {
                int SelectedIndex = int.Parse("" + dataGridView2.SelectedCells[0].Value);
                var query = from std in facultyList where std.FacultytID == SelectedIndex select std;
                int department = 0;
                foreach (var a in query)
                {
                    Faculty_UpdateNameTxt.Text = a.Name;
                    Faculty_UpdateFName.Text = a.FName1;
                    Faculty_UpdateDOB.Text = a.DOB;
                    Faculty_UpdateUsername.Text = a.Username;
                    Faculty_UpdateQualification.Text = a.Qualification;
                    Faculty_UpdateExp.Text = a.Experience;
                    department = a.Department;
                }
                var queryDep = from dep in departments select new { DepName = dep.DepartmentName, DepID = dep.DepartmentID };

                DictionaryCombo = new Dictionary<string, string>();
                DictionaryCombo.Add("**SELECT DEPT**", "0");
                int i = 1, dptComboboxIndex = 0;
                foreach (var deptNames in queryDep)
                {
                    DictionaryCombo.Add(deptNames.DepName.ToString(), deptNames.DepID.ToString());
                    if (deptNames.DepID.ToString().Equals(""+ department))
                        dptComboboxIndex = i;
                    i++;
                }
                Faculty_UpdateDep.DataSource = new BindingSource(DictionaryCombo, null);
                Faculty_UpdateDep.DisplayMember = "Key";
                Faculty_UpdateDep.ValueMember = "Value";
                Faculty_UpdateDep.SelectedIndex = dptComboboxIndex;
            }
            catch (Exception) { }

        }

        private void bunifuDropdown1_onItemSelected(object sender, EventArgs e)
        {

        }

        private void filterGridViewFaculty(IEnumerable<Faculty> faculty)
        {
            DataTable dt = new DataTable();
            dataGridView2.DataSource = dt;
            dt.Columns.Add("FacultyID");
            dt.Columns.Add("Name");
            dt.Columns.Add("FName");
            dt.Columns.Add("DOB");
            dt.Columns.Add("Department");
            dt.Columns.Add("Username");
            dt.Columns.Add("AddedBy");
            dt.Columns.Add("AccountType");
            dt.Columns.Add("Qualification");
            dt.Columns.Add("Exp");
            foreach (var item in faculty)
            {
                var dr = dt.NewRow();
                dr["FacultyID"] = item.FacultytID;
                dr["Name"] = item.Name;
                dr["FName"] = item.FName1;
                dr["DOB"] = item.DOB;
                dr["Department"] = item.Department;
                dr["AddedBy"] = item.AddedBy;
                dr["AccountType"] = item.AccountType;
                dr["Username"] = item.Username;
                dr["Qualification"] = item.Qualification;
                dr["Exp"] = item.Experience;
                dt.Rows.Add(dr);
            }
            dataGridView2.DataSource = dt;

        }

        private void FilterFaculty_Click(object sender, EventArgs e)
        {
            filteredList = new List<Student>();
            int index = comboBox3.SelectedIndex;

            try
            {
                switch (index)
                {
                    case 0:
                        return;

                    case 1:
                        var FacID = from std in facultyList where std.FacultytID == int.Parse(FacultySearchBox.Text) select std;
                        filterGridViewFaculty(FacID);
                        break;
                    case 2:
                        var FacName = from std in facultyList where std.Name.ToUpper().Contains(FacultySearchBox.Text.ToUpper()) select std;
                        filterGridViewFaculty(FacName);
                        break;
                    case 3:
                        var FacsFName = from std in facultyList where std.FName1.ToUpper().Contains(FacultySearchBox.Text.ToUpper()) select std;
                        filterGridViewFaculty(FacsFName);
                        break;
                    case 4:
                        var FacDept = from std in facultyList where std.Department==int.Parse(FacultySearchBox.Text) select std;
                        filterGridViewFaculty(FacDept);
                        break;
                    case 5:
                        var studentsUser = from std in facultyList where std.Username.ToUpper().Contains(FacultySearchBox.Text.ToUpper()) select std;
                        filterGridViewFaculty(studentsUser);
                        break;
                    default: MessageBox.Show("Faculty Not Found!"); StudentGridViewReload(); break;
                }
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(ex.Message + ", Please Enter Correct FacultyID");
                FacGridViewReload();
            }
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            FacGridViewReload();
        }
        private void FacGridViewReload()
        {
            backgroundWorker1.RunWorkerAsync();
            comboBox3.SelectedIndex = 0;
            FacultySearchBox.Text = "";
            dataGridView2.DataSource = dtSource;
        }


        private void AssignCourse_Click(object sender, EventArgs e)
        {

            Back( FacultyList, AssignCourseToFacultyPanel);
            try { 
            SqlConnection con = new SqlConnection(@"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=universityManagementSystem;Integrated Security=True");
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT SectionNo, CourseCode, s.Timings, c.CourseName FROM Section s, Course c  WHERE SectionNo NOT IN(SELECT SectionID FROM Section s, AssignedCourses a where s.SectionNo = a.SectionID) AND c.CourseID = s.CourseCode; ", con);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView3.DataSource = ds.Tables[0];
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            Back(FacultyList,AdminFacultyPanel);
        }

        private void button21_Click_1(object sender, EventArgs e)
        {

            int val = int.Parse( dataGridView2.SelectedCells[0].Value.ToString());
            try { 
            string query = "DELETE FROM Faculty Where FacultyID="+val;
                SqlConnection con = new SqlConnection(@"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=universityManagementSystem;Integrated Security=True");
                SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
                //  var itemToRemove = facultyList.SingleOrDefault(r => r.accountID == val);
                facultyList.RemoveAll(item => item.FacultytID == val);
                MessageBox.Show("Faculty Successfully Deleted!");
                Back(FacultyList, AdminFacultyPanel);
            }
            catch (Exception xe)
            {
                MessageBox.Show(xe.Message);
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            try { 
            SqlConnection con = new SqlConnection(@"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=universityManagementSystem;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("INSERT INTO AssignedCourses (FacultyID,AssignedBy,SectionID) VALUES('"+ dataGridView2.SelectedCells[0].Value + "','"+userAccount.AccountID+"','"+ dataGridView3.SelectedCells[0].Value + "')",con);
            con.Open();
                cmd.ExecuteNonQuery();
            con.Close();
                MessageBox.Show("Done");
                AssignCourse_Click(sender, e);
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {
            Back(AssignCourseToFacultyPanel, FacultyList);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Back(CoursePanel, CourseAddPanel);

        }

        private void bunifuThinButton27_Click(object sender, EventArgs e)
        {
            Back(CoursePanel,AdminMainPanel);
        }

        private void Courses_Click(object sender, EventArgs e)
        {
            Back(AdminMainPanel,CoursePanel);
        }


        //COURSE
        private void button24_Click(object sender, EventArgs e)
        {
            string value = ((KeyValuePair<string, string>)AddCourse_DeptCombo.SelectedItem).Value;

            try
            { 
            string query = "INSERT INTO Course (CourseName,CreditHour,DepartmentID,Timings,Date) VALUES('"+AddCourse_CourseNameTxt.Text+"','"+AddCourse_CreditHRTxt.Text+"','"+ value + "','"+AddCourse_Time.Text + "','"+AddCourse_Date.Text+"')";
            SqlConnection con = new SqlConnection(@"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=universityManagementSystem;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Done");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuThinButton28_Click(object sender, EventArgs e)
        {
            Back(CourseAddPanel,CoursePanel);
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int SelectedIndex = int.Parse("" + CourseGrid.SelectedCells[0].Value);
            int department = 0;
            var query = from std in CourseList where std.CourseID == SelectedIndex select std;
            foreach (var a in query)
            {
                CourseUpdate_CourseName.Text = a.CourseName;
                CourseUpdate_CrHR.Text = a.CreditHour;
                CourseUpdate_Date.Text = a.Date1;
                department = a.DepartmentID;
                CourseUpdate_Time.Text=a.Time;
            }
            var queryDep = from dep in departments select new { DepName = dep.DepartmentName, DepID = dep.DepartmentID };

            DictionaryCombo = new Dictionary<string, string>();
            DictionaryCombo.Add("**SELECT DEPT**", "0");
            int i = 1, dptComboboxIndex = 0;
            foreach (var deptNames in queryDep)
            {
                DictionaryCombo.Add(deptNames.DepName.ToString(), deptNames.DepID.ToString());
                if (deptNames.DepID.ToString().Equals("" + department))
                    dptComboboxIndex = i;
                i++;
            }
            UpdateCourse_DeptCombo.SelectedIndex = dptComboboxIndex;
        }

        private void button25_Click(object sender, EventArgs e)
        {
            string value = ((KeyValuePair<string, string>)UpdateCourse_DeptCombo.SelectedItem).Value;

            try
            {
                int val= int.Parse(""+CourseGrid.SelectedCells[0].Value);
                string query = "UPDATE Course SET CourseName='" + CourseUpdate_CourseName.Text + "',CreditHour='" + CourseUpdate_CrHR.Text + "',DepartmentID='" + value + "',Timings='" + CourseUpdate_Time.Text + "',Date='" + CourseUpdate_Date.Text + "' WHERE CourseID='" + val + "'";
                SqlConnection con = new SqlConnection(@"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=universityManagementSystem;Integrated Security=True");
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Done");
                Back(ShowCourses,CoursePanel);
                backgroundWorker1.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Back(CoursePanel,ShowCourses);
            dtSource = new DataTable();
            try
            {
                dtSource.Columns.Add("CouseID");
                dtSource.Columns.Add("CourseName");
                dtSource.Columns.Add("CreditHour");
                dtSource.Columns.Add("dateOfCreation");
                dtSource.Columns.Add("Department");
                dtSource.Columns.Add("Timing");
                dtSource.Columns.Add("Date");
                foreach (var item in CourseList)
                {
                    var dr = dtSource.NewRow();
                    dr["CouseID"] = item.CourseID;
                    dr["CourseName"] = item.CourseName;
                    dr["CreditHour"] = item.CreditHour;
                    dr["dateOfCreation"] = item.DateOfCreation;
                    dr["Department"] = item.DepartmentID;
                    dr["Timing"] = item.Time;
                    dr["Date"] = item.Date1;
                    dtSource.Rows.Add(dr);
                }
                CourseGrid.DataSource = dtSource;

            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuThinButton29_Click(object sender, EventArgs e)
        {

            Back(ShowCourses, CoursePanel);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            int val = int.Parse("" + CourseGrid.SelectedCells[0].Value);
            try
            {
             SqlConnection con = new SqlConnection(@"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=universityManagementSystem;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("DELETE From Course Where CourseID='"+ val + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Done");
                Back(ShowCourses, CoursePanel);
                backgroundWorker1.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuThinButton210_Click(object sender, EventArgs e)
        {
            Back(DepartmentPanel,AdminMainPanel );
        }

        private void Department_Click(object sender, EventArgs e)
        {
            Back(AdminMainPanel, DepartmentPanel);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            Back(DepartmentPanel,AddDepartment);
        }

        private void bunifuThinButton211_Click(object sender, EventArgs e)
        {
            Back(AddDepartment,DepartmentPanel);
        }

        private void button29_Click(object sender, EventArgs e)
        {
              try
            {
                SqlConnection con = new SqlConnection(@"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=universityManagementSystem;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("INSERT INTO Department (DepartmentName,HOD,AddedBy,CreationDate) VALUES('"+AddDep_DeptName.Text+"','"+AddDep_DeptHOD.Text+"','"+userAccount.AccountID+"','"+DateTime.Now+"')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Done");
                Back(AddDepartment, DepartmentPanel);
                backgroundWorker1.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuThinButton212_Click(object sender, EventArgs e)
        {
            Back(ModifyDeptPanel,DepartmentPanel);
        }

        private void label50_Click(object sender, EventArgs e)
        {

        }

        private void button28_Click(object sender, EventArgs e)
        {
            Back(DepartmentPanel,ModifyDeptPanel );

            dtSource = new DataTable();
            try
            {
                dtSource.Columns.Add("DepartmentID");
                dtSource.Columns.Add("DepartmentName");
                dtSource.Columns.Add("HeadOfDepartment");
                dtSource.Columns.Add("AddedBy");
                foreach (var item in departments)
                {
                    var dr = dtSource.NewRow();
                    dr["DepartmentID"] = item.DepartmentID;
                    dr["DepartmentName"] = item.DepartmentName;
                    dr["HeadOfDepartment"] = item.HOD;
                    dr["AddedBy"] = item.AddedBy;
                    dtSource.Rows.Add(dr);
                }
                DeptGrid.DataSource = dtSource;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView4_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int SelectedIndex = int.Parse("" + DeptGrid.SelectedCells[0].Value);
         
            var query = from std in departments where std.DepartmentID == SelectedIndex select std;
            foreach (var a in query)
            {
                Update_Dept_Name.Text = a.DepartmentName;
                Update_Dept_HOD.Text = a.HOD;
            }
         }

        private void button31_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=universityManagementSystem;Integrated Security=True");
                int val = int.Parse("" + DeptGrid.SelectedCells[0].Value);

                SqlCommand cmd = new SqlCommand("UPDATE Department SET DepartmentName='"+Update_Dept_Name.Text+"',HOD='"+Update_Dept_HOD.Text+"' where DepartmentID='"+val+"'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Done");
                Back(ModifyDeptPanel, DepartmentPanel);
                backgroundWorker1.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            int val = int.Parse("" + CourseGrid.SelectedCells[0].Value);
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=universityManagementSystem;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("DELETE FROM Department WHERE DepartmentID='"+ val + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Done");
                Back(ModifyDeptPanel, DepartmentPanel);
                backgroundWorker1.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Marks_Click(object sender, EventArgs e)
        {
            Back(AdminMainPanel,AddMarksPanel);
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
               AddMarks_StudentGrid.DataSource = dtSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuThinButton214_Click(object sender, EventArgs e)
        {
            Back(AddMarksPanel,AdminMainPanel);

        }

        private void bunifuThinButton213_Click(object sender, EventArgs e)
        {
            Back(AddMarksPanel,AddMarks_Student_SelectCoursePanel );
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
                AddMarks_StudentGrid.DataSource = dtSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //    Back();
        }

        private void bunifuThinButton215_Click(object sender, EventArgs e)
        {
            Back(AddMarks_Student_SelectCoursePanel,AddMarksPanel);
            var query = "SELECT CourseID, CourseName, CreditHour, Date, Timings FROM Course WHERE CourseID IN(SELECT CourseCode FROM Enrollment where StudentID = '"+ AddMarks_StudentGrid.SelectedCells[0].Value + "'); ";

            dtSource = new DataTable();
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=universityManagementSystem;Integrated Security=True");
                SqlDataAdapter adapter = new SqlDataAdapter(query,con);
                DataSet ds = new DataSet();
                adapter.Fill(ds);



                AddMarks_CourseGrid.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            }

        private void bunifuThinButton216_Click(object sender, EventArgs e)
        {
            Back(AddMarks_Student_SelectCoursePanel, AddMarks_Std_Course_Add_Panel);
            SqlConnection con = new SqlConnection(@"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=universityManagementSystem;Integrated Security=True");
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Marks Where CourseCode='"+AddMarks_CourseGrid.SelectedCells[0].Value+"' AND StudentID='"+AddMarks_StudentGrid.SelectedCells[0].Value + "'",con);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataTable table = ds.Tables[0];
            foreach(DataRow dr in table.Rows)
                
            {
                QuizAndAss.Text = "" + dr[0];
                ProjectMarks.Text = ""+dr[1];
                MidTerm.Text = "" + dr[2];
                FinalTerm.Text = "" + dr[3]; 
            }
        }

        private void AddMarks_CourseGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuThinButton218_Click(object sender, EventArgs e)
        {
            Back(AddMarks_Std_Course_Add_Panel,AddMarks_Student_SelectCoursePanel);

        }

        private void bunifuThinButton217_Click(object sender, EventArgs e)
        {
            var query = "UPDATE Marks SET QuizesAndAssignments='"+QuizAndAss.Text+"' ,Project='"+ProjectMarks.Text+"',Midterm='"+MidTerm.Text+"',Final='"+FinalTerm.Text+"'";
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=universityManagementSystem;Integrated Security=True");
                SqlCommand cmd = new SqlCommand(query,con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Done");
                Back(AddMarks_Std_Course_Add_Panel, AddMarks_Student_SelectCoursePanel);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    }
