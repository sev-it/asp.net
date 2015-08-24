using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch06Ex06
{
    internal class Program
    {
        delegate double ProcessDelegate(double param1, double param2);

        static double Multiply(double param1, double param2)
        {
            return param1*param2;
        }

        static double Divide(double param1, double param2)
        {
            return param1/param2;
        }

        static void Main(string[] args)
        {
            ProcessDelegate process;
            Console.WriteLine("Enter 2 numbers separated with a comma:");
                               // Введите 2 числа, отделив их друг от друга запятой 
            string input = Console.ReadLine();
            int commaPos = input.IndexOf(',');
            double paraml = Convert.ToDouble(input.Substring(0, commaPos));
            double param2 = Convert.ToDouble(input.Substring(commaPos + 1,
                input.Length - commaPos - 1));
            Console.WriteLine("Enter M to multiply or D to divide:");
                               // Введите М, если хотите выполнить операцию умножения, 
                               // или D, если операцию деления 
            input = Console.ReadLine();
            if (input == "M")
                process = new ProcessDelegate(Multiply);
            else
                process = new ProcessDelegate(Divide);
            Console.WriteLine("Result: {0}", process(paraml, param2));
                               // Вывод результата 
            Console.ReadKey();
        }
    }
}