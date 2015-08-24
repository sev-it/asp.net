using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ch10CardLib;

namespace Practic
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            MyCopyableClass myObj = new MyCopyableClass();
            Console.WriteLine("myObj: {0}", myObj.myNumber);
            MyCopyableClass myCopy = myObj.GetCopy();
            Console.WriteLine("myCopy: {0}", myCopy.myNumber);
            myObj.myNumber = 6;
            Console.WriteLine("myObj: {0}\nmyCopy: {1}", myObj.myNumber, myCopy.myNumber);
            /// <summary>
            /// Клиенсткое приложение для Ch10CardLib
            /// </summary>
            Deck myDeck = new Deck();
            myDeck.Shuffle();
            bool Result = true;
            for (int count = 1; count < 52; count ++)
            {
                if (count%5 == 0)
                {
                    if (Result) Console.WriteLine("Flash!s");
                    else
                    {
                        Console.WriteLine("Not flash!");
                    }
                    Result = true;
                }
                Result = Result & myDeck.GetCard(count - 1).suit == myDeck.GetCard(count).suit;
            }   
            Console.ReadKey();
        }
    }
}
