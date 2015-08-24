using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch06Ex05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("{0} command line arguments were specified:", args.Length); 
                               // Вывод аргументов командной строки 
            foreach (string arg in args) 
                Console.WriteLine(arg); 
            Console.ReadKey(); 
        } 
    }
}
