﻿using System;
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
    public partial class Form1 : Form
    {
        List<Account> AccountsLists;
        public Form1()
        {
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
          var LinQuery = from acc in AccountsLists
                      where acc.Username.Equals(usernameTxt.Text.ToString())
                      && acc.Password.Equals(PassTxt.Text.ToString())
                      select new {Role=acc.AccountType };
            MessageBox.Show(""+ LinQuery);

            if (LinQuery.Any())
            {
                var a = LinQuery.First();
                MessageBox.Show(""+a.Role);
               
              /*  foreach (var a in LinQuery)
                {
                    MessageBox.Show(a.Role);
                }*/

            }
            else
            {
                MessageBox.Show("Incorrect Username / Password. Please Try Again","Login Error");
            }

           

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try {
                AccountsLists = new List<Account>();
            SqlConnection con = new SqlConnection(@"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=universityManagementSystem;Integrated Security=True");
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM UserAccount",con);
            DataSet ds = new DataSet();
            adapter.Fill(ds,"UserAccount");
            DataTable dt = ds.Tables["UserAccount"];
            foreach(DataRow dr in dt.Rows)
            {
                    AccountsLists.Add(new Account((int)dr[0],dr[1].ToString(),dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString()));
            }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
            }
    }
}
