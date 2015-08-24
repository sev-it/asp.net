using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic
{
    class Program
    {
        private static void Main(string[] args)
        {
            string myString = Console.ReadLine();
            char[] myChar = myString.ToCharArray();
            Console.WriteLine(myString);

            for (int i = myString.Length - 1; i >= 0; --i)
            {
                Console.Write(myChar[i]);
            }
            Console.Write("\n Часть вторая\n");
            char[] separators = {' ', ','};
            string[] myWords;
            myWords = myString.Split(separators);
            myString = "";
            for (int i = 0; i < myWords.Length; i++)
            {
                if (myWords[i].ToLower() == "no")
                    myWords[i] = "yes";
            myString = myString + ' ' + myWords[i];
            }
            Console.WriteLine(myString,"\n Часть третья");
            myString = "";
            for (int i = 0; i < myWords.Length; i++)
                myString = myString + " \"" + myWords[i] + "\"";
            Console.WriteLine(myString);
        Console.ReadKey();
        }
    }
}
