using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch04Ex04
{
    class Program
    {
        static void Main(string[] args)
        {
            double balance, interestRate, targetBalance;
            Console.WriteLine("What is your current balance?"); // Каков ваш текущий баланс?
            balance = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("What is your current annual interest rate (in %)?");
            // Какова ежегодная ставка (в процентах)?
            interestRate = 1 + Convert.ToDouble(Console.ReadLine()) / 100.0;
            Console.WriteLine("What balance whould you like to have?");
            // Какой баланс необходимо получить?
            targetBalance = Convert.ToDouble(Console.ReadLine());
            int totalYears = 0;
            while (balance < targetBalance)
            {
                balance *= interestRate;
                ++totalYears;
            }
            Console.WriteLine("In {0} year{1} you'll have a balance of {2}.",
                               totalYears, totalYears == 1 ? "" : "s", balance);
            // Вывод баланса через заданное количество лет
            Console.ReadKey();
        }
    }
}
