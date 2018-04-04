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
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            AdminStudentPanel.Visible = false;
            AccountName.Text = userAccount.Name ;
            comboBox1.SelectedIndex = 0;


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Faculty_Click(object sender, EventArgs e)
        {

        }

        private void Students_Click(object sender, EventArgs e)
        {
            AdminStudentPanel.Visible = true;
            AdminMainPanel.Visible = false;
     

        }

        private void NameLbl_Click(object sender, EventArgs e)
        {

        }

        private void AccountName_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            AdminMainPanel.Visible = true;
            AdminStudentPanel.Visible = false;

        }

        private void AdminStudentPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            AdminMainPanel.Visible = true;
            AdminStudentPanel.Visible = false;
        }

        private void AdminStudentAddPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
       {
            try
            {

                studentLists = new List<Student>();
                departments = new List<Department>();
                SqlConnection con = new SqlConnection(@"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=universityManagementSystem;Integrated Security=True");
                SqlDataAdapter adapterStudents = new SqlDataAdapter("SELECT s.AccountID,u.Name,u.DOB,u.AddedBy,u.Username,u.password,u.AccountType,u.FName,s.StudentID,s.Department,s.Qualification FROM STUDENT s , UserAccount u where s.AccountID=u.AccountID", con);
                SqlDataAdapter adapterDepartments = new SqlDataAdapter("SELECT * FROM Department", con);

                DataSet ds = new DataSet();
                adapterStudents.Fill(ds, "Students");
                adapterDepartments.Fill(ds, "Departments");
                DataTable dtStd = ds.Tables["Students"];
                DataTable dtDep = ds.Tables["Departments"];

                foreach (DataRow dr in dtStd.Rows)
                {
                    studentLists.Add(new Student((int)dr[0], dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(),(int) dr[8], dr[9].ToString(), dr[10].ToString()));          
                }
                foreach(DataRow dr in dtDep.Rows)
                {
                    departments.Add(new Department((int)dr[0], dr[1].ToString(), dr[2].ToString(),dr[3].ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
            var query = from dep in departments select new {DepName=dep.DepartmentName,DepID= dep.DepartmentID };

            Dictionary<string, string> DictionaryCombo = new Dictionary<string, string>();
            foreach (var deptNames in query)
            {
                DictionaryCombo.Add(deptNames.DepID.ToString(), deptNames.DepName.ToString());
              

                backgroundWorker1.ReportProgress(deptNames.DepID, deptNames.DepName);
               // comboBox1.Items.Add("abc");
             //   MessageBox.Show(""+deptNames.DepName);
            }

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ComboboxItem item = new ComboboxItem();
            

            if (e.UserState!=null)
            {
                item.Text = "" + e.UserState;
                item.Value = "" + e.ProgressPercentage;

                comboBox1.Items.Add(item);
            }

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void AdminStudentAddPanel_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminStudentAddPanel.Visible = true;
            AdminStudentPanel.Visible = false;
            backgroundWorker1.RunWorkerAsync();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=universityManagementSystem;Integrated Security=True");
            try
            {
                MessageBox.Show(comboBox1.SelectedIndex.ToString());
                MessageBox.Show(comboBox1.SelectedValue.ToString());

                SqlCommand cmd = new SqlCommand("Proc_AddStd", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                /*
                 *
                 * @Name varchar(10),
@DOB date,
@AddedBy varchar(10),
@Username varchar(20),
@Password varchar(20),
@AccountType varchar(20),
@FName varchar(10),
@Department varchar(10),
@Qualification varchar(10),
                 **/
                cmd.Parameters.AddWithValue("@Name", FNameTxt.Text);
                cmd.Parameters.AddWithValue("@DOB", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@AddedBy", userAccount.AccountID);
                cmd.Parameters.AddWithValue("@Username", Username.Text);
                cmd.Parameters.AddWithValue("@Password", Password.Text);
                cmd.Parameters.AddWithValue("@AccountType", "Student");
                cmd.Parameters.AddWithValue("@FName", LNameTxt.Text);
                cmd.Parameters.AddWithValue("@Department", comboBox1.SelectedIndex);
                cmd.Parameters.AddWithValue("@Qualification", qualification.Text);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

                con.Close();
            }

            MessageBox.Show("Done");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex==1)
            {
                string value = ((KeyValuePair<string, string>)comboBox1.SelectedItem).Value;
                MessageBox.Show(value);

            }
        }
    }
}
