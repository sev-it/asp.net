using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> myString = new List<string>();
            myString.Add("1");
            myString.Add("2");
            myString.Add("3");
            ShortCollection<string> myShort = new ShortCollection<string>(3,myString);
            Console.WriteLine("{0}",myShort.Capacity);
            myShort.Add("5");
            Console.ReadKey();
        }
    }
}
