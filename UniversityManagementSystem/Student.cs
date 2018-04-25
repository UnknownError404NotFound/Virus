using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManagementSystem
{
   public class Student : Account
    {
        public int studentID;
        private string department;
        private string qualification;

        public Student(int accountID, string name, string dOB, string addedBy, string username, string password, string accountType, string FName, int studentID, string Department, string Qualification) : base(accountID, name, dOB, addedBy, username, password, accountType, FName)
        {
            this.studentID = studentID;
            this.Department = Department;
            this.Qualification = Qualification;
        }

        public int StudentID
        {
            get
            {
                return studentID;
            }

            set
            {
                studentID = value;
            }
        }

        public string Department
        {
            get
            {
                return department;
            }

            set
            {
                department = value;
            }
        }

        public string Qualification
        {
            get
            {
                return qualification;
            }

            set
            {
                qualification = value;
            }
        }
    }
}
