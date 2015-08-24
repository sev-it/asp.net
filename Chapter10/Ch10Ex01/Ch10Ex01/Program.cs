using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch10Ex01
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Creating object myObj...");
            // Создание объекта myObj.. . 
            MyClass myObj = new MyClass("My Object");
            Console.WriteLine("myObj created.");
            // Объект myObj создан 
            for (int i = -1; i <= 0; i++)
            {
                try
                {
                    Console.WriteLine("\nAttempting to assign {0} to myObj.Val...", i);
                    // Попытка присвоить myObj.Val значение 
                    myObj.Val = i;
                    Console.WriteLine("Value {0} assigned to myObj.Val.", myObj.Val);
                    // Значение myObj.Val присвоено 
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception {0} thrown.", e.GetType().FullName);
                    // Сгенерировано исключение 
                    Console.WriteLine("Message:\n\"{0}\"", e.Message);
                    Console.WriteLine("\nOutputting myObj.ToString()...");
                    // Вывод myObj.ToString () ... 
                    Console.WriteLine(myObj.ToString());
                    Console.WriteLine("myObj.ToString() Output.");
                    Console.ReadKey();
                }

            }
        }
    }
}
