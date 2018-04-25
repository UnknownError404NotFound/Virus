using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManagementSystem
{
  public  class Faculty : Account
    {
        private int facultytID;
        private int department;
        private string qualification;
        private string experience;

        public int FacultytID
        {
            get
            {
                return facultytID;
            }

            set
            {
                facultytID = value;
            }
        }

        public int Department
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

        public string Experience
        {
            get
            {
                return experience;
            }

            set
            {
                experience = value;
            }
        }

        public Faculty(int accountID, string name, string dOB, string addedBy, string username, string password, string accountType, string FName, int FacultyID, int Department, string Qualification,string experience) : base(accountID, name, dOB, addedBy, username, password, accountType, FName)
        {
            this.FacultytID = FacultyID;
            this.Department = Department;
            this.Qualification = Qualification;
            this.Experience = experience;
        }

    }
}
