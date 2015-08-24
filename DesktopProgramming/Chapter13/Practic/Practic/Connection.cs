using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Practic
{
    public delegate void MessageHandler(Connection Source, MessageArrivedEventArgs e);
    public class Connection
    {
        public event MessageHandler MessageArrived;
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private Timer pollTimer;
        public Connection()
        {
            pollTimer = new Timer(100);
            pollTimer.Elapsed += new ElapsedEventHandler(CheckForMessage);
        }
        public void Connect()
        {
            pollTimer.Start();
        }
        public void Disconnect()
        {
            pollTimer.Stop();
        }
        private static Random random = new Random();
        public void CheckForMessage(object source, EventArgs e)
        {
            if (source is Timer)
            {
                Console.WriteLine("Event from {0}", ((Timer)source).ToString());
                Console.WriteLine("Properties of event: {0}", ((ElapsedEventArgs)e).SignalTime);
                if ((random.Next(9) == 0) && (MessageArrived != null))
                {
                    MessageArrived(this, new MessageArrivedEventArgs("Hello mum!"));
                }
            }
            if (source is Connection)
            {
                Console.WriteLine("Event from {0}", ((Connection)source).ToString());
                Console.WriteLine("Properties of event: {0}", ((MessageArrivedEventArgs)e).Message);
            }
        }
    }
}
