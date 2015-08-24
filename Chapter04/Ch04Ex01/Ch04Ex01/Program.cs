using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch04Ex01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter an integer:"); // Введите целое число
            int myInt = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Integer less than 10? {0}", myInt < 10);
                            // Это целое число меньше 10?
            Console.WriteLine("Integer between 0 and 5? {0}", (0 <= myInt) && (myInt <= 5));
                            // Это целове число находится в диапазоне между 0 and 5?
            Console.WriteLine("Bitwise AND of Integer and 10 = {0}", myInt & 10);
                            // Результат выполнения поразрядной операции И
                            // для указанного целого числа и 10
            Console.ReadKey();
        }
    }
}
