using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic
{
    class Program
    {
        static string ToAcroym(string inputString)
        {
            return inputString.Split(' ').Aggregate("", (x, y) =>y!=""?x+=y.Trim().Substring(0,1):x);
        }

        static void Main(string[] args)
        {
            string s = " Privet  loh jjosh  kak dela? ";
             Console.WriteLine("{0}",ToAcroym(s));
            Console.ReadKey();
        }
    }
}
