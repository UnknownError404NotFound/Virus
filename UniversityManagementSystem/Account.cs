using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManagementSystem
{
   public class Account
    {
        int accountID;
        String name;
        String dOB;
        String addedBy;
        String username;
        String password;
        String accountType;
        String FName;
        private string v1;
        private string v2;
        private string v3;

        public int AccountID
        {
            get
            {
                return accountID;
            }

            set
            {
                accountID = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string DOB
        {
            get
            {
                return dOB;
            }

            set
            {
                dOB = value;
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

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public string AccountType
        {
            get
            {
                return accountType;
            }

            set
            {
                accountType = value;
            }
        }

        public string FName1
        {
            get
            {
                return FName;
            }

            set
            {
                FName = value;
            }
        }

        public Account(int accountID, string name, string dOB, string addedBy, string username, string password, string accountType,string FName)
        {
            this.AccountID = accountID;
            this.Name = name;
            this.DOB = dOB;
            this.AddedBy = addedBy;
            this.Username = username;
            this.Password = password;
            this.AccountType = accountType;
            this.FName1 = FName;
        }

        public Account(int accountID, string name, string dOB, string addedBy, string username, string password, string accountType, string FName, string v1, string v2, string v3) : this(accountID, name, dOB, addedBy, username, password, accountType, FName)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
        }
    }
}
