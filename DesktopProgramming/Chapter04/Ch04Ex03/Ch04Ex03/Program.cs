﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch04Ex03
{
    class Program
    {
        static void Main(string[] args)
        {
            const string myName = "karli";
            const string sexyName = "angelina";
            const string sillyName = "ploppy";
            string name;
            Console.WriteLine("What is your name?"); // Как вас зовут?
            name = Console.ReadLine();
            switch (name.ToLower())
            {
                case myName:
                    Console.WriteLine("You have the same name as me!");
                                       // У вас такое же имя, как и у меня!
                    break;
                case sexyName:
                    Console.WriteLine("My, what a sexy name you have!");
                                       // Забавное у вас имя!
                    break;
                case sillyName:
                    Console.WriteLine("That's a very silly name.");
                                       // Это очкеь глупое имя.
                    break;
            }
            Console.WriteLine("Hello {0}!", name); // Приветствие
            Console.ReadKey();
        }
    }
}
