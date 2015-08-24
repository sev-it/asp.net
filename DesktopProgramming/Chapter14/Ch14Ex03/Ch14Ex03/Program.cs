using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtensionLib;

namespace Ch14Ex03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string to convert:");
                // Введите строку, подлежащую преобразованию 
            string sourceString = Console.ReadLine();
            Console.WriteLine("String with title casing: {0}",
            sourceString.ToTitleCase(true));
                // Строка со словами, начинающимися с заглавной буквы 
            Console.WriteLine("String backwards: {0}", sourceString.ReverseString());
                // Строка в обратном порядке 
            Console.WriteLine("String length backwards: {0}",
            sourceString.Length.ToStringReversed());
                // Длина строки в обратном порядке 
            Console.ReadKey(); 
        }
    }
}
