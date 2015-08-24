using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch04Ex02
{
    class Program
    {
        static void Main(string[] args)
        {
            string comparison;
            Console.WriteLine("Enter a number:");
                             // Введите число
            double var1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter another number:");
                             // Введите ще одно число
            double var2 = Convert.ToDouble(Console.ReadLine());
            if (var1 < var2)
                comparison = "less than";
                            // Меньше чем
            else
            {
                if (var1 == var2)
                    comparison = "equal to";
                            // Равно
                else
                    comparison = "greater than";
                            // Больше чем
            }
            Console.WriteLine("The first number is {0} the second number.", comparison);
                            // Вывод результата сравнения чисел
            Console.ReadKey();
        }
    }
}
