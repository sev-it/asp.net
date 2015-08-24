using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch06Ex04
{
    class Program
    {
        private static string myString;
        static void Write()
        {
            string myString = "String defined in Write()";
                               // Строка, определённая в функции Write()
            Console.WriteLine("Now in Write()");
                               // Теперь в функции Write()
            Console.WriteLine("Local myString = {0}", myString);
                               // Локальная переменная
            Console.WriteLine("Global myString = {0}", Program.myString);
                               // Глобальная переменная
        }
        static void Main(string[] args)
        {
            string myString = "String defined in Main()";
            Program.myString = "Global string";
            Write();
            Console.WriteLine("\nNow in Main()");
            Console.WriteLine("Local myString = {0}", myString);
            Console.WriteLine("Global myString = {0}", Program.myString);
            Console.ReadKey();
        }
    }
}
