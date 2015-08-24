using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch11Ex04
{
    internal class Checker
    {
        public void Check(object param1)
        {
            if (param1 is ClassA)
                Console.WriteLine("Variable can be converted to ClassA.");
                // Переменная может быть преобразована в ClassA 
            else
                Console.WriteLine("Variable can't be converted to ClassA.");
            // Переменная не может быть преобразована в ClassA 
            if (param1 is IMylnterface)
                Console.WriteLine("Variable can be converted to IMylnterface.");
                // Переменная может быть преобразована в IMylnterface 
            else
                Console.WriteLine("Variable can't be converted to IMylnterface.");
            // Переменная не может быть преобразована в IMylnterface 
            if (param1 is MyStruct)
                Console.WriteLine("Variable can be converted to MyStruct.");
                // Переменная может быть преобразована в MyStruct 
            else
                Console.WriteLine("Variable can't be converted to MyStruct.");
            // Переменная не может быть преобразована в MyStruct 
        }
    }

    interface IMylnterface
    {
    }

    class ClassA : IMylnterface
    {
    }

    class ClassB : IMylnterface
    {
    }

    class ClassC
    {
    }

    class ClassD : ClassA
    {
    }

    struct MyStruct : IMylnterface
    {
    }

    class Program
    {
        static void Main(string[] args)
        {
            Checker check = new Checker(); 
            ClassA try1 = new ClassA();
            ClassB try2 = new ClassB();
            ClassC try3 = new ClassC();
            ClassD try4 = new ClassD();
            MyStruct try5 = new MyStruct();
            object try6 = try5;
            Console.WriteLine("Analyzing ClassA type variable:");
                              // Анализ переменной типа ClassA 
            check.Check(try1);
            Console.WriteLine("\nAnalyzing ClassB type variable:"); 
                              // Анализ переменной типа ClassB 
            check.Check(try2);
            Console.WriteLine("\nAnalyzing ClassC type variable:");
                              // Анализ переменной типа ClassC 
            check.Check(try3);
            Console.WriteLine("\nAnalyzing ClassD type variable:");
                              // Анализ переменной типа ClassD  
            check.Check(try4);
            Console.WriteLine("\nAnalyzing MyStruct type variable:");
                              // Анализ переменной типа MyStruct  
            check.Check(try5);
            Console.WriteLine("\nAnalyzing boxed MyStruct type variable:"); 
                              // Анализ упакованной 
            check.Check(try6); 
            Console.ReadKey(); 
        }
    }
}
