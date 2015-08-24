using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch14Ex01
{
    public class Cow : Animal
    {
        public void Milk()
        {
            Console.WriteLine("{0} has been milked.", name);
                              // Вывд информации о доении
        }
        public override void MakeANoise()
        {
            Console.WriteLine("{0} says 'moo!'", name);
        }
        public Cow(string newName) : base(newName)
        {
        }
        public Cow()
        {
        }
    }
}
