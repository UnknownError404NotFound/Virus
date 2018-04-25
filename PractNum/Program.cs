using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PractNum
{


    class Program
    {
        static Dictionary<string, string> dictionary1 = new Dictionary<string, string>();
        static Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
        public static void Main()
        {
            Program tt = new Program(); // Create a common instance
            new Thread(tt.Go).Start();
            tt.Go();

            Console.ReadLine();
        }
        public static void Linq41()
        {
            dictionary1.Add("1", "abc");
            dictionary1.Add("2", "xbc");
            dictionary1.Add("3", "ybc");

            dictionary2.Add("1", "z1");
            dictionary2.Add("2", "z2");
            dictionary2.Add("3", "z3");
            var q = from d in dictionary1 join d1 in dictionary2 on d.Key equals d1.Key select new { val1 = d.Value , val2 = d1.Value};
            foreach(var z in q)
            {
                Console.WriteLine(z.val1);

                Console.WriteLine(z.val2);
            }

        }
        static bool done;
        void Go()
        {
            if (!done)
            {
                done = true;
                Console.WriteLine("Done");
            }
            else
            {

                Console.WriteLine("Not Done");
            }
        }



    }
}

