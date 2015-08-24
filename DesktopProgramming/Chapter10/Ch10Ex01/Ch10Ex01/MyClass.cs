using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch10Ex01
{
    class MyClass
    {
        public readonly string Name;
        private int intVal;

        public int Val
        {
            get
            {
                return intVal;
            }
            set
            {
                if (value >= 0 && value <= 10)
                    intVal = value;
                else
                    throw (new ArgumentOutOfRangeException("Val", value,
                      "Val must be assigned a value between 0 and 10."));
                      // Val может присваиваться только значение в диапазоне от 0 до 10 
            }
        }

        public override string ToString()
        {
            return "Name: " + Name + "\nVal: " + Val;
        }

        private MyClass() : this("Default name")
        {
        }

        public MyClass(string newName)
        {
            Name = newName;
            intVal = 0;
        }
    }
}
