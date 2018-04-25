using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{

    public delegate void updateNum(int i);
    class Program
    {
        public delegate int Square(int x);
        static void Main(string[] args)
        {
          //      longRunning(updateNum);
            Square obj = x => x * x;
            Console.WriteLine(obj(5));

        }

        static void longRunning(updateNum obj)
        {
            for (int i = 0; i < 100000; i++)
            {
                obj(i);
            }
        }
        static void updateNum(int i)
        {
            Console.WriteLine(i);
        }
    }
}