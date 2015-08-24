using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Ch13Ex03
{
    public class Display
    {
        public void DisplayMessage(object source, EventArgs e)
        {
            if (source is Connection)
            {
                Console.WriteLine("Message arrived from: {0}", ((Connection) source).Name);
                Console.WriteLine("Message text: {1}", ((MessageArrivedEventArgs) e).Message);
            }
            else
            {
            }
        }
    }
}
