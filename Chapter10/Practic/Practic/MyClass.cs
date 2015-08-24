using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic
{
    class MyClass
    {
        private string myString;

        public string ContainedString
        {
            set
            {
                myString = value;
            }
        }
        public virtual string GetString()
        {
            return myString;
        }
    }

    class MyDerivedClass : MyClass
    {
        public override string GetString()
        {
            Console.WriteLine("Output from derived class.");
            return base.GetString();
        }
    }

    class MyCopyableClass
    {
        public int myNumber;
        public MyCopyableClass(int myNumber)
        {
            this.myNumber = myNumber;
        }

        public MyCopyableClass() : this(5)
        {
        }

        public MyCopyableClass GetCopy()
        {
            MyCopyableClass other = (MyCopyableClass) this.MemberwiseClone();
            return other;
        }
    }
}
