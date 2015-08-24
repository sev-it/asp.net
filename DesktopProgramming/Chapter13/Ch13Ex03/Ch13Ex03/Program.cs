using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Ch13Ex03
{
    class Program
    {
        static void Main(string[] args)
        {
            Connection myConnection1 = new Connection();
            myConnection1.Name = "First connection";

            Display myDisplay = new Display();
            myConnection1.MessageArrived += new MessageHandler(myConnection1.CheckForMessage);
            myConnection1.Connect();

            Console.ReadKey(); 
        }
    }
}
