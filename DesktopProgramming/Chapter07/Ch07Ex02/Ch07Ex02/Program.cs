using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch07Ex02
{
    class Program
    {
        private static string[] eTypes = {"none", "simple", "index", "nested index"};
        static void Main(string[] args)
        {
            foreach (string eType in eTypes)
            {
                try
                {
                    Console.WriteLine("Main() try block reached."); // Строка 23
                    // Достигнут блок try в Main()
                    Console.WriteLine("ThrowException(\"{0}\") called.", eType); // Строка 24
                    // Вызвано TrowException
                    ThrowException(eType);
                }
                catch (System.IndexOutOfRangeException e) // Строка 28
                {
                    Console.WriteLine("Main() System.IndexOutOfRangeException catch"
                                      + " block reached. Message:\n\"{0}\"",
                        e.Message);
                }
                catch // Строка 34
                {
                    Console.WriteLine("Main() general catch block reached.");
                    // Достигнут общий блок catch в Main()
                }
                finally
                {
                    Console.WriteLine("Main() finally block reached.");
                                      // Достигнут основной блок catch в Main()
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        static void ThrowException(string exceptionType)
        {
            Console.WriteLine("ThrowException(\"{0}\") reached.", exceptionType);
            // Строка 49
                       // Достигнута функция ThrowException
            switch (exceptionType)
            {
                case "none" :
                    Console.WriteLine("Not throwing an exception.");
                                      // Исключение не генерируется
                    break; // строка 54
                case "simple" :
                    Console.WriteLine("Throwing System.Exception.");
                                      // Генерируется исключение System.Exception
                    throw (new SystemException()); // Строка 57
                case "index" :
                    Console.WriteLine("Throwing System.IndexOutOfRangeException.");
                             // Генерируется исключение System.IndexOutOfRangeException
                    throw (new System.IndexOutOfRangeException());
                    eTypes[4] = "error"; // Строка 60
                    break;
                case "nested index" :
                    try // Строка 63
                    {
                        Console.WriteLine("ThrowException(\"nested index\") " +
                                          "try block reached.");
                        // Достигнут блок try в ThrowException
                        Console.WriteLine("ThrowException(\"index\") called.");
                        // Вызвана функция ThrowException
                        ThrowException("index"); // Строа 68
                    }
                    catch // Строка 70
                    {
                        Console.WriteLine("ThrowException(\"nested index\") general"
                                          + " catch block reached.");
                        // Достигнут основной блок catch в ThrowException
                    }
                    finally
                    {
                        Console.WriteLine("ThrowException(\"nested index\") finally"
                                          + " block reached.");
                        // Достигнут блок finally в ThrowException
                    }
                    break;
            }
        }
    }
}
