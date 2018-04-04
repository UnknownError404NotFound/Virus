using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManagementSystem
{
   public class Department
    {
        int departmentID;
        string departmentName;
        string hOD;
        string addedBy;

        public int DepartmentID
        {
            get
            {
                return departmentID;
            }

            set
            {
                departmentID = value;
            }
        }

        public string DepartmentName
        {
            get
            {
                return departmentName;
            }

            set
            {
                departmentName = value;
            }
        }

        public string HOD
        {
            get
            {
                return hOD;
            }

            set
            {
                hOD = value;
            }
        }

        public string AddedBy
        {
            get
            {
                return addedBy;
            }

            set
            {
                addedBy = value;
            }
        }

        public Department(int departmentID, string departmentName, string hOD, string addedBy)
        {
            this.DepartmentID = departmentID;
            this.DepartmentName = departmentName;
            this.HOD = hOD;
            this.AddedBy = addedBy;
        }
    }
}
