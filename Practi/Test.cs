using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practi
{
    public class Test
    {
        string Name;
        string FName;

        public Test(string name, string fName)
        {
            Name = name;
            FName = fName;
        }

        public string Name1
        {
            get
            {
                return Name;
            }

            set
            {
                Name = value;
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
    }
}
